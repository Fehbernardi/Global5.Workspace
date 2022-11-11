namespace Global5.Api.Searchs
{
	public class UserSearch
	{        
		#region Propriedades Públicas
		/// <summary>
		/// Atribuir/Recuperar o identificador unico do usuario
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Atribuir/Recuperar o nome do usuario
		/// </summary>
		public string? Name { get; set; }

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
