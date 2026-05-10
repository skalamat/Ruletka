using Ruletka.Data;

namespace Ruletka;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private void return_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
    private void registerbutton_Clicked(object sender, EventArgs e)
    {
        var db = new RuletkaDb();

        string username = usernameEntry.Text?.Trim() ?? string.Empty;
        string password = passwordEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            passwordErrorLabel.Text = "Wszystkie pola muszą być wypełnione";
            return;
        }
        else
        {
            passwordErrorLabel.Text = "";
        }
        foreach (var u in db.Users)
        {
            if(username == u.UserName)
            {
                usernameErrorLabel.Text = "Użytwonik o takiej nazwie już istnieje";
                return;
            }
            else
            {
                usernameErrorLabel.Text = "";
            }
        }
        if(password.Length < 6)
        {
            passwordErrorLabel.Text = "Hasło musi mieć co najmniej 6 znaków";
            return;
        }
        else
        {
            passwordErrorLabel.Text = "";
        }

        var user = new User
        {
            UserName = username,
            Password = password,
            Balance = 500,
        };
        db.AddUser(user);

        Navigation.PushAsync(new MainPage());

        DisplayAlert("Sukces", "Pomyślnie utworzono konto.", "OK");

        usernameEntry.Text = string.Empty;
        passwordEntry.Text = string.Empty;
    }

    private void LoginTapped(object sender, TappedEventArgs e)
    { 
            Navigation.PushAsync(new LogInPage());
    }

    private void TogglePassword(object sender, EventArgs e)
    {
        if(passwordEntry.IsPassword)
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


    private void LoginMouseEnter(object sender, PointerEventArgs e)
    {
        loginLabel.TextColor = Color.FromArgb("#3975f3");
    }

    private void LoginMouseExit(object sender, PointerEventArgs e)
    {
        loginLabel.TextColor = Color.FromArgb("#0c49ca");
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

    private void registerMouseEnter(object sender, PointerEventArgs e)
    {
        registerButton.BackgroundColor = Color.FromArgb("#4e7ba7");
    }
    private void registerMouseExit(object sender, PointerEventArgs e)
    {
        registerButton.BackgroundColor = Color.FromArgb("#375776");
    }
}