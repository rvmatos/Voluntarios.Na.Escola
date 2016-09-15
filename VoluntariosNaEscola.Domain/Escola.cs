﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain
{
    public class Escola : EntidadeBase
    {

        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

        public Diretor Diretor { get; set; }
    }
}
