namespace Back.Dto;

public class ReturnPatientDto
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

    public List<ReturnDiseaseDto> Diseases { get; set; } = new();
}