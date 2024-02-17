using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DownHill.MVVM.Messages;
using DownHill.MVVM.Models;
using System.Windows.Input;

public class CadastroCorridaViewModel : ObservableObject
{
    private string _nome;
    private DateTime _dataDaProva;
    private DateTime? _horaDaLargada;
    private string _mensagemErro;

    private readonly CorridaRepository _corridaRepository;

    public string Nome
    {
        get => _nome;
        set => SetProperty(ref _nome, value);
    }

    public DateTime DataDaProva
    {
        get => _dataDaProva;
        set => SetProperty(ref _dataDaProva, value);
    }

    public DateTime? HoraDaLargada
    {
        get => _horaDaLargada;
        set => SetProperty(ref _horaDaLargada, value);
    }

    public string MensagemErro
    {
        get => _mensagemErro;
        set => SetProperty(ref _mensagemErro, value);
    }

    public ICommand AdicionarCorridaCommand { get; }

    public CadastroCorridaViewModel(CorridaRepository corridaRepository)
    {
        _corridaRepository = corridaRepository;
        AdicionarCorridaCommand = new RelayCommand(AdicionarCorrida);
       
        DataDaProva = DateTime.Now;
        HoraDaLargada = DateTime.Now;
    }

    private void AdicionarCorrida()
    {
        try
        {
            var corrida = new Corrida
            {
                Nome = this.Nome,
                DataDaProva = this.DataDaProva,
                HoraDaLargada = this.HoraDaLargada
            };
            _corridaRepository.Add(corrida);

            // Notificar que uma nova corrida foi adicionada
            WeakReferenceMessenger.Default.Send(new NotificationMessage("UpdateCorridasList"));

            // Limpar os campos após o cadastro
            Nome = string.Empty;
            DataDaProva = DateTime.Now;
            HoraDaLargada = null;
            MensagemErro = "Corrida adicionada com sucesso!";
        }
        catch (Exception ex)
        {
            MensagemErro = $"Erro ao adicionar corrida: {ex.Message}";
        }
    }
}
