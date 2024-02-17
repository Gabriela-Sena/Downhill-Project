using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DownHill.MVVM.Messages;
using DownHill.MVVM.Models;
using System.Windows.Input;

public class CadastroCorredorViewModel : ObservableObject
{
    private string _nome;
    private int _numero;
    private int _cpf;
    private string _mensagemErro;

    private readonly CorredorRepository _corredorRepository; // Supondo que você tenha este repositório

    // Propriedade para o nome do corredor
    public string Nome
    {
        get => _nome;
        set => SetProperty(ref _nome, value);
    }

    // Propriedade para o número do corredor
    public int Numero
    {
        get => _numero;
        set => SetProperty(ref _numero, value);
    }

    // Propriedade para o cpf do corredor
    public string Cpf
    {
        get => _cpf;
        set => SetProperty(ref _cpf, value);
    }

    // Propriedade para exibir mensagens de erro
    public string MensagemErro
    {
        get => _mensagemErro;
        set => SetProperty(ref _mensagemErro, value);
    }

    // Comando para adicionar o corredor
    public ICommand AdicionarCorredorCommand { get; }

    public CadastroCorredorViewModel(CorredorRepository corredorRepository)
    {
        _corredorRepository = corredorRepository;
        AdicionarCorredorCommand = new RelayCommand(AdicionarCorredor);
    }

    private void AdicionarCorredor()
    {
        try
        {
            var corredor = new Corredor { Nome = this.Nome, Numero = this.Numero, Cpf = this.Cpf };
            _corredorRepository.Add(corredor);

            // Notificar que um novo corredor foi adicionado
            WeakReferenceMessenger.Default.Send(new NotificationMessage("UpdateCorredoresList"));

            // Limpar os campos após o cadastro
            Nome = string.Empty;
            Numero = 0;
            Cpf = string.Empty;
            MensagemErro = "Corredor adicionado com sucesso!";
        }
        catch (Exception ex)
        {
            // Captura e exibe o erro
            MensagemErro = $"Erro ao adicionar corredor: {ex.Message}";
        }
    }
}
