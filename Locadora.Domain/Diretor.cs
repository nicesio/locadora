using System.Collections.Generic;

namespace Locadora.Domain
{
    public class Diretor
    {
        public int Id {get;set;}
        public string nomeDiretor {get;set;}
        public List <Filme> Filme {get;set;}
        
    }
}