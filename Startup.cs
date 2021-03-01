using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team3SemesterProject.Startup))]
namespace Team3SemesterProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
