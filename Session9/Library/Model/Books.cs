using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Library.Model
{
    public class Books
    {
        [Key]
        public int ISBN { get; set; }
        public string Tittle { get; set; }
        public int TotalPages { get; set; }
        public DateTime PublishDate { get; set; }
        public Author Author { get; set; }
        public Genres Genre { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}