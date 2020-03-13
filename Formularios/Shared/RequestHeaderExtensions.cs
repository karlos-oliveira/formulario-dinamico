using Microsoft.AspNetCore.Http;
using System;

namespace System
{
    public static class RequestHeaderExtensions
    {
        public static Guid ObterIdConta(this HttpRequest request)
        {
            var idConta = request.Headers?["idAccount"];
            if (!String.IsNullOrEmpty(idConta))
                return new Guid(idConta);
            else throw new ArgumentNullException("O a propriedade do header não pode ser nulo");
        }
        public static Guid ObterIdUsuario(this HttpRequest request)
        {
            var sub = request.Headers?["sub"];
            if (!String.IsNullOrEmpty(sub))
                return new Guid(sub);
            else throw new ArgumentNullException("O a propriedade do header não pode ser nulo");
        }
        public static string ObterConta(this HttpRequest request)
        {
            var conta = request.Headers?["account"];
            if (!String.IsNullOrEmpty(conta))
                return conta;
            else throw new ArgumentNullException("O a propriedade do header não pode ser nulo");
        }
    }
}