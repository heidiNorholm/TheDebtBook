using DebtBook.ViewModels;

namespace TheDebtBook.View;

public partial class AddDebterPage : ContentPage
{
    private MainPageViewModel mainPageViewModel;
	public AddDebterPage(MainPageViewModel mainPageViewModel)
	{
        this.mainPageViewModel = mainPageViewModel;
        InitializeComponent();
        BindingContext = new AddDebtorViewModel(mainPageViewModel);

    }

    private async void OnCancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnSaveButton_Clicked(object sender, EventArgs e)
    {
        // Noget med at opdatere data i listen

        // Skal måske ikke være her - er en test
        await mainPageViewModel.LoadDebtorAsync();
        //OnPropertyChanged();
        await Navigation.PopAsync();
    }
}