using System;
using System.Threading.Tasks;
using DesafioCientec.Business.Interfaces;
using DesafioCientec.Business.Models;
using DesafioCientec.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioCientec.Data.Repository
{
    public class FundacaoRepository : Repository<Fundacao>, IFundacaoRepository
    {
        public FundacaoRepository(FundacaoContext db) : base(db)
        {
        }

        public override async Task<Fundacao> ObterPorId(Guid id)
        {
            return await Db.Fundacoes.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}