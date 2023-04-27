using Application.Data;
using Domain.Entities;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}