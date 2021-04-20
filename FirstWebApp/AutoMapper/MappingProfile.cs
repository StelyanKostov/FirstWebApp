using AutoMapper;
using FirstWebApp.Data;
using FirstWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Smartphone, SmartphoneViewModel>();
            CreateMap<Data.Battery, ViewModels.Battery>();
            CreateMap<Data.Body, ViewModels.Body>();
            CreateMap<Data.Connect, ViewModels.Connect>();
            CreateMap<Data.Date, ViewModels.Date>();
            CreateMap<Data.Display, ViewModels.Display>();
            CreateMap<Data.Features, ViewModels.Features>();
            CreateMap<Data.Hardware, ViewModels.Hardware>();
            CreateMap<Data.Image, ViewModels.Image>();
            CreateMap<Data.MainCamera, ViewModels.MainCamera>();
            CreateMap<Data.Memory, ViewModels.Memory>();
            CreateMap<Data.Network, ViewModels.Network>();
            CreateMap<Data.SelfieCamera, ViewModels.SelfieCamera>();
            CreateMap<Data.Sound, ViewModels.Sound>();
            CreateMap<Data.View, ViewModels.View>();


            CreateMap<SmartphoneViewModel, Smartphone>();
            CreateMap<ViewModels.Battery, Data.Battery>();
            CreateMap<ViewModels.Body, Data.Body>();
            CreateMap<ViewModels.Connect, Data.Connect>();
            CreateMap<ViewModels.Date, Data.Date>();
            CreateMap<ViewModels.Display, Data.Display>();
            CreateMap<ViewModels.Features, Data.Features>();
            CreateMap<ViewModels.Hardware, Data.Hardware>();
            CreateMap<ViewModels.Image, Data.Image>();
            CreateMap<ViewModels.MainCamera, Data.MainCamera>();
            CreateMap<ViewModels.Memory, Data.Memory>();
            CreateMap<ViewModels.Network, Data.Network>();
            CreateMap<ViewModels.SelfieCamera, Data.SelfieCamera>();
            CreateMap<ViewModels.Sound, Data.Sound>();
            CreateMap<ViewModels.View, Data.View>();
        }
    }
}
