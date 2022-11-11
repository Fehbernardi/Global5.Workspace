using FluentValidation;
using Global5.ViewModels;

namespace Global5.ViewModels.Validators
{
    /// <summary>
    /// Objeto responsável pela validação dos usuários.
    /// </summary>
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        #region Construtores
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public UserValidator()
        {
            RuleFor( x => x.Name ).NotEmpty();
            RuleFor( x => x.Name ).MaximumLength( 10 );
            
            RuleFor( x => x.Email ).EmailAddress();
            RuleFor( x => x.Email ).MaximumLength( 10 );
        }
        #endregion
    }
}