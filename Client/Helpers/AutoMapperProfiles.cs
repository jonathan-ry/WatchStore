using AutoMapper;
using Client.ViewModels;

namespace Client.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<WatchViewModel, UpdateViewModel>();
            CreateMap<CreateViewModel, WatchViewModel>();
            CreateMap<UpdateViewModel, WatchViewModel>();
        }
    }
}
