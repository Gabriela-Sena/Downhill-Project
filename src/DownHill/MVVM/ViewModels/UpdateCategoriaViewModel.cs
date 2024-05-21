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
    public ICommand LoadCategoriaByIdCommand { get; }

    public UpdateCategoriaViewModel(CategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
        UpdateCategoriaCommand = new RelayCommand(UpdateCategoria);
        LoadCategoriaByIdCommand = new RelayCommand<int>(LoadCategoriaById);
    }

    private void UpdateCategoria()
    {
        try
        {
            if (CategoriaSelecionada != null)
            {
                _categoriaRepository.Update(CategoriaSelecionada);
                Console.WriteLine(CategoriaSelecionada.ToString());

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
    public void LoadCategoriaById(int id)
    {
        try
        {
            CategoriaSelecionada = _categoriaRepository.GetById(id);
            if (CategoriaSelecionada == null)
            {
                MensagemErro = "Nenhuma categoria encontrada com o ID especificado.";
            }
            else
            {
                MensagemErro = null; 
            }
        }
        catch (Exception ex)
        {
            MensagemErro = $"Erro ao carregar categoria: {ex.Message}";
        }
    }
}