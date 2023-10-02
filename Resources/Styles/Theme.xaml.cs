namespace TheDebtBook;

public partial class Theme : ResourceDictionary
{
	public Theme()
	{
        global::Microsoft.Maui.Controls.Xaml.Extensions.LoadFromXaml(this, typeof(Theme));
	}
}
