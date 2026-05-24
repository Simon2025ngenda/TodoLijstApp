using TodoLijstApp.Models;
using TodoLijstApp.Repositories;

namespace TodoLijstApp.views;

public partial class persoonDetailPage : ContentPage
{
    private readonly PersonRepository _personRepository;

    private Person _person;

    public persoonDetailPage(Person person)
    {
        InitializeComponent();

        _personRepository = new PersonRepository();

        _person = person;

        FirstNameEntry.Text = person.FirstName;
        LastNameEntry.Text = person.LastName;
        BirthDatePicker.Date = person.BirthDate;
        ImageUrlEntry.Text = person.ImageUrl;

        if (!string.IsNullOrWhiteSpace(person.ImageUrl))
        {
            PersonImage.Source = person.ImageUrl;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(FirstNameEntry.Text))
        {
            await DisplayAlert("Fout", "Voornaam is verplicht.", "OK");
            return;
        }




        _person.FirstName = FirstNameEntry.Text;
        _person.LastName = LastNameEntry.Text;
        _person.BirthDate = BirthDatePicker.Date ?? DateTime.Today;
        _person.ImageUrl = ImageUrlEntry.Text;
        _person.UpdatedAt = DateTime.Now;

        _personRepository.Update(_person);

        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        _personRepository.Delete(_person.Id);

        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}