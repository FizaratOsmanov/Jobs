using AutoMapper;
using BL.DTOs.ApplyJobDTOs;
using BL.DTOs.JobDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Utilities;
using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BL.Services.Implementations
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IApplyJobService _applyJobService;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, ICategoryRepository categoryRepository, IApplyJobService applyJobService, IMapper mapper,AppDbContext appDbContext)
        {
            _jobRepository = jobRepository;
            _categoryRepository = categoryRepository;
            _applyJobService = applyJobService;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task CreateJobAsync(CreateJobDTO dto)
        {
            if (await _categoryRepository.GetByIdAsync(dto.CategoryId) is null) throw new BaseException("Category not found!");

            Job job = _mapper.Map<Job>(dto);
            job.CompanyIconPath = await dto.CompanyIcon.SaveAsync("Jobs");

            await _jobRepository.CreateAsync(job);
            await _jobRepository.SaveChangesAsync();
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            Job? job = await _jobRepository.GetByIdAsync(id, "Category", "ApplyJobs");
            if (job == null) throw new BaseException("Job not found");
            return job;
        }

        public async Task<ICollection<AdminGetJobDTO>> GetJobAdminItemsAsync()
        {
            ICollection<Job> jobs = await _jobRepository.GetAllAsync("Category", "ApplyJobs");
            return _mapper.Map<ICollection<AdminGetJobDTO>>(jobs);
        }

        public async Task<UpdateJobDTO> GetJobByIdForUpdateAsync(int id)
        {
            Job? job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new BaseException("Job not found");
            return _mapper.Map<UpdateJobDTO>(job);
        }

        public async Task<ICollection<JobDetailDTO>> GetJobForDetailViewAsync()
        {
            ICollection<Job> jobs = await _jobRepository.GetAllAsync("Category", "ApplyJobs");
            return _mapper.Map<ICollection<JobDetailDTO>>(jobs);
        }

        public async Task<ICollection<JobListDTO>> GetJobForListViewAsync()
        {
            ICollection<Job> jobs = await _jobRepository.GetAllAsync("Category", "ApplyJobs");
            return _mapper.Map<ICollection<JobListDTO>>(jobs);
        }

        public async Task HardDeleteJobAsync(int id)
        {
            Job job = await GetJobByIdAsync(id);
            _jobRepository.HardDelete(job);
            if (!string.IsNullOrEmpty(job.CompanyIconPath))
            {
                File.Delete(Path.Combine("wwwroot", "Uploads", "Jobs", job.CompanyIconPath));
            }
            await _jobRepository.SaveChangesAsync();
        }

        public async Task SoftDeleteJobAsync(int id)
        {
            Job job = await GetJobByIdAsync(id);
            _jobRepository.SoftDelete(job);
            if (!string.IsNullOrEmpty(job.CompanyIconPath))
            {
                File.Delete(Path.Combine("wwwroot", "Uploads", "Jobs", job.CompanyIconPath));
            }
            await _jobRepository.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(UpdateJobDTO dto)
        {
            Job? oldJob = await GetJobByIdAsync(dto.Id);
            if (oldJob == null) throw new BaseException("Job not found!");

            Job newJob = _mapper.Map<Job>(dto);
            newJob.CreatedDate = oldJob.CreatedDate;

            newJob.CompanyIconPath = dto.CompanyIcon != null
                ? await dto.CompanyIcon.SaveAsync("Jobs")
                : oldJob.CompanyIconPath;

            _jobRepository.Update(newJob);
            if (dto.CompanyIcon != null)
            {
                File.Delete(Path.Combine("wwwroot", "Uploads", "Jobs", oldJob.CompanyIconPath));
            }

            await _jobRepository.SaveChangesAsync();
        }

        public async Task<ICollection<GetApplyJobDTO>> GetJobApplicationsAsync(int jobId)
        {
            Job job = await GetJobByIdAsync(jobId);
            return _mapper.Map<ICollection<GetApplyJobDTO>>(job.ApplyJobs);
        }

        public async Task<List<JobListDTO>> GetJobsByCategoryAsync(int categoryId)
        {
            return await _appDbContext.Jobs
                .Where(j => j.CategoryId == categoryId && !j.IsDeleted)
                .Select(j => new JobListDTO
                {
                    Id = j.Id,
                    Title = j.Title,
                    Location = j.Location,
                    JobNature = j.JobNature,
                    MinSalary = j.MinSalary,
                    MaxSalary = j.MaxSalary,
                    CompanyIconPath = j.CompanyIconPath,
                    DateLine = j.DateLine
                })
                .ToListAsync();
        }
    }
}
