using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}