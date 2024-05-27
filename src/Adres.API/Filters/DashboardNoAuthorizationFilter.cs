using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Adres.API.Filters
{
    public class DashboardNoAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}