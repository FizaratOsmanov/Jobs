using AutoMapper;
using BL.DTOs.CommentDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using DATA.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace BL.Services.Implementations;

public class CommentService : ICommentService
{
    readonly ICommentRepository _commentRepository;
    readonly IAccountService _accountService;
    readonly AppDbContext _appDbContext;
    readonly IMapper _mapper;
    public CommentService(ICommentRepository commentRepository, IMapper mapper, IAccountService accountService,AppDbContext appDbContext)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _appDbContext = appDbContext;   
        _accountService = accountService;
    }

    public async Task<Comment> GetCommentByIdForAsync(int id)
    {
        Comment? comment = await _commentRepository.GetByIdAsync(id, "AppUser");
        if (comment == null) throw new BaseException("Comment not found");
        return comment;
    }
    public async Task<ICollection<AdminGetCommentDTO>> GetAllCommentForAdminAsync()
    {
        ICollection<Comment> comment = await _commentRepository.GetAllAsync("AppUser");
        if (comment == null) throw new BaseException("Comment not found");
        ICollection<AdminGetCommentDTO> dto = _mapper.Map<ICollection<AdminGetCommentDTO>>(comment);
        return dto;
    }
    public async Task<ICollection<GetCommentDTO>> GetAllCommentForViewAsync()
    {
        ICollection<Comment> comment = await _commentRepository.GetAllAsync("AppUser");
        if (comment == null) throw new BaseException("Comment not found");
        ICollection<GetCommentDTO> dto = _mapper.Map<ICollection<GetCommentDTO>>(comment);
        return dto;
    }

    public async Task CreateCommentAsync(CreateCommentDTO dto, string userId)
    {
        var user = await _accountService.GetCurrentUserAsync(userId);
        if (user == null)
        {
            throw new BaseException("User not found");
        }

        Comment comment = new()
        {
            Message = dto.Message,
            AppUserId = Guid.Parse(userId),
            FirstName = user.FirstName,       
            Profession = user.Profession,     
            PhotoPath = user.PhotoPath,
            CreatedDate = DateTime.UtcNow
        };

        await _commentRepository.CreateAsync(comment);
        await _commentRepository.SaveChangesAsync();
    }


    public async Task HardDeleteCommentAsync(int id)
    {
        Comment? comment = await GetCommentByIdForAsync(id) ?? throw new BaseException("Comment not Found");
        _commentRepository.HardDelete(comment);
        await _commentRepository.SaveChangesAsync();

    }
    public async Task SoftDeleteCommentAsync(int id)
    {
        Comment? comment = await GetCommentByIdForAsync(id) ?? throw new BaseException("Comment not Found");
        _commentRepository.SoftDelete(comment);
        await _commentRepository.SaveChangesAsync();
    }
}
