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
}