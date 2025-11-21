using Back.Dto;
using MediatR;

namespace Back.MediatR.Commands;

public class CreateDoctorCommand : IRequest<ReturnDoctorDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Specialization { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public int ExperienceYears { get; set; }
}