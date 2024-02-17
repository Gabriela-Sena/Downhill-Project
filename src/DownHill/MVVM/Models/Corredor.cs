using SQLite;

namespace DownHill.MVVM.Models
{
    public class Corredor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        public int Numero { get; set; }

        [MaxLength(14)]
        public string Cpf { get; set; }
    }
}
