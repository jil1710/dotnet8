using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthChangeInDotNet8.DataContext
{
    public class ApplicationdbContext : IdentityDbContext<MyUser>
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options) 
        {
        
        }
        
    }
}
