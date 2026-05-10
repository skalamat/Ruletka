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
        Navigation.PushAsync(new MainPage());
    }
    private void logInButton_Clicked(object sender, EventArgs e)
    {
        var db = new RuletkaDb();

        string username = usernameEntry.Text?.Trim() ?? string.Empty;
        string password = passwordEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            errorLabel.Text = "Wszystkie pola muszą być wypełnione";
            return;
        }
 
            User logedIn = db.LoginUser(username, password);
            if (logedIn != null)
            {
                App.CurrentUser = logedIn;
                Navigation.PushAsync(new MainPage());
                DisplayAlert("Sukces", "Pomyślnie zalogowano.", "OK");
            }
        else
            {
                errorLabel.Text = "Błędna nazwa użytownika lub hasło!";
            }
    }

    private void RegisterTapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new RegisterPage());
    }

    private void TogglePassword(object sender, EventArgs e)
    {
        if (passwordEntry.IsPassword)
        {
            passwordEntry.IsPassword = false;
            passwordToggleLabel.Text = "🔓";
        }
        else
        {
            passwordEntry.IsPassword = true;
            passwordToggleLabel.Text = "🔒";

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

    private void RegisterMouseEnter(object sender, PointerEventArgs e)
    {
        registerLabel.TextColor = Color.FromArgb("#3975f3");
    }

    private void RegisterMouseExit(object sender, PointerEventArgs e)
    {
        registerLabel.TextColor = Color.FromArgb("#0c49ca");
    }


    private void userNameMouseEnter(object sender, PointerEventArgs e)
    {
        usernameEntry.BackgroundColor = Color.FromArgb("#39597a");
    }
    private void userNameMouseExit(object sender, PointerEventArgs e)
    {
        usernameEntry.BackgroundColor = Color.FromArgb("#1E2F40");
    }


    private void passwordMouseEnter(object sender, PointerEventArgs e)
    {
        passwordEntry.BackgroundColor = Color.FromArgb("#39597a");
    }
    private void passwordMouseExit(object sender, PointerEventArgs e)
    {
        passwordEntry.BackgroundColor = Color.FromArgb("#1E2F40");
    }

    private void loginMouseEnter(object sender, PointerEventArgs e)
    {
        loginButton.BackgroundColor = Color.FromArgb("#4e7ba7");
    }
    private void loginMouseExit(object sender, PointerEventArgs e)
    {
        loginButton.BackgroundColor = Color.FromArgb("#375776");
    }
}