using FluentValidation;
using TodoApp.Domain.Dtos;

namespace TodoApp.Api.Validators
{
    public class TodoValidator : AbstractValidator<TodoDTO>
    {
        public TodoValidator()
        {
            RuleFor(x => x.Text).NotNull().WithMessage("Text field is required.");
        }
    }
}
