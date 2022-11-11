using AutoMapper;
using Global5.Api.Searchs;
using Global5.DataBase;
using Global5.DataBase.Models;
using Global5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Global5.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class userController : ControllerBase
	{
		
        /// <summary>
        /// Recuperar objeto contendo o contexto de acesso ao banco de dados.
        /// </summary>
        protected ApplicationContext ApplicationContext{ get; }

        /// <summary>
        /// Recuperar objeto responsável pelo mapeamento dos objetos.
        /// </summary>
        protected IMapper Mapper{ get; }

		public userController( IMapper mapper , ApplicationContext applicationContext)
		{
            ApplicationContext = applicationContext ?? throw new ArgumentNullException( nameof(applicationContext) );
            Mapper = mapper ?? throw new ArgumentNullException( nameof(mapper) );
		}

		/// <summary>
		/// Adicionar um usuario
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<UserViewModel> Add( UserViewModel user)
		{
			var newItem = Mapper.Map<User>( user );

            await ApplicationContext.Users.AddAsync( newItem ).ConfigureAwait( false );
            await ApplicationContext.SaveChangesAsync().ConfigureAwait( false );

			return Mapper.Map<UserViewModel>( newItem );
		}

		/// <summary>
		/// buscar usuarios
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public List<UserViewModel> Get( [FromQuery] UserSearch search )
		{
			 var users = ApplicationContext.Users
				.AsNoTracking()
				.AsQueryable();

			 #region Aplicar filtro

            if( search?.Id != null ) users = users.Where( x => x.Id == search.Id.Value );

            if( !string.IsNullOrWhiteSpace( search?.Name ))
            {
                users = users.Where( x => x.Name == search.Name);
            }
			
            if( !string.IsNullOrWhiteSpace( search?.Email ))
            {
                users = users.Where( x => x.Email == search.Email);
            }
			
            if( !string.IsNullOrWhiteSpace( search?.Telefone ))
            {
                users = users.Where( x => x.Telefone == search.Telefone);
            }

            #endregion

			return Mapper.Map<List<UserViewModel>>( users );
		}
		
		/// <summary>
		/// Atualizar determinado usuario
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="user"></param>
		/// <returns></returns>
        [HttpPut( "{userId:long}" )]
		public async Task<bool> Update(long userId, User user)
		{
			// caso o usuario não exista
			if (!Get(new UserSearch { Id = userId }).Any()) return false;

			user.Id= userId;

			var result = ApplicationContext.Update<User>( user ).State == EntityState.Modified;
            await ApplicationContext.SaveChangesAsync().ConfigureAwait(false);

            return result;
		}

		/// <summary>
		/// Excluir um usuario
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
        [HttpDelete( "{userId:long}" )]
		public async Task<bool> Del(long userId)
		{
			// caso o usuario não exista
			if (!Get(new UserSearch { Id = userId }).Any()) return false;

			var result = ApplicationContext.Remove(ApplicationContext.Users.Single( x => x.Id == userId )).State == EntityState.Deleted;
                
            await ApplicationContext.SaveChangesAsync().ConfigureAwait( false );
			return result;
		}
	}
}