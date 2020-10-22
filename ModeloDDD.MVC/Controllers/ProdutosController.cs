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
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        private readonly IMapper _mapper = AutoMapper.AutoMapperConfig.Mapper;

        public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            var produtoViewModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoVM>>(_produtoApp.GetAll());
            return View(produtoViewModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoVM>(produto);

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome"); 
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoVM produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoVM, Produto>(produto);
                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoVM>(produto);

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoVM produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoVM, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoVM>(produto);

            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        }
    }
}