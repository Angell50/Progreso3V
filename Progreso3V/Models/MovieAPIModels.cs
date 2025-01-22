using SQLite;

namespace Progreso3V.Models
{
    public class MovieAPIModels
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string title { get; set; } 
        public List<string> genre { get; set; }
        public List<string> actors { get; set; }
        public string awards { get; set; } 
        public string website { get; set; }
        public string AngelV { get; set; } 
    }
}
