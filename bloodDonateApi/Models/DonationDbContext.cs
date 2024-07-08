using Microsoft.EntityFrameworkCore;

namespace BloodDonateApi.Models;
public class DonationDbContext : DbContext
{
    public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
    {
    }
    public DbSet<BDcandidate> BDCandidates { get; set; }

}