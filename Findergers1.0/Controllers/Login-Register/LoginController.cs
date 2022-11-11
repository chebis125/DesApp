using Findergers1._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Findergers1._0.Controllers.Login_Register
{
    public class LoginController : Controller
    {

        string urlDomain = "http://DesApp.somee.com";

        [HttpGet]
        public ActionResult Login()
        {
            Models.IniciarSesion model = new Models.IniciarSesion();

            ViewBag.Login = model;
            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            Models.Register model = new Models.Register();
            ViewBag.Register = model;
            return View(model);
        }

        [HttpGet]
        public ActionResult StarRecovery()
        {
            Models.Recovery model = new Models.Recovery();
            return View(model);
        }

        [HttpGet]
        public ActionResult Recovery(string token)
        {
            Models.RecoveryPass model = new Models.RecoveryPass();
            model.token = token;
            using (DesappDBContext db = new DesappDBContext())
            {
                if (model.token == null || model.token.Trim().Equals(""))
                {
                    return View();
                }
                var oUser = db.LoginAndRegisters.Where(d => d.Token == model.token).FirstOrDefault();
                if (oUser == null)
                {
                    ViewBag.Error = "Token Invalido";
                    return View("Login");
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult StarRecovery(Models.Recovery model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                string token = GetSha256(Guid.NewGuid().ToString());
                using (DesappDBContext db = new DesappDBContext())
                {
                    var oUser = db.LoginAndRegisters.Where(d => d.Email == model.Email).FirstOrDefault();
                    if (oUser != null)
                    {
                        oUser.Token = token;
                        db.Entry(oUser).State = EntityState.Modified;
                        db.SaveChanges();

                        //Send Email
                        SendEmail(oUser.Email, token);
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Recovery(Models.RecoveryPass model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);

                }
                using (DesappDBContext db = new DesappDBContext())
                {
                    var oUser = db.LoginAndRegisters.Where(d => d.Token == model.token).FirstOrDefault();
                    if (oUser != null)
                    {

                        oUser.Password = GetSha256(model.Password);
                        oUser.Token = null;
                        db.Entry(oUser).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Models.LoginAndRegister model)
        {
            using (DesappDBContext db = new DesappDBContext())
            {
                string username = model.Username;
                string pass = GetSha256(model.Password);


                if ((from d in db.LoginAndRegisters where d.Username == username && d.Password == pass select d).Count() > 0)
                {
                    return Redirect("~/Home/Index");
                }
            }
            return View();

        }
        

        [HttpPost]
        public ActionResult Register(Models.Register model)
        {
            using (DesappDBContext db = new DesappDBContext())
            {
                var oPeople = new LoginAndRegister();
                var frist_name = model.FristName;
                oPeople.FristName = model.FristName;
                oPeople.LastName = model.LastName;
                oPeople.Username = model.Username;
                oPeople.Password = GetSha256(model.Password);
                oPeople.Email = model.Email;
                oPeople.Phone = model.Phone;
                db.LoginAndRegisters.Add(oPeople);
                db.SaveChanges();
                db.SaveChanges();
            }
            return Redirect("Login");
        }

        #region HELPERS
        private string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private void SendEmail(string EmailDestino, string token)
        {
            string EmailOrigen = "desapprecovery@gmail.com";
            string Contraseña = "tcygqcmsiaqwotfp";
            string url = urlDomain + "/Login/Recovery/?token=" + token;
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperación de contraseña", "<p>Por favor ingrese al siguiente link para restablecer su contraseña:</p><br>" + "<a href='" + url + "'>Click para recuperar</a>");
            oMailMessage.IsBodyHtml = true;
            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            // oSmtpClient. Host = "smtp.gmail.com";
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();


        }



        #endregion
    }



}

