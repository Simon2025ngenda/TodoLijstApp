using Microsoft.Extensions.DependencyInjection;

namespace TodoLijstApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute("PersonenPagina", typeof(TodoLijstApp.views.PersonenPagina));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
           return new Window(new NavigationPage(new MainPage()));
        }
    }
}