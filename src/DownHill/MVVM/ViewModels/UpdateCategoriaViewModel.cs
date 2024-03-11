using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DownHill.MVVM.Messages;
using DownHill.MVVM.Models;
using System;
using System.Windows.Input;

public class UpdateCategoriaViewModel : ObservableObject
{
    private Categoria _categoriaSelecionada;
    private readonly CategoriaRepository _categoriaRepository;

    public Categoria CategoriaSelecionada
    {
        get => _categoriaSelecionada;
        set => SetProperty(ref _categoriaSelecionada, value);
    }

    public string MensagemErro { get; private set; }

    public ICommand UpdateCategoriaCommand { get; }

    public UpdateCategoriaViewModel(CategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
        UpdateCategoriaCommand = new RelayCommand(UpdateCategoria);
    }

    private void UpdateCategoria()
    {
        try
        {
            if (CategoriaSelecionada != null)
            {
                _categoriaRepository.Update(CategoriaSelecionada);

                // Notifica que a categoria foi atualizada
                WeakReferenceMessenger.Default.Send(new NotificationMessage("UpdateCategoryList"));

                MensagemErro = "Categoria editada com sucesso!";
            }
            else
            {
                MensagemErro = "Nenhuma categoria selecionada para edição.";
            }
        }
        catch (Exception ex)
        {
            MensagemErro = $"Erro ao editar categoria: {ex.Message}";
        }
    }
}