using SQLite;

namespace Progreso3V.Models
{
    public class MovieAPIModels
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string title { get; set; } // Título de la película

        public string genre { get; set; } // Género (1er registro)

        public string actors { get; set; } // Actor principal (1er registro)

        public string awards { get; set; } // Premios

        public string website { get; set; } // Website

        public string AngelV { get; set; } // Tu nombre (campo adicional)
    }
}
