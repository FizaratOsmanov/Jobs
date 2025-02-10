using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DATA.Repositories.Implementations
{
    public class SliderItemRepository : Repository<SliderItem>, ISliderItemRepository
    {
        public SliderItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
