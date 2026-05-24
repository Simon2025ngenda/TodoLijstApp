namespace TodoLijstApp.Models;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string FullName => $"{FirstName} {LastName}";

    public string AgeText
    {
        get
        {
            if (BirthDate == DateTime.MinValue)
                return "Geen geboortedatum";

            var today = DateTime.Today;
            var age = today.Year - BirthDate.Year;

            if (BirthDate.Date > today.AddYears(-age))
                age--;

            return $"{age} jaar";
        }
    }

    public DateTime BirthDate { get; set; }

    public string ImageUrl { get; set; } = "";

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
