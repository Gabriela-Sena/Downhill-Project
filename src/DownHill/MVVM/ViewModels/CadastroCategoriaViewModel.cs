
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DownHill.MVVM.Messages;
using DownHill.MVVM.Models;
using System.Windows.Input;

public class CadastroCategoriaViewModel : ObservableObject
{
    private string _nomeCategoria;
    private int _idadeMinima;
    private int _idadeMaxima;
    private string _sexo;
    private string _mensagemErro;

    private readonly CategoriaRepository _categoriaRepository; // Supondo que você tenha este repositório

    // Propriedade para o nome da categoria
    public string NomeCategoria
    {
        get => _nomeCategoria;
        set => SetProperty(ref _nomeCategoria, value);
    }

    // Propriedade para a idade minima do corredor
    public int IdadeMinima
    {
        get => _idadeMinima;
        set => SetProperty(ref _idadeMinima, value);
    }

    // Propriedade para a idade maxima do corredor
    public int IdadeMaxima
    {
        get => _idadeMaxima;
        set => SetProperty(ref _idadeMaxima, value);
    }

    // Propriedade para o sexo do corredor
    public string Sexo
    {
        get => _sexo;
        set => SetProperty(ref _sexo, value);
    }

    // Propriedade para exibir mensagens de erro
    public string MensagemErro
    {
        get => _mensagemErro;
        set => SetProperty(ref _mensagemErro, value);
    }

    // Comando para adicionar a categoria
    public ICommand AdicionarCategoriaCommand { get; }

    public CadastroCategoriaViewModel(CategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
        AdicionarCategoriaCommand = new RelayCommand(AdicionarCategoria);
    }

    private void AdicionarCategoria()
    {
        try
        {
            var categoria = new Categoria { NomeCategoria = this.NomeCategoria, IdadeMinima = this.IdadeMinima, IdadeMaxima = this.IdadeMaxima, Sexo = this.Sexo };
            _categoriaRepository.Add(categoria);

            // Notificar que uma nova categoria foi adicionado
            WeakReferenceMessenger.Default.Send(new NotificationMessage("UpdateCategoryList"));

            // Limpar os campos após o cadastro
            NomeCategoria = string.Empty;
            IdadeMinima = 0;
            IdadeMaxima = 0;
            Sexo = string.Empty;
            MensagemErro = "Categoria adicionada com sucesso!";
        }
        catch (Exception ex)
        {
            // Captura e exibe o erro
            MensagemErro = $"Erro ao adicionar categoria: {ex.Message}";
        }
    }

  
    }
