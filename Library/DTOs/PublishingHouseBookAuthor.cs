namespace Library.DTOs
{
    public class PublishingHouseBookAuthor
    {
        public string Name { get; set; }
        public List<BookItemDTO> Books { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
