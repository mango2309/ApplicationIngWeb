using System.Globalization;

namespace ApplicationIngWeb.Models.Domain
{
    public class BlogPost
    {

        public int Id {  get; set; }
        public string Titulo { get; set; }
        public string DescripcionCorta { get; set; }
        public string Contenido { get; set; }
        public string ImageUrl { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }

    }
}
