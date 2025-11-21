using Back.MediatR.Queries;
using FluentValidation;

namespace Back.Validation;

public class GetDoctorsBySpecializationQueryValidator : AbstractValidator<GetDoctorsBySpecializationQuery>
{
    public GetDoctorsBySpecializationQueryValidator()
    {
        RuleFor(d => d.Specialization)
            .NotEmpty().WithMessage("Специализация обязательна.")
            .MinimumLength(3)
            .MaximumLength(100)
            .Matches("^[A-Za-zА-Яа-яЁё\\s-]+$").WithMessage("Название специализации содержит недопустимые символы.");
    }
}