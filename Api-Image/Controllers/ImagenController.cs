using Api_Image.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;

namespace Api_Image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        private readonly string _rutaServidor;
        private readonly string _cadenaSql;

        public ImagenController(IConfiguration config)
        {
            _rutaServidor = config.GetSection("Configuracion").GetSection("RutaServidor").Value;
            _cadenaSql = config.GetConnectionString("CadenaSQL");
        }

        [HttpPost]
        [Route("Subir")]
        public IActionResult Subir([FromForm] Documento request)
        {
            string rutaDocumento = Path.Combine(_rutaServidor, request.Imagen.FileName);
            try
            {
                using (FileStream newFile = System.IO.File.Create(rutaDocumento))
                {
                    request.Imagen.CopyTo(newFile);
                    newFile.Flush();
                }
                using (var conexion = new SqlConnection(_cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_guardar_documento", conexion);
                    cmd.Parameters.AddWithValue("nombre", request.Name);
                    cmd.Parameters.AddWithValue("ruta", rutaDocumento);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Imagen Guardada" });
            }

            catch(Exception error)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = error.Message });
            }
        }
    }
}
