namespace DownHill.MVVM.Views
{

    public partial class UpdateCategoriaPage : ContentPage
    {
        public UpdateCategoriaPage()
        {
            InitializeComponent();

            var categoriaRepo = new CategoriaRepository();
            var viewModel = new UpdateCategoriaViewModel(categoriaRepo);
            BindingContext = viewModel;
        }
    }
}
