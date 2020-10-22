using AutoMapper;
using ModeloDDD.Application.Interface;
using ModeloDDD.Domain.Entities;
using ModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IMapper _mapper = AutoMapper.AutoMapperConfig.Mapper;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteVM>>(_clienteApp.GetAll());
            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteVM>>(_clienteApp.ObterClientesEspeciais());
            return View(clienteViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteVM>(cliente);

            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteVM cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = _mapper.Map<ClienteVM, Cliente>(cliente);
                _clienteApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteVM>(cliente);

            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteVM cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = _mapper.Map<ClienteVM, Cliente>(cliente);
                _clienteApp.Update(clienteDomain);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteVM>(cliente);

            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}
