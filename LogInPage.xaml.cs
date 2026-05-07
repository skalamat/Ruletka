namespace Ruletka;
using Ruletka.Data;

public partial class LogInPage : ContentPage
{
	public LogInPage()
	{
		InitializeComponent();
	}
    private void return_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void logInButton_Clicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        using (var db = new RuletkaDb())
        {
            User logedIn = db.LoginUser(username, password);
            if (logedIn != null)
            {
                App.CurrentUser = logedIn;
                Navigation.PopAsync();
            }
            else
            {
                error.Text = "Błędna nazwa użytownika lub hasło!";
            }
        }
    }
    //HOOVER
    private void ReturnHoverEntered(object? sender, PointerEventArgs e)
    {
        ReturnButton.Background = new SolidColorBrush(Color.FromArgb("#a0a0a0"));

    }
    private void ReturnHoverExited(object? sender, PointerEventArgs e)
    {
        ReturnButton.Background = new SolidColorBrush(Colors.SlateGray);
    }
}