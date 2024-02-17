namespace DownHill.MVVM.Views { 

	public partial class CadastroCorredorPage : ContentPage
	{
        public CadastroCorredorPage()
        {
            InitializeComponent();

            var corredorRepo = new CorredorRepository();
            var viewModel = new CadastroCorredorViewModel(corredorRepo);
            BindingContext = viewModel;
        }
    }
}