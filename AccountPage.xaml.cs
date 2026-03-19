namespace Ruletka;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
	}

    private void return_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}