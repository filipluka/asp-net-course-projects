
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;
namespace Infrastructure.Contexts;

public class APIContext(DbContextOptions<APIContext> options) : DbContext(options)
{
    public DbSet<SubscribersEntity> Subscribers { get; set; }  
    public DbSet<CourseEntity> Courses { get; set; }  

}
