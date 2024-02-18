using SQLite;

namespace DownHill.MVVM.Models
{
    public class Categoria
    {
        [PrimaryKey, AutoIncrement]
        public int NumCategoria { get; set; }

        [MaxLength(50)]
        public string NomeCategoria { get; set; }

        public int IdadeMinima { get; set; }

        public int IdadeMaxima { get; set; }

        [MaxLength(1)]
        public string Sexo { get; set; }
    }
}