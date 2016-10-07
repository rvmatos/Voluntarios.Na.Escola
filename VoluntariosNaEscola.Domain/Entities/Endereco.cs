﻿namespace VoluntariosNaEscola.Domain.Entities
{
    public class Endereco : EntidadeBase
    {
        public string Rua { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }

    }
}
