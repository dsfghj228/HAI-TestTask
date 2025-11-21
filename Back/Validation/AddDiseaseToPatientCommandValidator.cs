using Back.MediatR.Commands;
using FluentValidation;

namespace Back.Validation;

public class AddDiseaseToPatientCommandValidator : AbstractValidator<AddDiseaseToPatientCommand>
{
    public AddDiseaseToPatientCommandValidator()
    {
        RuleFor(x => x.PatientId)
            .GreaterThan(0).WithMessage("Идентификатор доктора должен быть положительным");
        RuleFor(x => x.DiseaseId)
            .GreaterThan(0).WithMessage("Идентификатор доктора должен быть положительным");
    }
}