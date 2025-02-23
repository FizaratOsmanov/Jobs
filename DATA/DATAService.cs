using DATA.Repositories.Abstractions;
using DATA.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DATA
{
    public static class DATAService
    {
        public static void AddDATAService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ISliderItemRepository, SliderItemRepository>();
        }
    }
}
