using FluentValidation;

namespace ChatApp.Entity
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public bool Validate()
        {
            var validator = new UserValidator();
            var results = validator.Validate(this);
            return results.IsValid;
        }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}