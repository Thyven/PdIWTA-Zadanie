using FluentValidation;

namespace Lab4.DTO.Validators
{
    public class TestUserDTOValidator : AbstractValidator<TestUserDTO>
    {
        public TestUserDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(x => x.Phone).NotEmpty().Length(9);
        }
    }
}
