using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;

namespace BL.Services.Abstractions
{
    public  interface IUserLikeService
    {
        Task LikeJobAsync(UserLike userLike);
        Task<ICollection<Job>> GetLikedJobsAsync(string userId);
    }
}
