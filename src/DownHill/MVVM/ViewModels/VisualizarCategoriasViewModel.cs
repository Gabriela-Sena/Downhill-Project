using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DownHill.MVVM.Messages;
using DownHill.MVVM.Models;
using System.Collections.ObjectModel;

public class VisualizarCategoriasViewModel : ObservableObject
{
	private ObservableCollection<Categoria> _categorias;
	private readonly CategoriaRepository _categoriaRepository;

	public ObservableCollection<Categoria> Categorias
	{
		get => _categorias;
		set => SetProperty(ref _categorias, value);
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

	// Chame este método quando o ViewModel não for mais necessário
	public void UnsubscribeFromMessages()
	{
		WeakReferenceMessenger.Default.Unregister<NotificationMessage>(this);
	}
}
