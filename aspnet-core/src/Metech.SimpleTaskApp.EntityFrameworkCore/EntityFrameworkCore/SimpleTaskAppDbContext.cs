using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Metech.SimpleTaskApp.Authorization.Roles;
using Metech.SimpleTaskApp.Authorization.Users;
using Metech.SimpleTaskApp.MultiTenancy;
using Metech.SimpleTaskApp.Tasks;
using Metech.SimpleTaskApp.People;

namespace Metech.SimpleTaskApp.EntityFrameworkCore
{
    public class SimpleTaskAppDbContext : AbpZeroDbContext<Tenant, Role, User, SimpleTaskAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public SimpleTaskAppDbContext(DbContextOptions<SimpleTaskAppDbContext> options)
            : base(options)
        {
        }
    }
}
