using System.Net;
using System.Net.Mail;
using AutoMapper;
using BL.DTOs.ApplyJobDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Models;
using DATA.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BL.Services.Implementations
{
    public class ApplyJobService : IApplyJobService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ApplyJobService(AppDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task SendEmailAsync(ApplyJob applyJob, string cvFilename)
        {
            using (var smtpClient = new SmtpClient(_configuration["Smtp:Host"]))
            {
                smtpClient.Port = int.Parse(_configuration["Smtp:Port"]);
                smtpClient.Credentials = new NetworkCredential(
                    _configuration["Smtp:Username"],
                    _configuration["Smtp:Password"]
                );
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_configuration["Smtp:FromEmail"]);
                    mailMessage.To.Add(_configuration["Smtp:ToEmail"]);
                    mailMessage.Subject = "Yeni İş Müraciəti: " + applyJob.Name;
                    mailMessage.Body = $"Ad: {applyJob.Name}<br>Email: {applyJob.Email}<br>Portfolio: {applyJob.Portfolio}<br><br>Cover Letter:<br>{applyJob.CoverLetter}";
                    mailMessage.IsBodyHtml = true;

                    if (!string.IsNullOrEmpty(applyJob.Email))
                    {
                        mailMessage.ReplyToList.Add(new MailAddress(applyJob.Email));
                    }

                    if (!string.IsNullOrEmpty(cvFilename))
                    {
                        string filePath = Path.Combine("wwwroot", "Uploads", "CVs", cvFilename);
                        if (File.Exists(filePath))
                        {
                            mailMessage.Attachments.Add(new Attachment(filePath));
                        }
                    }
                    var jobExists = await _context.Jobs.AnyAsync(j => j.Id == applyJob.JobId);
                    if (!jobExists)
                    {
                        throw new Exception($"JobId {applyJob.JobId} does not exist in Jobs table.");
                    }

                    await smtpClient.SendMailAsync(mailMessage);
                    _context.ApplyJobs.Add(applyJob);
                    await _context.SaveChangesAsync();
                }
            }
        }


        public async Task<ICollection<GetApplyJobDTO>> GetApplicationsByJobIdAsync(int jobId)
        {
            var applications = await _context.ApplyJobs
                .Where(a => a.JobId == jobId)
                .ToListAsync();

            return _mapper.Map<ICollection<GetApplyJobDTO>>(applications);
        }

        public async Task DeleteApplicationsByJobIdAsync(int jobId)
        {
            var applications = await _context.ApplyJobs
                .Where(a => a.JobId == jobId)
                .ToListAsync();

            if (applications.Any())
            {
                _context.ApplyJobs.RemoveRange(applications);
                await _context.SaveChangesAsync();
            }
        }
    }
}
