namespace DownHill.MVVM.Views
{
    public partial class VisualizarCorredoresPage : ContentPage
    {
        public VisualizarCorredoresPage()
        {
            InitializeComponent();

            var corredorRepo = new CorredorRepository();
            var viewModel = new VisualizarCorredoresViewModel(corredorRepo);
            BindingContext = viewModel;
        }
    }
}
