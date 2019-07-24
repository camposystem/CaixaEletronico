using CaixaEletronico.Aplicacao;
using CaixaEletronico.Dominio.Entidade;
using CaixaEletronico.Dominio.Enums;
using CaixaEletronico.Dominio.Interface;
using System;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
         ICaixaEletronica _caixaEletronica = new CaixaAplicacao();
   
        var caixaEntrada = new Caixa()
            {
                tipoNota = TipoNota.Dez,
                tipoMovimento = TipoMovimento.Entrada,
                qteNota = 5,
                saldo = 0,
                valor = 0
            };
            _caixaEletronica.Entrada(caixaEntrada);


            var caixaSaida = new Caixa()
            {
                tipoNota = 0,
                tipoMovimento = TipoMovimento.Saida,
                qteNota = 0,
                saldo = 0,
                valor = 50
            };
            _caixaEletronica.Saida(caixaSaida);

            Console.ReadKey();


        }
    }
}
