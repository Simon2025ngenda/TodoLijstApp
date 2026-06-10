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
            var mainPage = IPlatformApplication.Current!
                .Services
                .GetService<MainPage>();

            return new Window(new NavigationPage(mainPage));
        }
    }
}