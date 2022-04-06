using System.Collections.Generic;
using DesafioCientec.Business.Notificacoes;

namespace DesafioCientec.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}