using DebtBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Models
{
    public class DebtorDTO:BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private double amountOwed;

        public double AmountOwed
        {
            get
            {
                return amountOwed;
            }
            set
            {
                amountOwed = value;
                RaisePropertyChanged(nameof(AmountOwed));
            }
        }

    }
}
