using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DesafioCientec.App.ViewModels;
using DesafioCientec.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioCientec.Business.Models;
using DesafioCientec.Data.Context;

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
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FundacaoViewModel>>(await _fundacaoRepository.ObterTodos()));
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
    }
}
