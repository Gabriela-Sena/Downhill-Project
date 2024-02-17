using DownHill.MVVM.Models;
using SQLite;

namespace DownHill.Services
{
    public class DatabaseService
    {
        private static SQLiteConnection _database;

        public DatabaseService()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (_database == null)
            {
                string dbName = "mydatabase.db3";
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
                _database = new SQLiteConnection(dbPath);

                // Aqui você pode criar suas tabelas, se elas ainda não existirem
                _database.CreateTable<Corredor>();
                _database.CreateTable<Corrida>();
                _database.CreateTable<Categoria>();

                // Adicione outras tabelas conforme necessário
            }
        }

        public SQLiteConnection GetConnection()
        {
            return _database;
        }
    }
}
