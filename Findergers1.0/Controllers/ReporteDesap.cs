using Findergers1._0.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Findergers1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class ReporteDesap : ControllerBase
    {
        private readonly DesappContext _context;

        public ReporteDesap(DesappContext context)
        {
            _context = context;
        }
        [HttpGet]
        [EnableCors("permitir")]
        //api/ReporteDesap
        public ActionResult Get()
        {
            using (Models.DesappContext db = new Models.DesappContext())
            {
                var lst = (from d in db.Missings select d).ToList();
                return Ok(lst);
            }
        }
        [HttpPost]
        [EnableCors("permitir")]
        public ActionResult Post([FromBody] Models.Request.ReportarDesapRequest model)
        {
            using (Models.DesappContext db = new Models.DesappContext())
            {
                Models.Missing oDesaparecido = new Models.Missing();
                
                oDesaparecido.NameMissing = model.name;
                oDesaparecido.AgeMissing = model.age;
                oDesaparecido.DescriptionMissing = model.description;
                oDesaparecido.DateMissing = model.disappDate;
                
                db.Missings.Add(oDesaparecido);
                db.SaveChanges();
            }
            return Ok();

        }
        [HttpPut]
        [EnableCors("permitir")]
        public ActionResult Put([FromBody] Models.Request.ReportDesapEditRequest model)
        {
            using (Models.DesappContext db = new Models.DesappContext())
            {
                Models.Missing oDesaparecido = db.Missings.Find(model.id);

                oDesaparecido.NameMissing = model.name;
                oDesaparecido.AgeMissing = model.age;
                oDesaparecido.DescriptionMissing = model.description;
                oDesaparecido.DateMissing = model.disappDate;
               
                db.Entry(oDesaparecido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok();

        }

        [HttpDelete("{id}")]
        [EnableCors("permitir")]
        public async Task<IActionResult> DeleteDesaparecido(int id)
        {
            var desaparecido = await _context.Missings.FindAsync(id);
            if (desaparecido == null)
            {
                return NotFound();
            }

            _context.Missings.Remove(desaparecido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
