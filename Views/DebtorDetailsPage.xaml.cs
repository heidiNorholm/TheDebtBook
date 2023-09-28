using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.View;

public partial class DebtorDetailsPage : ContentPage
{
    public string PageTitle { get; set; }
    public DebtorDetailsPage(Debtor selectedDebtor)
    {
        InitializeComponent();
        PageTitle = selectedDebtor.Name;
        BindingContext=selectedDebtor;
    }

    private void OnCloseButton_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnAddValueButton_Clicked(object sender, EventArgs e)
    {
        // Til
        throw new NotImplementedException();
    }
}