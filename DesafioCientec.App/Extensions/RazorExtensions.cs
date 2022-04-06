using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DesafioCientec.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataCNPJ(this RazorPage page, string documento)
        {
            return Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormataTelefone(this RazorPage page, int tamanho, string telefone)
        {
            return tamanho == 11 ? Convert.ToUInt64(telefone).ToString(@"(00)00000-0000") : Convert.ToUInt64(telefone).ToString(@"(00)0000-0000");
        }
    }
}