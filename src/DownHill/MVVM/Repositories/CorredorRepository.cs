using DownHill.MVVM.Models;
using DownHill.Services;
using SQLite;

public class CorredorRepository
{
    private readonly SQLiteConnection _database;

    public CorredorRepository()
    {
        var dbService = new DatabaseService();
        _database = dbService.GetConnection();
    }

    // Adiciona um novo corredor ao banco de dados
    public int Add(Corredor corredor)
    {
        return _database.Insert(corredor);
    }

    // Atualiza um corredor existente
    public int Update(Corredor corredor)
    {
        return _database.Update(corredor);
    }

    // Deleta um corredor
    public int Delete(Corredor corredor)
    {
        return _database.Delete(corredor);
    }

    // Obtém um corredor pelo ID
    public Corredor GetById(int id)
    {
        return _database.Table<Corredor>().FirstOrDefault(c => c.ID == id);
    }

    // Obtém todos os corredores
    public IEnumerable<Corredor> GetAll()
    {
        return _database.Table<Corredor>().ToList();
    }
}
