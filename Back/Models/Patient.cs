namespace Back.Models;

public class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }

    public string Phone { get; set; }
    public string? Email { get; set; }
    public string Address { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public List<Disease> Diseases { get; set; } = new();
}
