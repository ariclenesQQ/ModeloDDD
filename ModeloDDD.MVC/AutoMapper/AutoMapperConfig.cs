using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void RegisterMappings()
        {
            var _mapper = new MapperConfiguration((mapper) =>
            {
                mapper.AddProfile<DomainToViewModelMappingProfile>();
                mapper.AddProfile<ViewModelToDomainMappingProfile>();
            });
            Mapper = _mapper.CreateMapper();

            // return new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new DomainToViewModelMappingProfile());
            //    cfg.AddProfile(new ViewModelToDomainMappingProfile());
            //});

            //Mapper.Initialize(x =>
            //    {
            //        x.AddProfile<DomainToViewModelMappingProfile>();
            //        x.AddProfile<ViewModelToDomainMappingProfile>();
            //    });
        }

    }
}
