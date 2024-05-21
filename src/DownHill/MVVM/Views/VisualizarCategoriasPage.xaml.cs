using DownHill.MVVM.Models;

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
            var button = sender as Button;
            var categoria = button?.BindingContext as Categoria;
            if (categoria != null)
            {
                await Shell.Current.GoToAsync("///UpdateCategoriaPage?NumCategoria={categoria.NumCategoria}");
            }
        }

    }
}