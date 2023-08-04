using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Extensions
{
    public static class RepositoryExtensions
    {
        public static ResultPage<T> ToPages<T>(this List<T> Entidades, int page = 1, int qtd = 20)
        {
            var qtdPages = Entidades.Count / qtd;
            int vr = Entidades.Count;
            int result = 0;
            decimal res = Math.DivRem(vr, qtd, out result);
            if (result > 0)
            {
                qtdPages++;
            }

            var inicio = (page - 1) * qtd;
            ResultPage<T> retorno = new ResultPage<T>();
            retorno.Items = Entidades.Skip(inicio).Take(qtd).ToList();
            retorno.Page = page;
            retorno.TotalPages = qtdPages;
            retorno.TotalItems = Entidades.Count;
            return retorno;
        }
    }
}
