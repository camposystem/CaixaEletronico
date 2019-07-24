using CaixaEletronico.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Repositorio
{
    public  class CaixaRepositorio
    {
        /// <summary>
        /// Lista com a movimentação.
        /// </summary>
        private List<Caixa> ListaCaixa = new List<Caixa>();
        public List<Caixa> Processar(Caixa caixa)
        {
             ListaCaixa.Add(caixa);
             return ListaCaixa;

        }


    }
}
