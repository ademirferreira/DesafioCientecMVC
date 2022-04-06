using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DesafioCientec.App.ViewModels;
using DesafioCientec.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DesafioCientec.Business.Models;


namespace DesafioCientec.App.Controllers
{
    public class FundacoesController : BaseController
    {
        private readonly IFundacaoRepository _fundacaoRepository;
        private readonly IFundacaoService _fundacaoService;
        private readonly IMapper _mapper;

        public FundacoesController(IFundacaoRepository fundacaoRepository,
            IFundacaoService fundacaoService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _fundacaoRepository = fundacaoRepository;
            _fundacaoService = fundacaoService;
            _mapper = mapper;
        }

        [Route("lista-de-fundacoes")]
        public async Task<IActionResult> Index(string busca = null)
        {
            var fundacoes = _mapper.Map<IEnumerable<FundacaoViewModel>>(await _fundacaoRepository.ObterTodos());
            if (!string.IsNullOrEmpty(busca))
            {
                fundacoes = fundacoes.Where(f => f.Documento.Equals(busca));
            }
            
            return View(fundacoes);
        }

        [Route("nova-fundacao")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-fundacao")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FundacaoViewModel fundacaoViewModel)
        {
            if (!ModelState.IsValid) return View(fundacaoViewModel);

            var fundacao = _mapper.Map<Fundacao>(fundacaoViewModel);
            await _fundacaoService.Adicionar(fundacao);
            if (!OperacaoValida()) return View(fundacaoViewModel);
            return RedirectToAction("Index");
        }

        [Route("editar-fundacao/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = _mapper.Map<FundacaoViewModel>(await _fundacaoRepository.ObterPorId(id));
            if (fornecedorViewModel is null) return NotFound();

            return View(fornecedorViewModel);
        }

        [Route("editar-fundacao/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FundacaoViewModel fundacaoViewModel)
        {
            if (id != fundacaoViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(fundacaoViewModel);

            var fundacao = _mapper.Map<Fundacao>(fundacaoViewModel);
            await _fundacaoService.Atualizar(fundacao);
            if (!OperacaoValida()) return View(fundacaoViewModel);

            return RedirectToAction("Index");
        }

        [Route("excluir-fundacao/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = _mapper.Map<FundacaoViewModel>(await _fundacaoRepository.ObterPorId(id));
            if (fornecedorViewModel is null) return NotFound();
            return View(fornecedorViewModel);
        }

        [Route("excluir-fundacao/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedorViewModel = _mapper.Map<FundacaoViewModel>(await _fundacaoRepository.ObterPorId(id));
            if (fornecedorViewModel is null) return NotFound();

            await _fundacaoService.Remover(id);
            TempData["Sucesso"] = "Fundação excluída com sucesso";
            return RedirectToAction("Index");
        }
    }
}
