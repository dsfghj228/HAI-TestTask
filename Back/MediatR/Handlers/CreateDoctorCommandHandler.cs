using AutoMapper;
using Back.Dto;
using Back.Interfaces;
using Back.MediatR.Commands;
using MediatR;

namespace Back.MediatR.Handlers;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, ReturnDoctorDto>
{
    private readonly IDoctorRepository _repo;
    private readonly IMapper _mapper;
    
    public CreateDoctorCommandHandler(IDoctorRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<ReturnDoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repo.CreateDoctor(request);
        var doctorForReturn = _mapper.Map<ReturnDoctorDto>(doctor);
        return doctorForReturn;
    }
}