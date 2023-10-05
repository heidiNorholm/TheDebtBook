using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBook.ViewModels;
using TheDebtBook.Models;

namespace TheDebtBook.View;

public partial class DebtorDetailsPage : ContentPage
{
    private MainPageViewModel mainPageViewModel;
    public int Id { get; set; }

    public DebtorDetailsPage(MainPageViewModel mainPageViewModel, DebtorDTO selectedDebtor)
    {
        InitializeComponent();
        this.mainPageViewModel = mainPageViewModel;
        BindingContext=new DebtorDetailsViewModel(mainPageViewModel,selectedDebtor);
    }

    // Metoden sørger for at mainPage bliver opdateret
    private async void OnCloseButton_Clicked(object sender, EventArgs e)
    {
        await mainPageViewModel.TotalAmountForAllDebtors();
        await Navigation.PopAsync();
    }

    // Tilføjer en værdi til den valgte debtor
    private async void OnAddValueButton_Clicked(object sender, EventArgs e)
    {
        await mainPageViewModel.TotalAmount(Id);
        await mainPageViewModel.TotalAmountForAllDebtors();
        OnPropertyChanged();
        await Navigation.PopAsync();
    }
}