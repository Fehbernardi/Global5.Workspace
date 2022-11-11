using AutoMapper;
using Global5.DataBase.Models;
using Global5.ViewModels;

namespace Global5.Api.Mappings
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			
            #region UserViewModel
            CreateMap<UserViewModel , User>();
            #endregion
		}
	}
}
