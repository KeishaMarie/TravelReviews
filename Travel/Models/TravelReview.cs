using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class TravelReview
  {
    public int TravelReviewId { get; set; }
    public string ReviewTitle { get; set; }
    public int Rating { get; set; }
    public string Location { get; set; }
    public string Reviewer { get; set; }
    public string ReviewBody { get; set; }
  }
}