using System.ComponentModel.DataAnnotations;

namespace Global5.ViewModels
{
    /// <summary>
    /// Objeto representando os usuários.
    /// </summary>
    public sealed class UserViewModel
    {
        #region Propriedades Públicas
		/// <summary>
		/// Atribuir/Recuperar o identificador unico do usuario
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Atribuir/Recuperar o nome do usuario
		/// </summary>
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Atribuir/Recuperar o email do usuario
		/// </summary>
		public string? Email { get; set; }

		/// <summary>
		/// Atribuir/Recuperar o telefone do usuario
		/// </summary>
		public string? Telefone { get; set; }
        #endregion
    }
}