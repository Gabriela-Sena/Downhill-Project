using DownHill.MVVM.Models;
using DownHill.Services;
using SQLite;

public class CorridaRepository
{
    private readonly SQLiteConnection _database;

    public CorridaRepository()
    {
        var dbService = new DatabaseService();
        _database = dbService.GetConnection();
    }

    public int Add(Corrida corrida)
    {
        return _database.Insert(corrida);
    }

    public int Update(Corrida corrida)
    {
        return _database.Update(corrida);
    }

    public int Delete(Corrida corrida)
    {
        return _database.Delete(corrida);
    }

    public Corrida GetById(int numeroDaProva)
    {
        return _database.Table<Corrida>().FirstOrDefault(c => c.NumeroDaProva == numeroDaProva);
    }

    public IEnumerable<Corrida> GetAll()
    {
        return _database.Table<Corrida>().ToList();
    }
}
