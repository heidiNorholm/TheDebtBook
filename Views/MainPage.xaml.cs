using DebtBook.ViewModels;
using TheDebtBook.View;

namespace TheDebtBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel vm = new MainPageViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm; 
        }

        private async void OnAddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDebterPage());
        }
    }
}
