namespace TheDebtBook.View;

public partial class AddDebterPage : ContentPage
{
	public AddDebterPage()
	{
		InitializeComponent();
	}

    private async void OnCancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnSaveButton_Clicked(object sender, EventArgs e)
    {
        // Noget med at opdatere data i listen


        await Navigation.PopAsync();
    }
}