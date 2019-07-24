using CaixaEletronico.Dominio.Entidade;
using CaixaEletronico.Dominio.Enums;
using CaixaEletronico.Dominio.Interface;
using CaixaEletronico.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Aplicacao
{
    public class CaixaAplicacao : ICaixaEletronica
    {

        private CaixaRepositorio _caixaRepositorio = new CaixaRepositorio();
        private List<Caixa> _listaCaixa = new List<Caixa>();
        private Caixa _caixa = new Caixa();
        public List<Caixa> Entrada(Caixa caixa)
        {

            _caixa = this.CalcularMovimento(_caixaRepositorio.Processar(caixa));


            Console.WriteLine("{0} notas de {1} somando o valor total de {2} reais.",
                caixa.qteNota,
                DescreverNota(caixa.tipoNota),
                _caixa.saldo);

            return _listaCaixa;
        }

        public List<Caixa> Movimento(Caixa caixa)
        {
            throw new NotImplementedException();
        }

        public List<Caixa> Saida(Caixa caixa)
        {
            _caixa = this.CalcularMovimento(_caixaRepositorio.Processar(caixa));
            Console.WriteLine("Saque efetuado no valor de {0} reais.", _caixa.valor);

            Console.WriteLine();
            foreach (KeyValuePair<string, string> item in OrdenarSaque(caixa.valor))
            {
                Console.WriteLine("{0} notas de {1} reais",
                    item.Key, item.Value);
            }


            return _listaCaixa;
        }

        private Dictionary<string, string> OrdenarSaque(int valor)
        {
            Dictionary<string, string> ordem = new Dictionary<string, string>();
            int resultado;
            while (valor > 0)
            {
                if ((valor % 50) == 0)
                {
                    resultado = valor / 50;
                    valor = (valor % 50);
                    ordem.Add(resultado.ToString(), "Cinquenta");

                }
                else if (valor > 0 && (valor % 50) <= valor)
                {
                    if ((valor % 20) == 0)
                    {
                        resultado = valor / 20;
                        valor = valor % 20;
                        ordem.Add(resultado.ToString(), "Vinte");

                    }
                    else if (valor > 0 && (valor % 20) <= valor)
                    {
                        if ((valor % 10) == 0)
                        {
                            resultado = valor / 10;
                            valor -= valor % 10;
                            ordem.Add(resultado.ToString(), "Dez");

                        }

                    }

                }
            }
            return ordem;
        }

        private Caixa CalcularMovimento(List<Caixa> listaCaixa)
        {
            foreach (var item in listaCaixa)
            {
                if (item.tipoMovimento == TipoMovimento.Entrada)
                {
                    _caixa.valor += ((int)item.tipoNota) * item.qteNota;
                    _caixa.saldo += _caixa.valor;
                }
                if (item.tipoMovimento == TipoMovimento.Saida && item.saldo > 0)
                {
                    _caixa.saldo -= item.valor;
                }
            }
            return _caixa;
        }

        private string DescreverNota(TipoNota tipo)
        {
            string nota = "";
            switch (tipo)
            {
                case TipoNota.Dez:
                    nota = "Dez";
                    break;
                case TipoNota.Vinte:
                    nota = "Vinte";
                    break;
                case TipoNota.Cinquenta:
                    nota = "Cinquenta";
                    break;

            }
            return nota;
        }
    }
}
