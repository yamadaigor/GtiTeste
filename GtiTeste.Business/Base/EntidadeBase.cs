using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtiTeste.Business.Base
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = new Guid();
        }
    }
}
