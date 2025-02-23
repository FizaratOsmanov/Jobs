namespace PL
{
    public static  class PLService
    {
        public static void AddPLService(this  IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Admin/Account/Login";
                opt.AccessDeniedPath = "/";
            });
        }
    }
}
