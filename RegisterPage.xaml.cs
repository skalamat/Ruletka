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
        string email = emailEntry.Text?.Trim() ?? string.Empty;
        string password = passwordEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            error.Text = "Wszystkie pola muszą być wypełnione";
            return;
        }
        foreach (var u in db.Users)
        {
            if(username == u.UserName)
            {
                error.Text = "Użytwonik o takiej nazwie już istnieje";
                return;
            }
        }
        if(password.Length < 6)
        {
            error.Text = "Hasło musi mieć co najmniej 6 znaków";
            return;
        }

        var user = new User
        {
            UserName = username,
            Email = email,
            Password = password,
            Balance = 500,
        };
        db.AddUser(user);

        usernameEntry.Text = string.Empty;
        emailEntry.Text = string.Empty;
        passwordEntry.Text = string.Empty;
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