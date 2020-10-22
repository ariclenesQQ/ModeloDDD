using AutoMapper;
using ModeloDDD.Domain.Entities;
using ModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteVM>();
            CreateMap<Produto, ProdutoVM>();
        }

        //protected override void Configure()
        //{
        //    //MappingOperationOptions(ClienteVM, Cliente);

        //    Mapper.CreateMap<ClienteVM, Cliente>();
        //    Mapper.CreateMap<ProdutoVM, Produto>();
        //}
    }
}
