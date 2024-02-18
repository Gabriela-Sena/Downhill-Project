namespace DownHill
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToCadastroCorredoresButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CadastroCorredorPage");
        }

        private async void OnViewCorredoresButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//VisualizarCorredoresPage");
        }

        private async void OnNavigateToCadastroCorridaButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CadastroCorridaPage");
        }

        private async void OnNavigateToVisualizarCorridasButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//VisualizarCorridasPage");
        }

        private async void OnNavigateToVisualizarCategoriaButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//VisualizarCategoriasPage");
        }

        private async void OnNavigateToCadastroCategoriaButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CadastroCategoriaPage");
        }
    }
}