namespace DownHill.MVVM.Views{

    public partial class CadastroCategoriaPage : ContentPage
    {
        public CadastroCategoriaPage()
        {
            InitializeComponent();

            var categoriaRepo = new CategoriaRepository();
            var viewModel = new CadastroCategoriaViewModel(categoriaRepo);
            BindingContext = viewModel;
        }
    }
}