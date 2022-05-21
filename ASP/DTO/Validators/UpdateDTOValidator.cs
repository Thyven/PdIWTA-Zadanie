using FluentValidation;

namespace Lab4.DTO.Validators
{
    public class UpdateDTOValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateDTOValidator()
        {

            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(x => x.IsAvailable).NotEmpty();
        }
    }
}
