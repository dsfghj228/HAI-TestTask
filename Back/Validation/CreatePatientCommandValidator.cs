using Back.MediatR.Commands;
using FluentValidation;

namespace Back.Validation;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Имя обязательно")
            .MaximumLength(50).WithMessage("Имя не может быть длиннее 50 символов");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Фамилия обязательна")
            .MaximumLength(50).WithMessage("Фамилия не может быть длиннее 50 символов");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Дата рождения обязательна")
            .LessThan(DateTime.Now).WithMessage("Дата рождения должна быть в прошлом")
            .GreaterThan(DateTime.Now.AddYears(-120))
            .WithMessage("Возраст пациента не может быть больше 120 лет");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Пол обязателен")
            .Must(g => g == "Male" || g == "Female" || g == "Other")
            .WithMessage("Недопустимое значение пола");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Телефон обязателен")
            .Matches(@"^\+?[0-9]{10,15}$")
            .WithMessage("Телефон должен быть в международном формате, напр.: +79991234567");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Некорректный email")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Адрес обязателен")
            .MaximumLength(200).WithMessage("Адрес слишком длинный");

        RuleFor(x => x.DoctorId)
            .GreaterThan(0).WithMessage("Идентификатор доктора должен быть положительным");
    }
}
