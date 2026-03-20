namespace Ruletka
{
    public partial class MainPage : ContentPage
    {
        private readonly RouletteWheelDrawable _drawable = new();
        private float _currentAngle = 0f;
        private bool _isSpinning = false;

        public double balance = 0;
        public double chosen_chip_value = 0;

        double[] current_bet_on = new double[37];
        double current_bet_on_red = 0;
        double current_bet_on_black = 0;

        public double current_bet = 0;

        private List<Grid> _betGrids;

        public MainPage()
        {
            InitializeComponent();
            WheelView.Drawable = _drawable;
            balance_label.Text = Math.Round(balance, 2).ToString() + "$";

            _betGrids = new List<Grid>
            {
                Bet0Grid, Bet1Grid, Bet2Grid, Bet3Grid, Bet4Grid, Bet5Grid,
                Bet6Grid, Bet7Grid, Bet8Grid, Bet9Grid, Bet10Grid, Bet11Grid,
                Bet12Grid, Bet13Grid, Bet14Grid, Bet15Grid, Bet16Grid, Bet17Grid,
                Bet18Grid, Bet19Grid, Bet20Grid, Bet21Grid, Bet22Grid, Bet23Grid,
                Bet24Grid, Bet25Grid, Bet26Grid, Bet27Grid, Bet28Grid, Bet29Grid,
                Bet30Grid, Bet31Grid, Bet32Grid, Bet33Grid, Bet34Grid, Bet35Grid,
                Bet36Grid, BetRedGrid, BetBlackGrid
            };
        }

        private void AccountTapped(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new AccountPage());
        }

        private async void OnSpinClicked(object? sender, EventArgs e)
        {
            await SpinToAngle(Random.Shared.NextSingle() * 360f);
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            foreach (var grid in _betGrids)
            {
                var label = grid.Children.OfType<Label>().FirstOrDefault();
                if (label != null) grid.Children.Remove(label);
            }

            Array.Clear(current_bet_on);
            current_bet_on_red = 0;
            current_bet_on_black = 0;
        }

        #region żetony
        private void Bet1DollarButton_Clicked(object sender, EventArgs e) { chosen_chip_value = 1; }
        private void Bet5DollarButton_Clicked(object sender, EventArgs e) { chosen_chip_value = 5; }
        private void Bet25DollarButton_Clicked(object sender, EventArgs e) { chosen_chip_value = 25; }
        private void Bet50DollarButton_Clicked(object sender, EventArgs e) { chosen_chip_value = 50; }
        private void Bet100DollarButton_Clicked(object sender, EventArgs e) { chosen_chip_value = 100; }
        private void Bet500DollarButton_Clicked(object sender, EventArgs e) { chosen_chip_value = 500; }
        #endregion

        #region zakłady

        public double PlaceBet(double currentBet)
        {
            if (chosen_chip_value == 0)
            {
                DisplayAlert("Błąd", "Wybierz wartość żetonu przed postawieniem zakładu.", "OK");
                return currentBet;
            }
            return currentBet + chosen_chip_value;
        }

        public void DisplayBet(double currentBet, Grid betsGrid)
        {
            var existing = betsGrid.Children.OfType<Label>().FirstOrDefault();
            if (existing != null) betsGrid.Children.Remove(existing);

            var label = new Label
            {
                Text = $"{currentBet}$",
                FontSize = 11,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Yellow,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                Margin = 2,
            };
            betsGrid.Children.Add(label);
        }

        // NUMERY
        private void Bet0Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[0] = PlaceBet(current_bet_on[0]);
            if (current_bet_on[0] != 0) DisplayBet(current_bet_on[0], Bet0Grid);
        }
        private void Bet1Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[1] = PlaceBet(current_bet_on[1]);
            if (current_bet_on[1] != 0) DisplayBet(current_bet_on[1], Bet1Grid);
        }
        private void Bet2Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[2] = PlaceBet(current_bet_on[2]);
            if (current_bet_on[2] != 0) DisplayBet(current_bet_on[2], Bet2Grid);
        }
        private void Bet3Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[3] = PlaceBet(current_bet_on[3]);
            if (current_bet_on[3] != 0) DisplayBet(current_bet_on[3], Bet3Grid);
        }
        private void Bet4Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[4] = PlaceBet(current_bet_on[4]);
            if (current_bet_on[4] != 0) DisplayBet(current_bet_on[4], Bet4Grid);
        }
        private void Bet5Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[5] = PlaceBet(current_bet_on[5]);
            if (current_bet_on[5] != 0) DisplayBet(current_bet_on[5], Bet5Grid);
        }
        private void Bet6Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[6] = PlaceBet(current_bet_on[6]);
            if (current_bet_on[6] != 0) DisplayBet(current_bet_on[6], Bet6Grid);
        }
        private void Bet7Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[7] = PlaceBet(current_bet_on[7]);
            if (current_bet_on[7] != 0) DisplayBet(current_bet_on[7], Bet7Grid);
        }
        private void Bet8Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[8] = PlaceBet(current_bet_on[8]);
            if (current_bet_on[8] != 0) DisplayBet(current_bet_on[8], Bet8Grid);
        }
        private void Bet9Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[9] = PlaceBet(current_bet_on[9]);
            if (current_bet_on[9] != 0) DisplayBet(current_bet_on[9], Bet9Grid);
        }
        private void Bet10Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[10] = PlaceBet(current_bet_on[10]);
            if (current_bet_on[10] != 0) DisplayBet(current_bet_on[10], Bet10Grid);
        }
        private void Bet11Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[11] = PlaceBet(current_bet_on[11]);
            if (current_bet_on[11] != 0) DisplayBet(current_bet_on[11], Bet11Grid);
        }
        private void Bet12Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[12] = PlaceBet(current_bet_on[12]);
            if (current_bet_on[12] != 0) DisplayBet(current_bet_on[12], Bet12Grid);
        }
        private void Bet13Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[13] = PlaceBet(current_bet_on[13]);
            if (current_bet_on[13] != 0) DisplayBet(current_bet_on[13], Bet13Grid);
        }
        private void Bet14Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[14] = PlaceBet(current_bet_on[14]);
            if (current_bet_on[14] != 0) DisplayBet(current_bet_on[14], Bet14Grid);
        }
        private void Bet15Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[15] = PlaceBet(current_bet_on[15]);
            if (current_bet_on[15] != 0) DisplayBet(current_bet_on[15], Bet15Grid);
        }
        private void Bet16Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[16] = PlaceBet(current_bet_on[16]);
            if (current_bet_on[16] != 0) DisplayBet(current_bet_on[16], Bet16Grid);
        }
        private void Bet17Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[17] = PlaceBet(current_bet_on[17]);
            if (current_bet_on[17] != 0) DisplayBet(current_bet_on[17], Bet17Grid);
        }
        private void Bet18Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[18] = PlaceBet(current_bet_on[18]);
            if (current_bet_on[18] != 0) DisplayBet(current_bet_on[18], Bet18Grid);
        }
        private void Bet19Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[19] = PlaceBet(current_bet_on[19]);
            if (current_bet_on[19] != 0) DisplayBet(current_bet_on[19], Bet19Grid);
        }
        private void Bet20Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[20] = PlaceBet(current_bet_on[20]);
            if (current_bet_on[20] != 0) DisplayBet(current_bet_on[20], Bet20Grid);
        }
        private void Bet21Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[21] = PlaceBet(current_bet_on[21]);
            if (current_bet_on[21] != 0) DisplayBet(current_bet_on[21], Bet21Grid);
        }
        private void Bet22Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[22] = PlaceBet(current_bet_on[22]);
            if (current_bet_on[22] != 0) DisplayBet(current_bet_on[22], Bet22Grid);
        }
        private void Bet23Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[23] = PlaceBet(current_bet_on[23]);
            if (current_bet_on[23] != 0) DisplayBet(current_bet_on[23], Bet23Grid);
        }
        private void Bet24Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[24] = PlaceBet(current_bet_on[24]);
            if (current_bet_on[24] != 0) DisplayBet(current_bet_on[24], Bet24Grid);
        }
        private void Bet25Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[25] = PlaceBet(current_bet_on[25]);
            if (current_bet_on[25] != 0) DisplayBet(current_bet_on[25], Bet25Grid);
        }
        private void Bet26Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[26] = PlaceBet(current_bet_on[26]);
            if (current_bet_on[26] != 0) DisplayBet(current_bet_on[26], Bet26Grid);
        }
        private void Bet27Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[27] = PlaceBet(current_bet_on[27]);
            if (current_bet_on[27] != 0) DisplayBet(current_bet_on[27], Bet27Grid);
        }
        private void Bet28Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[28] = PlaceBet(current_bet_on[28]);
            if (current_bet_on[28] != 0) DisplayBet(current_bet_on[28], Bet28Grid);
        }
        private void Bet29Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[29] = PlaceBet(current_bet_on[29]);
            if (current_bet_on[29] != 0) DisplayBet(current_bet_on[29], Bet29Grid);
        }
        private void Bet30Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[30] = PlaceBet(current_bet_on[30]);
            if (current_bet_on[30] != 0) DisplayBet(current_bet_on[30], Bet30Grid);
        }
        private void Bet31Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[31] = PlaceBet(current_bet_on[31]);
            if (current_bet_on[31] != 0) DisplayBet(current_bet_on[31], Bet31Grid);
        }
        private void Bet32Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[32] = PlaceBet(current_bet_on[32]);
            if (current_bet_on[32] != 0) DisplayBet(current_bet_on[32], Bet32Grid);
        }
        private void Bet33Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[33] = PlaceBet(current_bet_on[33]);
            if (current_bet_on[33] != 0) DisplayBet(current_bet_on[33], Bet33Grid);
        }
        private void Bet34Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[34] = PlaceBet(current_bet_on[34]);
            if (current_bet_on[34] != 0) DisplayBet(current_bet_on[34], Bet34Grid);
        }
        private void Bet35Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[35] = PlaceBet(current_bet_on[35]);
            if (current_bet_on[35] != 0) DisplayBet(current_bet_on[35], Bet35Grid);
        }
        private void Bet36Button_Clicked(object sender, EventArgs e)
        {
            current_bet_on[36] = PlaceBet(current_bet_on[36]);
            if (current_bet_on[36] != 0) DisplayBet(current_bet_on[36], Bet36Grid);
        }

        // KOLORY
        private void BetRedButton_Clicked(object sender, EventArgs e)
        {
            current_bet_on_red = PlaceBet(current_bet_on_red);
            if (current_bet_on_red == 0) return;

            var existing = BetRedGrid.Children.OfType<Label>().FirstOrDefault();
            if (existing != null) BetRedGrid.Children.Remove(existing);

            var label = new Label
            {
                Text = $"{current_bet_on_red}$",
                FontSize = 11,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Yellow,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                Margin = 8,
            };
            BetRedGrid.Children.Add(label);
        }

        private void BetBlackButton_Clicked(object sender, EventArgs e)
        {
            current_bet_on_black = PlaceBet(current_bet_on_black);
            if (current_bet_on_black == 0) return;

            var existing = BetBlackGrid.Children.OfType<Label>().FirstOrDefault();
            if (existing != null) BetBlackGrid.Children.Remove(existing);

            var label = new Label
            {
                Text = $"{current_bet_on_black}$",
                FontSize = 11,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Yellow,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                Margin = 8,
            };
            BetBlackGrid.Children.Add(label);
        }

        #endregion

        #region koło ruletki
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
        private void AccountHoverEntered(object? sender, PointerEventArgs e) { AccountBorder.Background = new SolidColorBrush(Color.FromArgb("#a0a0a0")); }
        private void AccountHoverExited(object? sender, PointerEventArgs e) { AccountBorder.Background = new SolidColorBrush(Colors.SlateGray); }
        private void SpinButton_OnPointerEntered(object sender, PointerEventArgs e) { SpinButton.BackgroundColor = Color.FromArgb("#B81304"); }
        private void SpinButton_OnPointerExited(object sender, PointerEventArgs e) { SpinButton.BackgroundColor = Colors.Maroon; }
        private void CancelButton_OnPointerEntered(object sender, PointerEventArgs e) { CancelButton.BackgroundColor = Colors.LightGray; }
        private void CancelButton_OnPointerExited(object sender, PointerEventArgs e) { CancelButton.BackgroundColor = Colors.DarkGray; }

        private void Bet0Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet0Button.BackgroundColor = Color.FromArgb("#0DC700"); }
        private void Bet0Button_OnPointerExited(object sender, PointerEventArgs e) { Bet0Button.BackgroundColor = Colors.Green; }
        private void Bet1Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet1Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet1Button_OnPointerExited(object sender, PointerEventArgs e) { Bet1Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet2Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet2Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet2Button_OnPointerExited(object sender, PointerEventArgs e) { Bet2Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet3Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet3Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet3Button_OnPointerExited(object sender, PointerEventArgs e) { Bet3Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet4Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet4Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet4Button_OnPointerExited(object sender, PointerEventArgs e) { Bet4Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet5Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet5Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet5Button_OnPointerExited(object sender, PointerEventArgs e) { Bet5Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet6Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet6Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet6Button_OnPointerExited(object sender, PointerEventArgs e) { Bet6Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet7Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet7Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet7Button_OnPointerExited(object sender, PointerEventArgs e) { Bet7Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet8Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet8Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet8Button_OnPointerExited(object sender, PointerEventArgs e) { Bet8Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet9Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet9Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet9Button_OnPointerExited(object sender, PointerEventArgs e) { Bet9Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet10Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet10Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet10Button_OnPointerExited(object sender, PointerEventArgs e) { Bet10Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet11Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet11Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet11Button_OnPointerExited(object sender, PointerEventArgs e) { Bet11Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet12Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet12Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet12Button_OnPointerExited(object sender, PointerEventArgs e) { Bet12Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet13Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet13Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet13Button_OnPointerExited(object sender, PointerEventArgs e) { Bet13Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet14Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet14Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet14Button_OnPointerExited(object sender, PointerEventArgs e) { Bet14Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet15Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet15Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet15Button_OnPointerExited(object sender, PointerEventArgs e) { Bet15Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet16Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet16Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet16Button_OnPointerExited(object sender, PointerEventArgs e) { Bet16Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet17Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet17Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet17Button_OnPointerExited(object sender, PointerEventArgs e) { Bet17Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet18Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet18Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet18Button_OnPointerExited(object sender, PointerEventArgs e) { Bet18Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet19Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet19Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet19Button_OnPointerExited(object sender, PointerEventArgs e) { Bet19Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet20Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet20Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet20Button_OnPointerExited(object sender, PointerEventArgs e) { Bet20Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet21Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet21Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet21Button_OnPointerExited(object sender, PointerEventArgs e) { Bet21Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet22Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet22Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet22Button_OnPointerExited(object sender, PointerEventArgs e) { Bet22Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet23Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet23Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet23Button_OnPointerExited(object sender, PointerEventArgs e) { Bet23Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet24Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet24Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet24Button_OnPointerExited(object sender, PointerEventArgs e) { Bet24Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet25Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet25Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet25Button_OnPointerExited(object sender, PointerEventArgs e) { Bet25Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet26Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet26Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet26Button_OnPointerExited(object sender, PointerEventArgs e) { Bet26Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet27Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet27Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet27Button_OnPointerExited(object sender, PointerEventArgs e) { Bet27Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet28Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet28Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet28Button_OnPointerExited(object sender, PointerEventArgs e) { Bet28Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet29Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet29Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet29Button_OnPointerExited(object sender, PointerEventArgs e) { Bet29Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet30Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet30Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet30Button_OnPointerExited(object sender, PointerEventArgs e) { Bet30Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet31Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet31Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet31Button_OnPointerExited(object sender, PointerEventArgs e) { Bet31Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet32Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet32Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet32Button_OnPointerExited(object sender, PointerEventArgs e) { Bet32Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet33Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet33Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet33Button_OnPointerExited(object sender, PointerEventArgs e) { Bet33Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet34Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet34Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet34Button_OnPointerExited(object sender, PointerEventArgs e) { Bet34Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void Bet35Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet35Button.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet35Button_OnPointerExited(object sender, PointerEventArgs e) { Bet35Button.BackgroundColor = Color.FromArgb("#B81304"); }
        private void Bet36Button_OnPointerEntered(object sender, PointerEventArgs e) { Bet36Button.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void Bet36Button_OnPointerExited(object sender, PointerEventArgs e) { Bet36Button.BackgroundColor = Color.FromArgb("#242424"); }
        private void BetRedButton_OnPointerEntered(object sender, PointerEventArgs e) { BetRedButton.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void BetRedButton_OnPointerExited(object sender, PointerEventArgs e) { BetRedButton.BackgroundColor = Color.FromArgb("#B81304"); }
        private void BetBlackButton_OnPointerEntered(object sender, PointerEventArgs e) { BetBlackButton.BackgroundColor = Color.FromArgb("#4A4A4A"); }
        private void BetBlackButton_OnPointerExited(object sender, PointerEventArgs e) { BetBlackButton.BackgroundColor = Color.FromArgb("#242424"); }
        
        private void Bet1DollarButton_OnPointerEntered(object sender, PointerEventArgs e) { Bet1DollarButton.BackgroundColor = Color.FromArgb("#B077E8"); }
        private void Bet1DollarButton_OnPointerExited(object sender, PointerEventArgs e) { Bet1DollarButton.BackgroundColor = Color.FromArgb("#8342B8"); }
        private void Bet5DollarButton_OnPointerEntered(object sender, PointerEventArgs e) { Bet5DollarButton.BackgroundColor = Color.FromArgb("#FF7070"); }
        private void Bet5DollarButton_OnPointerExited(object sender, PointerEventArgs e) { Bet5DollarButton.BackgroundColor = Color.FromArgb("#B0130B"); }
        private void Bet25DollarButton_OnPointerEntered(object sender, PointerEventArgs e) { Bet25DollarButton.BackgroundColor = Color.FromArgb("#098D00"); }
        private void Bet25DollarButton_OnPointerExited(object sender, PointerEventArgs e) { Bet25DollarButton.BackgroundColor = Color.FromArgb("#22740B"); }
        private void Bet50DollarButton_OnPointerEntered(object sender, PointerEventArgs e) { Bet50DollarButton.BackgroundColor = Color.FromArgb("#F5DC00"); }
        private void Bet50DollarButton_OnPointerExited(object sender, PointerEventArgs e) { Bet50DollarButton.BackgroundColor = Color.FromArgb("#BFAC00"); }
        private void Bet100DollarButton_OnPointerEntered(object sender, PointerEventArgs e) { Bet100DollarButton.BackgroundColor = Color.FromArgb("#E89FEB"); }
        private void Bet100DollarButton_OnPointerExited(object sender, PointerEventArgs e) { Bet100DollarButton.BackgroundColor = Color.FromArgb("#CC66D0"); }
        private void Bet500DollarButton_OnPointerEntered(object sender, PointerEventArgs e) { Bet500DollarButton.BackgroundColor = Color.FromArgb("#FFB066"); }
        private void Bet500DollarButton_OnPointerExited(object sender, PointerEventArgs e) { Bet500DollarButton.BackgroundColor = Color.FromArgb("#E86C00"); }
        #endregion
    }
}