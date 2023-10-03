using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBook.ViewModels;

namespace TheDebtBook.View;

public partial class DebtorDetailsPage : ContentPage
{
    public string PageTitle { get; set; }
    private MainPageViewModel mainPageViewModel;
    public DebtorDetailsPage(MainPageViewModel mainPageViewModel, Debtor selectedDebtor)
    {
        InitializeComponent();
        this.mainPageViewModel = mainPageViewModel;
        PageTitle = selectedDebtor.Name;
        BindingContext=new DebtorDetailsViewModel(mainPageViewModel,selectedDebtor);
        //BindingContext=selectedDebtor;
    }

    private async void OnCloseButton_Clicked(object sender, EventArgs e)
    {
        // SKal sørge for at mainPage bliver opdateret

        await Navigation.PopAsync();
    }

    private async void OnAddValueButton_Clicked(object sender, EventArgs e)
    {
        // Tilføj værdi

        OnPropertyChanged();
        await Navigation.PopAsync();
        //throw new NotImplementedException();
    }
}