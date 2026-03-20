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

        #region hoovers
        private void AccountHoverEntered(object? sender, PointerEventArgs e)
        {
            AccountBorder.Background = new SolidColorBrush(Color.FromArgb("#a0a0a0"));
        }
        private void AccountHoverExited(object? sender, PointerEventArgs e)
        {
            AccountBorder.Background = new SolidColorBrush(Colors.SlateGray);
        }

        private void SpinButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            SpinButton.BackgroundColor = Color.FromArgb("#B81304");
        }
        private void SpinButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            SpinButton.BackgroundColor = Colors.Maroon;
        }

        private void CancelButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            CancelButton.BackgroundColor = Colors.LightGray;
        }
        private void CancelButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            CancelButton.BackgroundColor = Colors.DarkGray;
        }

        //BETS

        //0
        private void Bet0Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet0Button.BackgroundColor = Color.FromArgb("#0DC700");
        }
        private void Bet0Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet0Button.BackgroundColor = Colors.Green;
        }
        // 1
        private void Bet1Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet1Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet1Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet1Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 2
        private void Bet2Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet2Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet2Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet2Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 3
        private void Bet3Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet3Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet3Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet3Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 4
        private void Bet4Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet4Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet4Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet4Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 5
        private void Bet5Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet5Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet5Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet5Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 6
        private void Bet6Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet6Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet6Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet6Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 7
        private void Bet7Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet7Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet7Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet7Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 8
        private void Bet8Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet8Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet8Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet8Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 9
        private void Bet9Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet9Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet9Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet9Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 10
        private void Bet10Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet10Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet10Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet10Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 11
        private void Bet11Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet11Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet11Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet11Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 12
        private void Bet12Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet12Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet12Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet12Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 13
        private void Bet13Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet13Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet13Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet13Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 14
        private void Bet14Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet14Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet14Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet14Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 15
        private void Bet15Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet15Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet15Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet15Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 16
        private void Bet16Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet16Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet16Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet16Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 17
        private void Bet17Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet17Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet17Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet17Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 18
        private void Bet18Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet18Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet18Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet18Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 19
        private void Bet19Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet19Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet19Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet19Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 20
        private void Bet20Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet20Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet20Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet20Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 21
        private void Bet21Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet21Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet21Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet21Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 22
        private void Bet22Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet22Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet22Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet22Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 23
        private void Bet23Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet23Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet23Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet23Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 24
        private void Bet24Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet24Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet24Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet24Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 25
        private void Bet25Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet25Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet25Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet25Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 26
        private void Bet26Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet26Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet26Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet26Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 27
        private void Bet27Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet27Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet27Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet27Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 28
        private void Bet28Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet28Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet28Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet28Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 29
        private void Bet29Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet29Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet29Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet29Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 30
        private void Bet30Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet30Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet30Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet30Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 31
        private void Bet31Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet31Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet31Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet31Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 32
        private void Bet32Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet32Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet32Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet32Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 33
        private void Bet33Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet33Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet33Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet33Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 34
        private void Bet34Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet34Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet34Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet34Button.BackgroundColor = Color.FromArgb("#242424");
        }

        // 35
        private void Bet35Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet35Button.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet35Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet35Button.BackgroundColor = Color.FromArgb("#B81304");
        }

        // 36
        private void Bet36Button_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet36Button.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void Bet36Button_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet36Button.BackgroundColor = Color.FromArgb("#242424");
        }

        //RED
        private void BetRedButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            BetRedButton.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void BetRedButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            BetRedButton.BackgroundColor = Color.FromArgb("#B81304");
        }

        //BLACK
        private void BetBlackButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            BetBlackButton.BackgroundColor = Color.FromArgb("#4A4A4A");
        }
        private void BetBlackButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            BetBlackButton.BackgroundColor = Color.FromArgb("#242424");
        }

        //BETTING CHIPS
        // 1$ 
        private void Bet1DollarButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet1DollarButton.BackgroundColor = Color.FromArgb("#B077E8");
        }
        private void Bet1DollarButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet1DollarButton.BackgroundColor = Color.FromArgb("#8342B8");
        }

        // 5$ 
        private void Bet5DollarButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet5DollarButton.BackgroundColor = Color.FromArgb("#FF7070");
        }
        private void Bet5DollarButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet5DollarButton.BackgroundColor = Color.FromArgb("#B0130B");
        }

        // 25$
        private void Bet25DollarButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet25DollarButton.BackgroundColor = Color.FromArgb("#098D00");
        }
        private void Bet25DollarButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet25DollarButton.BackgroundColor = Color.FromArgb("#22740B");
        }

        // 50$
        private void Bet50DollarButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet50DollarButton.BackgroundColor = Color.FromArgb("#F5DC00");
        }
        private void Bet50DollarButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet50DollarButton.BackgroundColor = Color.FromArgb("#BFAC00");
        }

        // 100$
        private void Bet100DollarButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet100DollarButton.BackgroundColor = Color.FromArgb("#E89FEB");
        }
        private void Bet100DollarButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet100DollarButton.BackgroundColor = Color.FromArgb("#CC66D0");
        }

        // 500$
        private void Bet500DollarButton_OnPointerEntered(object sender, PointerEventArgs e)
        {
            Bet500DollarButton.BackgroundColor = Color.FromArgb("#FFB066");
        }
        private void Bet500DollarButton_OnPointerExited(object sender, PointerEventArgs e)
        {
            Bet500DollarButton.BackgroundColor = Color.FromArgb("#E86C00");
        }
        #endregion

        private void AccountTapped(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new AccountPage());
        }

        
    }
}