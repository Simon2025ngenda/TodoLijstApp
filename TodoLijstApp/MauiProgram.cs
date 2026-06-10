using TodoLijstApp.Repositories;
using TodoLijstApp.views;
using TodoLijstApp.services;

namespace TodoLijstApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>();

            builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
            builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

            builder.Services.AddTransient<TaskService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<PersonenPagina>();
            builder.Services.AddTransient<TaskDetailPage>();
            builder.Services.AddTransient<persoonDetailPage>();
            

            return builder.Build();
        }
    }
}
