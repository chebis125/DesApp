namespace Api_Image.Models
{
    public class Documento
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Ruta { get; set; }
        public IFormFile Imagen {get; set;}
    }
}
