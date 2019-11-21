using System;

namespace Locadora.Domain
{
    public class Filme
    {
        public int Id {get; set;}
        public string nomeFilme {get; set;}
        public DateTime dataLancamento {get;set;}
        public Diretor Diretor {get;}

    }
}