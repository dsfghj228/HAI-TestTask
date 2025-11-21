using Back.MediatR.Commands;
using FluentValidation;

namespace Back.Validation;

public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
{
    public CreateDoctorCommandValidator()
    {
        RuleFor(d => d.FirstName)
            .NotEmpty().WithMessage("Имя обязательно.")
            .MinimumLength(2).WithMessage("Имя слишком короткое.")
            .MaximumLength(50).WithMessage("Имя слишком длинное.")
            .Matches("^[A-Za-zА-Яа-яЁё'-]+$").WithMessage("Имя содержит недопустимые символы.");
        
        RuleFor(d => d.LastName)
            .NotEmpty().WithMessage("Фамилия обязательно.")
            .MinimumLength(2).WithMessage("Фамилия слишком короткое.")
            .MaximumLength(50).WithMessage("Фамилия слишком длинное.")
            .Matches("^[A-Za-zА-Яа-яЁё'-]+$").WithMessage("Фамилия содержит недопустимые символы.");
        
        RuleFor(d => d.Specialization)
            .NotEmpty().WithMessage("Специализация обязательна.")
            .MinimumLength(3)
            .MaximumLength(100)
            .Matches("^[A-Za-zА-Яа-яЁё\\s-]+$").WithMessage("Название специализации содержит недопустимые символы.");
        
        RuleFor(d => d.Phone)
            .NotEmpty().WithMessage("Телефон обязателен.")
            .Matches("^\\+?[0-9]{10,15}$")
            .WithMessage("Некорректный номер телефона.");
        
        RuleFor(d => d.Email)
            .NotEmpty().WithMessage("Email обязателен.")
            .EmailAddress().WithMessage("Некорректный email.")
            .MaximumLength(100);
        
        RuleFor(d => d.ExperienceYears)
            .GreaterThanOrEqualTo(0).WithMessage("Опыт не может быть отрицательным.")
            .LessThanOrEqualTo(60).WithMessage("Опыт слишком большой.");
    }
}