using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TravelReviews",
                columns: new[] { "TravelReviewId", "Location", "Rating", "ReviewBody", "ReviewTitle", "Reviewer" },
                values: new object[] { 1, "Mordor, New Zealand", 1, "Mordor is super hot. I wish someone would have warned me before I went on this quest to destroy some random ring.", "It's too hot here", "Trevor" });

            migrationBuilder.InsertData(
                table: "TravelReviews",
                columns: new[] { "TravelReviewId", "Location", "Rating", "ReviewBody", "ReviewTitle", "Reviewer" },
                values: new object[] { 2, "The Lonely Mountain", 3, "there was a dragon", "Beautiful", "KB" });

            migrationBuilder.InsertData(
                table: "TravelReviews",
                columns: new[] { "TravelReviewId", "Location", "Rating", "ReviewBody", "ReviewTitle", "Reviewer" },
                values: new object[] { 3, "The Shire", 0, "I didn't realize that the Shire was burning", "too many orcs", "KB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TravelReviews",
                keyColumn: "TravelReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TravelReviews",
                keyColumn: "TravelReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TravelReviews",
                keyColumn: "TravelReviewId",
                keyValue: 3);
        }
    }
}
