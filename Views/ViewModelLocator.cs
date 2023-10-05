// class setup up to provide an instance of MainPageViewModel to the view

using DebtBook.ViewModels;

namespace TheDebtBook.View
{
    public class ViewModelLocator
    {
        // This property exposes the MainPageViewModel
        private static MainPageViewModel _mainPageViewModel;
        public static MainPageViewModel MainPageViewModel
        {
            get
            {
                return _mainPageViewModel;
            }
        }
    }
}