using CaixaEletronico.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Dominio.Entidade
{
    public class Caixa
    {
        public TipoNota tipoNota { get; set; }
        public int qteNota { get; set; }
        public int valor { get; set; }
        public TipoMovimento tipoMovimento { get; set; }
        public int saldo { get; set; }

    }
}
