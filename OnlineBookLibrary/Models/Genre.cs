using Microsoft.EntityFrameworkCore;

namespace OnlineBookLibrary.Models
{
    [PrimaryKey(nameof(Id))]
    public class Genre
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> books { get; set; }
    }
}
