using DebtBook.ViewModels;
using TheDebtBook.Models;
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

        private async void OnDebtorItemTapped(object sender, TappedEventArgs e)
        {
            if (sender is Label label && label.BindingContext is DebtorDTO selectedDebtor)
            {
                await Navigation.PushAsync(new DebtorDetailsPage(vm,selectedDebtor));
            }
        }
    }
}
