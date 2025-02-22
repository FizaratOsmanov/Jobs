using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;

namespace DATA.Repositories.Implementations
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
