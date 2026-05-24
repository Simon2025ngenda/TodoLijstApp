using TodoLijstApp.Models;
using TodoLijstApp.Repositories;
using TodoLijstApp.Strategies;

namespace TodoLijstApp
{
    public partial class MainPage : ContentPage
    {
        private readonly TaskRepository _taskRepository;
        private readonly PersonRepository _personRepository;

        public MainPage()
        {
            InitializeComponent();

            _taskRepository = new TaskRepository();
            _personRepository = new PersonRepository();

            LoadPersons();
            LoadTasks();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadPersons();
            LoadTasks();
        }

        private void OnAddTaskClicked(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(TaskEntry.Text))
                return;

            var selectedPerson = PersonsPicker.SelectedItem as Person;

            var task = new TaskItem
            {
                Title = TaskEntry.Text,
                Description = "",
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AssignedPersonId = selectedPerson?.Id ?? 0,
                AssignedPersonName = selectedPerson != null
                  ? $"{selectedPerson.FirstName} {selectedPerson.LastName}"
                  : "Geen persoon"
            };

            _taskRepository.Add(task);

            TaskEntry.Text = "";

            LoadTasks();
        }

        private void ApplyFilter(ITaskFilterStrategy strategy)
        {
            var tasks = _taskRepository.GetAll();

            TasksList.ItemsSource = strategy.Filter(tasks);
        }

        private void OnTaskCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.BindingContext is TaskItem task)
            {
                task.IsCompleted = e.Value;
                task.UpdatedAt = DateTime.Now;

                _taskRepository.Update(task);
            }
        }

        private async void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is TaskItem task)
            {
                bool confirm = await DisplayAlert(
                    "Bevestigen",
                    $"Wil je '{task.Title}' verwijderen?",
                    "Ja",
                    "Nee");

                if (confirm)
                {
                    _taskRepository.Delete(task.Id);
                    LoadTasks();
                }
            }
        }

        private async void OnTaskTapped(object sender, TappedEventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is TaskItem task)
            {
                await Navigation.PushAsync(new TodoLijstApp.views.TaskDetailPage(task));
            }
        }
        private async void OnPersonsClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new TodoLijstApp.views.PersonenPagina());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fout", ex.Message, "OK");
            }
        }

        private void LoadPersons()
        {
            PersonsPicker.ItemsSource = _personRepository.GetAll();
        }


        private void LoadTasks()
        {
            TasksList.ItemsSource = null;
            TasksList.ItemsSource = _taskRepository.GetAll();
        }

        private void OnShowAllClicked(object sender, EventArgs e)
        {
            ApplyFilter(new AllTasksFilterStrategy());
        }



        private void OnShowNotCompletedClicked(object sender, EventArgs e)
        {
            ApplyFilter(new NotCompletedTasksFilterStrategy());
        }

        private void OnShowRecentClicked(object sender, EventArgs e)
        {
            ApplyFilter(new RecentTasksFilterStrategy());
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = e.NewTextValue?.ToLower() ?? "";

            var tasks = _taskRepository.GetAll();

            var filteredTasks = tasks
                .Where(t => t.Title.ToLower().Contains(searchText))
                .ToList();

            TasksList.ItemsSource = filteredTasks;
        }
    }
}