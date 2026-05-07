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
        Navigation.PopAsync();
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

    private void registerbutton_Clicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

        var user = new User
        {
            UserName = username,
            Email = email,
            Password = password,
            Balance = 500m,
        };
        var db = new RuletkaDb();
        db.AddUser(user);

        usernameEntry.Text = string.Empty;
        emailEntry.Text = string.Empty;
        passwordEntry.Text = string.Empty;
    }
}