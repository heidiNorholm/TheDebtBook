using DebtBook.ViewModels;
using TheDebtBook.View;

namespace TheDebtBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
            BindingContext = vm; 
        }

        private async void OnAddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDebterPage(vm));
        }
    }
}
