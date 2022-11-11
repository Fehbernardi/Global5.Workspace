using AutoMapper;
using Global5.DataBase.Models;
using Global5.ViewModels;

namespace Global5.Api.Mappings
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			
            #region User
            CreateMap<User , UserViewModel>();
            #endregion

		}
	}
}
