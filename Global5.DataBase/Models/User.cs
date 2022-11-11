using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global5.DataBase.Models
{
	/// <summary>
	/// Objeto contendo os dados da tabela usuario
	/// </summary>
	[Table("user")]
	public sealed class  User
	{
		/// <summary>
		/// Atribuir/Recuperar o identificador unico do usuario
		/// </summary>
		[Key]
		[Column("id")]
		public long Id { get; set; }

		/// <summary>
		/// Atribuir/Recuperar o nome do usuario
		/// </summary>
		[Column("name")]
		[MaxLength(50)]
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Atribuir/Recuperar o email do usuario
		/// </summary>
		[Column("email")]
		[MaxLength(100)]
		public string? Email { get; set; }

		/// <summary>
		/// Atribuir/Recuperar o telefone do usuario
		/// </summary>
		[Column("telefone")]
		[MaxLength(20)]
		public string? Telefone { get; set; }
	}
}
