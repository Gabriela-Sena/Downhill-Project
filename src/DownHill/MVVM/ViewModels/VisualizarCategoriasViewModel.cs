using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DownHill.MVVM.Messages;
using DownHill.MVVM.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class VisualizarCategoriasViewModel : ObservableObject
{
	private ObservableCollection<Categoria> _categorias;
	private readonly CategoriaRepository _categoriaRepository;
    private string _mensagemErro;

    public ObservableCollection<Categoria> Categorias
	{
		get => _categorias;
		set => SetProperty(ref _categorias, value);
	}
    public ICommand EditCommand { get; private set; }

    public string MensagemErro
    {
        get => _mensagemErro;
        set => SetProperty(ref _mensagemErro, value);
    }


    public VisualizarCategoriasViewModel(CategoriaRepository categoriaRepository)
	{
		_categoriaRepository = categoriaRepository;
		LoadCategorias();

		// Inscrever-se para a mensagem
		WeakReferenceMessenger.Default.Register<VisualizarCategoriasViewModel, NotificationMessage>(this, OnCategoriaAdded);
	}

    public class CategoriaSelecionadaMessage : NotificationMessage
    {
        public Categoria CategoriaSelecionada { get; }

        public CategoriaSelecionadaMessage(Categoria categoriaSelecionada)
            : base("CategoriaSelecionada")
        {
            CategoriaSelecionada = categoriaSelecionada;
        }
    }

    private void EditarCategoria(Categoria categoria)
    {
        if (categoria != null)
        {
            // Enviar uma mensagem indicando que a categoria foi selecionada para edição
            WeakReferenceMessenger.Default.Send(new CategoriaSelecionadaMessage(categoria));
        }
        else
        {
            MensagemErro = "Nenhuma categoria selecionada para edição.";
        }
    }

    private void LoadCategorias()
	{
		var categoriasList = _categoriaRepository.GetAll();
		Categorias = new ObservableCollection<Categoria>(categoriasList);
	}

	// Método chamado quando a mensagem é recebida
	private void OnCategoriaAdded(VisualizarCategoriasViewModel sender, NotificationMessage message)
	{
		LoadCategorias();
	}

    // Chame este método quando o ViewModel não for mais necessário
    public void UnsubscribeFromMessages()
    {
        WeakReferenceMessenger.Default.Unregister<NotificationMessage>(this);
    }
}
