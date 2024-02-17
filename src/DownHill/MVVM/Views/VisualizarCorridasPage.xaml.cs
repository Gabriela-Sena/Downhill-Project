namespace DownHill.MVVM.Views
{
    public partial class VisualizarCorridasPage : ContentPage
    {
        public VisualizarCorridasPage()
        {
            InitializeComponent();

            var corridaRepo = new CorridaRepository();
            var viewModel = new VisualizarCorridasViewModel(corridaRepo);
            BindingContext = viewModel;
        }
    }
}
