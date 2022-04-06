using System;
using System.Linq;
using System.Threading.Tasks;
using DesafioCientec.Business.Interfaces;
using DesafioCientec.Business.Models;

namespace DesafioCientec.Business.Services
{
    public class FundacaoService : BaseService, IFundacaoService
    {
        private readonly IFundacaoRepository _fundacaoRepository;

        public FundacaoService(IFundacaoRepository fundacaoRepository, INotificador notificador) : base(notificador)
        {
            _fundacaoRepository = fundacaoRepository;
        }

        public async Task Adicionar(Fundacao fundacao)
        {
            if (_fundacaoRepository.Buscar(f => f.Documento == fundacao.Documento).Result.Any())
            {
                Notificar("Já existe uma fundação com esse documento");
                return;
            }

            await _fundacaoRepository.Adicionar(fundacao);
        }

        public async Task Atualizar(Fundacao fundacao)
        {
            if (_fundacaoRepository.Buscar(f => f.Documento == fundacao.Documento && f.Id != fundacao.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }
            await _fundacaoRepository.Atualizar(fundacao);
        }

        public async Task Remover(Guid id)
        {
            await _fundacaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _fundacaoRepository?.Dispose();
        }
    }
}