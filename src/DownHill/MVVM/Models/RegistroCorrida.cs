using SQLite;

namespace DownHill.MVVM.Models
{
    public class RegistroCorrida
    {
        [PrimaryKey, AutoIncrement]
        public int RegistroID { get; set; }

        [Indexed]
        public int CorredorID { get; set; }

        [Indexed]
        public int CorridaID { get; set; }

        public DateTime HoraDaLargada { get; set; }
    }
}
