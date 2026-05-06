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

    }

    private void logInButton_Clicked(object sender, EventArgs e)
    {

    }
}