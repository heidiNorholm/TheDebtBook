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

    // prøve:
    public int Id { get; set; }


    public DebtorDetailsPage(MainPageViewModel mainPageViewModel, DebtorDTO selectedDebtor)
    {
        InitializeComponent();
        this.mainPageViewModel = mainPageViewModel;
        BindingContext=new DebtorDetailsViewModel(mainPageViewModel,selectedDebtor);
    }

    private async void OnCloseButton_Clicked(object sender, EventArgs e)
    {
        // SKal sørge for at mainPage bliver opdateret
        await mainPageViewModel.TotalAmountForAllDebtors();
        await mainPageViewModel.LoadDebtorAsync();
        //OnPropertyChanged();
        await Navigation.PopAsync();
    }

    private async void OnAddValueButton_Clicked(object sender, EventArgs e)
    {
        await mainPageViewModel.TotalAmount(Id);
        OnPropertyChanged();
        await Navigation.PopAsync();
    }
}