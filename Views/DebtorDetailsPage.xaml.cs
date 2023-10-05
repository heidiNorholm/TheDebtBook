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
        await mainPageViewModel.TotalAmountForAllDebtors(); //Bliver allerede kaldt i LoadDebtorAsync()
        //await mainPageViewModel.LoadDebtorAsync();
        //OnPropertyChanged();
        await Navigation.PopAsync();
    }

    private async void OnAddValueButton_Clicked(object sender, EventArgs e)
    {
        await mainPageViewModel.TotalAmount(Id);
        await mainPageViewModel.TotalAmountForAllDebtors();
        OnPropertyChanged();
        //await Task.Delay(100);
        await Navigation.PopAsync();
    }
}