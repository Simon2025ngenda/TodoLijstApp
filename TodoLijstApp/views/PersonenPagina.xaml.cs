using TodoLijstApp.Models;
using TodoLijstApp.Repositories;

namespace TodoLijstApp.views;

public partial class PersonenPagina : ContentPage
{
    private readonly PersonRepository _personRepository;

    public PersonenPagina()
    {
        InitializeComponent();

        _personRepository = new PersonRepository();

        LoadPersons();
    }

    private void LoadPersons()
    {
        PersonsList.ItemsSource = _personRepository.GetAll();
    }

    private void OnAddPersonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(FirstNameEntry.Text) ||
            string.IsNullOrWhiteSpace(LastNameEntry.Text))
        {
            return;
        }

        var person = new Person
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            BirthDate = BirthDatePicker.Date ?? DateTime.Today,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _personRepository.Add(person);

        FirstNameEntry.Text = "";
        LastNameEntry.Text = "";

        LoadPersons();
    }


    private async void OnPersonTapped(object sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Person person)
        {
            await Navigation.PushAsync(new persoonDetailPage(person));
        }
    }


    private void OnDeletePersonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Person person)
        {
            _personRepository.Delete(person.Id);

            LoadPersons();
        }
    }
}