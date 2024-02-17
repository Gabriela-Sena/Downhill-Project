using DownHill.MVVM.Models;
using DownHill.Services;
using SQLite;

public class CategoriaRepository
{
    private readonly SQLiteConnection _database;

    public CategoriaRepository()
    {
        var dbService = new DatabaseService();
        _database = dbService.GetConnection();
    }

    public int Add(Categoria categoria)
    {
        return _database.Insert(categoria);
    }

    public int Update(Categoria categoria)
    {
        return _database.Update(categoria);
    }

    public int Delete(Categoria categoria)
    {
        return _database.Delete(categoria);
    }

    public Corrida GetById(int numCategoria)
    {
        return _database.Table<Categoria>().FirstOrDefault(c => c.NumCategoria == numCategoria);
    }

    public IEnumerable<Categoria> GetAll()
    {
        return _database.Table<Categoria>().ToList();
    }
}