namespace DownHill.MVVM.Views
{
    public partial class UpdateCategoriaPage : ContentPage
    {

        public UpdateCategoriaPage()

        {
            InitializeComponent();

        }
        public UpdateCategoriaPage(int idCategoria) 
        { 
            var categoriaRepo = new CategoriaRepository();
            var viewModel = new UpdateCategoriaViewModel(categoriaRepo);
            
            // Carrega os detalhes da categoria com base no ID fornecido
             viewModel.LoadCategoriaById(idCategoria);
             DisplayAlert("ID da Categoria", idCategoria.ToString(), "OK");
            BindingContext = viewModel;
        }
    }
}
