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


    private void EditarCategoria(Categoria categoriaEditada)
    {
        if (categoriaEditada != null)
        {
            try
            {
                // Atualiza os dados da categoria com os novos valores
                var categoria = new Categoria
                {
                    NomeCategoria = categoriaEditada.NomeCategoria,
                    IdadeMinima = categoriaEditada.IdadeMinima,
                    IdadeMaxima = categoriaEditada.IdadeMaxima,
                    Sexo = categoriaEditada.Sexo
                };

                // Chama o método de atualização do repositório
                _categoriaRepository.Update(categoria);

                // Notifica que a categoria foi atualizada
                WeakReferenceMessenger.Default.Send(new NotificationMessage("UpdateCategoryList"));

              
                MensagemErro = "Categoria editada com sucesso!";
            }
            catch (Exception ex)
            {
                // exibe o erro
                MensagemErro = $"Erro ao editar categoria: {ex.Message}";
            }
        }
    }

    // Chame este método quando o ViewModel não for mais necessário
    public void UnsubscribeFromMessages()
    {
        WeakReferenceMessenger.Default.Unregister<NotificationMessage>(this);
    }
}
