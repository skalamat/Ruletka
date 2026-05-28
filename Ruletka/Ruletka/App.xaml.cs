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
            return new Window(new AppShell());
        }
    }
}