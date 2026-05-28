using Microsoft.Extensions.DependencyInjection;
using Ruletka.Data;

namespace Ruletka
{
    public partial class App : Application
    {
        public static User CurrentUser { get; set; }
        public App()
        {
            InitializeComponent();

            using (var db = new RuletkaDb())
            {
                db.Database.EnsureCreated();
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
            window.Width = 1000;
            window.Height = 1000;
            return window;
        }
    }
}