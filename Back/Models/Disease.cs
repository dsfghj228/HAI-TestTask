namespace Back.Models;

public class Disease
{
    public int DiseaseId { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }

    public List<Patient> Patients { get; set; } = new();
}
