namespace Ruletka
{
    public partial class MainPage : ContentPage
    {
        private readonly RouletteWheelDrawable _drawable = new();
        private float _currentAngle = 0f;
        private bool _isSpinning = false;

        public MainPage()
        {
            InitializeComponent();
            WheelView.Drawable = _drawable;
        }

        #region koło ruletki

        // Wywołaj tę metodę ze swojej logiki, podając kąt końcowy obrotu
        public async Task SpinToAngle(float targetAngle, int durationMs = 1000)
        {
            if (_isSpinning) return;
            _isSpinning = true;
            SpinButton.IsEnabled = false;

            float extraSpins = Random.Shared.Next(5, 9) * 360f;
            float normalized = ((_currentAngle % 360f) + 360f) % 360f;
            float delta = ((targetAngle - normalized) % 360f + 360f) % 360f;
            float endAngle = _currentAngle + delta + extraSpins;

            await AnimateWheel(_currentAngle, endAngle, durationMs);
            _currentAngle = endAngle;

            SpinButton.IsEnabled = true;
            _isSpinning = false;
        }

        private async void OnSpinClicked(object? sender, EventArgs e)
        {
            // Tutaj podłącz swoją logikę – wylicz targetAngle i wywołaj SpinToAngle()
            // Przykład: await SpinToAngle(someAngle);
            await SpinToAngle(Random.Shared.NextSingle() * 360f);
        }

        private async Task AnimateWheel(float fromAngle, float toAngle, int durationMs)
        {
            const int fps = 60;
            int frames = durationMs * fps / 1000;
            float totalDiff = toAngle - fromAngle;

            for (int frame = 1; frame <= frames; frame++)
            {
                float t = (float)frame / frames;
                float eased = 1f - MathF.Pow(1f - t, 3f);

                _drawable.RotationAngle = fromAngle + totalDiff * eased;
                WheelView.Invalidate();

                await Task.Delay(1000 / fps);
            }

            _drawable.RotationAngle = toAngle;
            WheelView.Invalidate();
        }
        #endregion

        private void AccountTapped(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new AccountPage());
        }
        private void AccountHoverEntered(object? sender, PointerEventArgs e)
        {
            AccountBorder.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void AccountHoverExited(object? sender, PointerEventArgs e)
        {
            AccountBorder.Background = new SolidColorBrush(Colors.SlateGray);
        }
    }
}