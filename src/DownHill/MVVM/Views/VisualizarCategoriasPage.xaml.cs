namespace DownHill.MVVM.Views
{
    public partial class VisualizarCategoriasPage : ContentPage
    {
        public VisualizarCategoriasPage()
        {
            InitializeComponent();

            var categoriaRepo = new CategoriaRepository();
            var viewModel = new VisualizarCategoriasViewModel(categoriaRepo);
            BindingContext = viewModel;
        }
        private async void OnNavigateToUpdateCategoriaButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//UpdateCategoriaPage");
        }
    }
}