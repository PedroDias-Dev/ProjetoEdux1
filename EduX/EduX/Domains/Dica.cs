using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduX.Domains
{
    public partial class Dica
    {
        public Dica()
        {
            Curtida = new HashSet<Curtida>();
            IdDica = Guid.NewGuid();
        }

        public Guid IdDica { get; set; }
        public string Texto { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        public string UrlImagem { get; set; }
        public Guid? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
    }
}
