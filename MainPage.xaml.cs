using TheDebtBook.View;

namespace TheDebtBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDebterPage());
        }
    }
}
