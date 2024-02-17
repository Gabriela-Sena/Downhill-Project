using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DownHill.MVVM.Messages;
using DownHill.MVVM.Models;
using System.Collections.ObjectModel;

public class VisualizarCorridasViewModel : ObservableObject
{
    private ObservableCollection<Corrida> _corridas;
    private readonly CorridaRepository _corridaRepository;

    public ObservableCollection<Corrida> Corridas
    {
        get => _corridas;
        set => SetProperty(ref _corridas, value);
    }

    public VisualizarCorridasViewModel(CorridaRepository corridaRepository)
    {
        _corridaRepository = corridaRepository;
        LoadCorridas();

        WeakReferenceMessenger.Default.Register<VisualizarCorridasViewModel, NotificationMessage>(this, OnCorridaAdded);
    }

    private void LoadCorridas()
    {
        var corridasList = _corridaRepository.GetAll();
        Corridas = new ObservableCollection<Corrida>(corridasList);
    }

    private void OnCorridaAdded(VisualizarCorridasViewModel sender, NotificationMessage message)
    {
        LoadCorridas();
    }

    public void UnsubscribeFromMessages()
    {
        WeakReferenceMessenger.Default.Unregister<NotificationMessage>(this);
    }
}
