using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        internal TipoUsuarioDomain tipoUsuario;

        public int idUsuario { get; set; }

        public int idTipoUsuario { get; set; }

        public string titulo { get; set; }

        public string email { get; set; }

        public string senha { get; set; }
    }
}
