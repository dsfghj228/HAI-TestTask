using Back.MediatR.Queries;
using FluentValidation;

namespace Back.Validation;

public class GetPatientByIdQueryValidator : AbstractValidator<GetPatientByIdQuery>
{
    public GetPatientByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Идентификатор доктора должен быть положительным");
    }
}