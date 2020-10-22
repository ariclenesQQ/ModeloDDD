using ModeloDDD.Application.Interface;
using ModeloDDD.Domain.Entities;
using ModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;
        public ClienteAppService(IClienteService clienteService) : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        }
    }
}
