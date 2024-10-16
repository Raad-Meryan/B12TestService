using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using B12Test.Authorization.Roles;
using B12Test.Authorization.Users;
using B12Test.Entities;
using B12Test.MultiTenancy;

namespace B12Test.EntityFrameworkCore
{
    public class B12TestDbContext : AbpZeroDbContext<Tenant, Role, User, B12TestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }



        public B12TestDbContext(DbContextOptions<B12TestDbContext> options)
            : base(options)
        {
        }
    }
}
