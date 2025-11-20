namespace Back.Models;

public class Doctor
{
    public int DoctorId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Specialization { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public int ExperienceYears { get; set; }

    public List<Patient> Patients { get; set; } = new();
}
