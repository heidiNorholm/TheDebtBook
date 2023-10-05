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

    // prøve:
    public int Id { get; set; }


    public DebtorDetailsPage(MainPageViewModel mainPageViewModel, Debtor selectedDebtor)
    {
        InitializeComponent();
        this.mainPageViewModel = mainPageViewModel;
        PageTitle = selectedDebtor.Name;
        Id = selectedDebtor.Id;
        BindingContext=new DebtorDetailsViewModel(mainPageViewModel,selectedDebtor);
        //_=mainPageViewModel.LoadDebtorTransactions(selectedDebtor.Id);
        //BindingContext=selectedDebtor;
    }

    private async void OnCloseButton_Clicked(object sender, EventArgs e)
    {
        // SKal sørge for at mainPage bliver opdateret

        await Navigation.PopAsync();
    }

    private async void OnAddValueButton_Clicked(object sender, EventArgs e)
    {
        //mainPageViewModel.LoadDebtorTransactions()


        // Prøve
        await mainPageViewModel.TotalAmount(Id);
        //

        OnPropertyChanged();

        await Navigation.PopAsync();
        //throw new NotImplementedException();
    }
}