using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public static class Validacoes
    {
        //Se o texto for nulo caíra em uma exception.
        public static string ValidaStringVazia(this string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? throw new Exception("Propriedade deve estar preenchida."): texto;
        }
    }
}
