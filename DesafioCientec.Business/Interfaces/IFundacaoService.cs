using System;
using System.Threading.Tasks;
using DesafioCientec.Business.Models;

namespace DesafioCientec.Business.Interfaces
{
    public interface IFundacaoService : IDisposable
    {
        Task Adicionar(Fundacao fornecedor);
        Task Atualizar(Fundacao fornecedor);
        Task Remover(Guid id);
    }
}