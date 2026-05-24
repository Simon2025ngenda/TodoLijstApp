using TodoLijstApp.Models;
using TodoLijstApp.Repositories;

namespace TodoLijstApp.views;

public partial class TaskDetailPage : ContentPage
{
    private readonly TaskRepository _taskRepository;
    private readonly PersonRepository _personRepository;

    private TaskItem _task;

    public TaskDetailPage(TaskItem task)
    {
        InitializeComponent();

        _taskRepository = new TaskRepository();
        _personRepository = new PersonRepository();

        _task = task;

        PersonsPicker.ItemsSource = _personRepository.GetAll();

        TitleEntry.Text = task.Title;
        DescriptionEditor.Text = task.Description;
        CompletedCheckBox.IsChecked = task.IsCompleted;

        if (task.AssignedPersonId > 0)
        {
            var person = _personRepository.GetById(task.AssignedPersonId);

            if (person != null)
            {
                PersonsPicker.SelectedItem = person;
            }
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlert("Fout", "Titel is verplicht.", "OK");
            return;
        }

        if (PersonsPicker.SelectedItem == null)
        {
            await DisplayAlert("Fout", "Je moet een persoon kiezen.", "OK");
            return;
        }


        _task.Title = TitleEntry.Text;
        _task.Description = DescriptionEditor.Text;
        _task.IsCompleted = CompletedCheckBox.IsChecked;
        _task.UpdatedAt = DateTime.Now;

        if (PersonsPicker.SelectedItem is Person selectedPerson)
        {
            _task.AssignedPersonId = selectedPerson.Id;
            _task.AssignedPersonName = $"{selectedPerson.FirstName} {selectedPerson.LastName}";
        }

        _taskRepository.Update(_task);

        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}