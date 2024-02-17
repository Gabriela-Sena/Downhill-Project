namespace DownHill.MVVM.Views
{
    public partial class CadastroCorridaPage : ContentPage
    {
        public CadastroCorridaPage()
        {
            InitializeComponent();

            var corridaRepo = new CorridaRepository();
            var viewModel = new CadastroCorridaViewModel(corridaRepo);
            BindingContext = viewModel;
        }
    }
}
