using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Library.Model
{
    public class Genres
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}