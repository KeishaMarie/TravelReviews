using Microsoft.EntityFrameworkCore;

namespace Travel.Models{
  public class TravelContext : DbContext
  {
    public TravelContext(DbContextOptions<TravelContext> options)
      : base(options)
      {
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<TravelReview>()
        .HasData(
          new TravelReview { TravelReviewId = 1, ReviewTitle = "It's too hot here", Rating = 1, Location = "Mordor, New Zealand", Reviewer = "Trevor", ReviewBody ="Mordor is super hot. I wish someone would have warned me before I went on this quest to destroy some random ring." },
          new TravelReview { TravelReviewId = 2, ReviewTitle = "Beautiful", Rating = 3 , Location = "The Lonely Mountain", Reviewer = "KB", ReviewBody ="there was a dragon" },
          new TravelReview { TravelReviewId = 3, ReviewTitle = "too many orcs", Rating = 0 , Location = "The Shire", Reviewer = "KB", ReviewBody ="I didn't realize that the Shire was burning" }
        );
      }

      public DbSet<TravelReview> TravelReviews { get; set; }
  }
}