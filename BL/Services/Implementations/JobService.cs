using AutoMapper;
using BL.DTOs.JobDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Utilities;
using CORE.Models;
using DATA.Repositories.Abstractions;
namespace BL.Services.Implementations;

public class JobService : IJobService
{
    readonly IJobRepository _jobRepository;
    readonly ICategoryRepository _categoryRepository;
    readonly IMapper _mapper;
    public JobService(IJobRepository jobRepository,ICategoryRepository categoryRepository,IMapper mapper)
    {
        _categoryRepository=categoryRepository;
        _jobRepository = jobRepository;
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
       Job? job= await _jobRepository.GetByIdAsync(id,"Category");
        if (job == null) throw new BaseException("Job not found");
        return job;
    }
    public async Task<ICollection<AdminGetJobDTO>> GetJobAdminItemsAsync()
    {
        ICollection<Job> jobs = await _jobRepository.GetAllAsync("Category");
        ICollection<AdminGetJobDTO> dto=_mapper.Map<ICollection<AdminGetJobDTO>>(jobs);
        return dto;
    }
    public async Task<UpdateJobDTO> GetJobByIdForUpdateAsync(int id)
    {
        Job? job=await  _jobRepository.GetByIdAsync(id);
        if (job == null) throw new BaseException("Job not found");
        UpdateJobDTO dto=_mapper.Map<UpdateJobDTO>(job);
        return dto;
    }
    public async Task<ICollection<JobDetailDTO>> GetJobForDetailViewAsync()
    {
        ICollection<Job> jobs=await _jobRepository.GetAllAsync("Category");
        ICollection<JobDetailDTO> dto=_mapper.Map<ICollection<JobDetailDTO>>(jobs);
        return dto;
    }
    public async Task<ICollection<JobListDTO>> GetJobForListViewAsync()
    {
        ICollection<Job> jobs = await _jobRepository.GetAllAsync("Category");
        ICollection<JobListDTO> dto = _mapper.Map<ICollection<JobListDTO>>(jobs);
        return dto;
    }
    public async Task HardDeleteJobAsync(int id)
    {
        Job job=await GetJobByIdAsync(id);
        _jobRepository.HardDelete(job);
        if(job.CompanyIconPath != null ) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "Uploads", "Jobs", job.CompanyIconPath));
        await _jobRepository.SaveChangesAsync();
    }
    public async Task SoftDeleteJobAsync(int id)
    {
        Job job = await GetJobByIdAsync(id);
        _jobRepository.SoftDelete(job);
        if (job.CompanyIconPath != null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "Uploads", "Jobs", job.CompanyIconPath));
        await _jobRepository.SaveChangesAsync();
    }
    public async Task UpdateJobAsync(UpdateJobDTO dto)
    {
        if (await _categoryRepository.GetByIdAsync(dto.CategoryId) is null) throw new BaseException("Category not found!");
        Job? oldJob = await GetJobByIdAsync(dto.Id);
        if (oldJob == null)
        {
            throw new BaseException("Job not found!");
        }
        Job newJob = _mapper.Map<Job>(dto);
        newJob.CreatedDate = oldJob.CreatedDate;
        newJob.CompanyIconPath = dto.CompanyIcon is not null ? await dto.CompanyIcon.SaveAsync("Jobs") : oldJob.CompanyIconPath;
        _jobRepository.Update(newJob);
        if (dto.CompanyIcon is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "Uploads", "Jobs", oldJob.CompanyIconPath));
        await _jobRepository.SaveChangesAsync();

    }
}

