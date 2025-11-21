using Back.MediatR.Commands;
using FluentValidation;

namespace Back.Validation;

public class UpdateDiseaseInfoCommandValidator : AbstractValidator<UpdateDiseaseInfoCommand>
{
    public UpdateDiseaseInfoCommandValidator()
    {
        RuleFor(x => x.DiseaseId)
            .GreaterThan(0)
            .WithMessage("Идентификатор должен быть положительный числом.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Имя обязательно")
            .MinimumLength(2).WithMessage("Имя должно содержать как минимум 2 символа.")
            .MaximumLength(200).WithMessage("Имя не может превышать 200 символов.");

        RuleFor(x => x.Description)
            .MaximumLength(2000)
            .WithMessage("Описание не может превышать 2000 символов.");
    }
}