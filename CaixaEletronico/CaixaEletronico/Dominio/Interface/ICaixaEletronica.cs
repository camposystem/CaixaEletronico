using CaixaEletronico.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Dominio.Interface
{
    public interface ICaixaEletronica
    {
  
        /// <summary>
        /// Carrega notas no Caixa Eletronico
        /// </summary>
        /// <param name="caixa"></param>
        /// <returns></returns>
        List<Caixa> Entrada(Caixa caixa);
        /// <summary>
        /// Saque de notas no Caixa Eletronica
        /// </summary>
        /// <param name="caixa"></param>
        /// <returns></returns>
        List<Caixa> Saida(Caixa caixa);
        /// <summary>
        /// Relatorio de movimentação no Caixa Eletronico.
        /// </summary>
        /// <param name="caixa"></param>
        /// <returns></returns>
        List<Caixa> Movimento(Caixa caixa);

    }
}
