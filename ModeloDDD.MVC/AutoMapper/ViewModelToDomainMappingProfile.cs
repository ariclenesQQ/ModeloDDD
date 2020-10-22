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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteVM, Cliente>();
            CreateMap<ProdutoVM, Produto>();
        }

        //protected override void Configure()
        //{
        //    //Mapper.CreateMap<Cliente, ClienteVM>();
        //    //Mapper.CreateMap<Produto, ProdutoVM>();
        //}
    }
}
