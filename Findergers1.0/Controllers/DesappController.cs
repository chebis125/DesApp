using Findergers1._0.Models;
using Findergers1._0.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Findergers1._0.Controllers
{
    public class DesappController : Controller
    {
        public IActionResult Index()
        {
            List<ListMissing> lst;
            using (DesappDBContext db = new DesappDBContext())
            {
                lst = (from d in db.Missings
                       select new ListMissing
                       {
                           Id_Missing = d.IdMissing,
                           Name_Missing = d.NameMissing,
                           Age_Missing = d.AgeMissing,
                           Description_Missing = d.DescriptionMissing,
                           Date_Missing = d.DateMissing,
                           Lastlocation_Missing = d.LastlocationMissing,

                       }).ToList();

            }
            return View(lst);
        }
        //CREAR 
        public ActionResult NewMissing()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMissing(Missing model)
        {
            if (ModelState.IsValid)
            {
                using (DesappDBContext db = new DesappDBContext())
                {
                    var oDesa = new Missing();

                    oDesa.IdMissing = model.IdMissing;
                    oDesa.NameMissing = model.NameMissing;
                    oDesa.AgeMissing = model.AgeMissing;
                    oDesa.DescriptionMissing = model.DescriptionMissing;
                    oDesa.DateMissing = model.DateMissing;
                    oDesa.LastlocationMissing = model.LastlocationMissing;

                    db.Missings.Add(oDesa);
                    db.SaveChanges();

                }
                return Redirect("~/Desapp/Index");
            }
            return View(model);
        }
        //Editar

        public ActionResult Edit(int ID)
        {
            Missing model = new Missing();
            using (DesappDBContext db = new DesappDBContext())
            {
                var oMis = db.Missings.Find(ID);
                model.IdMissing = oMis.IdMissing;
                model.NameMissing = oMis.NameMissing;
                model.AgeMissing = oMis.AgeMissing;
                model.DescriptionMissing = oMis.DescriptionMissing;
                model.DateMissing = oMis.DateMissing;
                model.LastlocationMissing = oMis.LastlocationMissing;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Missing model)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    using (DesappDBContext db = new DesappDBContext())
                    {
                        var oDesa = db.Missings.Find(model.IdMissing);

                        oDesa.IdMissing = model.IdMissing;
                        oDesa.NameMissing = model.NameMissing;
                        oDesa.AgeMissing = model.AgeMissing;
                        oDesa.DescriptionMissing = model.DescriptionMissing;
                        oDesa.DateMissing = model.DateMissing;
                        oDesa.LastlocationMissing = model.LastlocationMissing;
                        db.Entry(oDesa).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Desapp/Index");
                }
                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //ELIMINAR
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            using (DesappDBContext db = new DesappDBContext())
            {
                var oDesa = db.Missings.Find(Id);
                db.Missings.Remove(oDesa);
                db.SaveChanges();

            }
            return Redirect("~/Desapp/Index");
        }


    }
}

