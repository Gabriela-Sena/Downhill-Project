using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DownHill.MVVM.Messages;
using DownHill.MVVM.Models;
using System.Collections.ObjectModel;

public class VisualizarCorredoresViewModel : ObservableObject
{
    private ObservableCollection<Corredor> _corredores;
    private readonly CorredorRepository _corredorRepository;

    public ObservableCollection<Corredor> Corredores
    {
        get => _corredores;
        set => SetProperty(ref _corredores, value);
    }

    public VisualizarCorredoresViewModel(CorredorRepository corredorRepository)
    {
        _corredorRepository = corredorRepository;
        LoadCorredores();

        // Inscrever-se para a mensagem
        WeakReferenceMessenger.Default.Register<VisualizarCorredoresViewModel, NotificationMessage>(this, OnCorredorAdded);
    }

    private void LoadCorredores()
    {
        var corredoresList = _corredorRepository.GetAll();
        Corredores = new ObservableCollection<Corredor>(corredoresList);
    }

    // Método chamado quando a mensagem é recebida
    private void OnCorredorAdded(VisualizarCorredoresViewModel sender, NotificationMessage message)
    {
        LoadCorredores();
    }

    // Chame este método quando o ViewModel não for mais necessário
    public void UnsubscribeFromMessages()
    {
        WeakReferenceMessenger.Default.Unregister<NotificationMessage>(this);
    }
}
