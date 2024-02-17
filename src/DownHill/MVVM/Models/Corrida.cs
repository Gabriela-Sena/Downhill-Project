using SQLite;

namespace DownHill.MVVM.Models
{
    public class Corrida
    {
        [PrimaryKey, AutoIncrement]
        public int NumeroDaProva { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        public DateTime DataDaProva { get; set; }

        public DateTime? HoraDaLargada { get; set; }
    }
}
