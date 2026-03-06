namespace KonyvkolcsonzoRendszer.Services.Dtok
{
    public class NewBookDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public int? UserId { get; set; }
    }
}
