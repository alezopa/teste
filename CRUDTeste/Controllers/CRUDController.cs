using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CRUDTeste.Controllers
{
    public class CRUDController : Controller
    {
     
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult create(Usuario model)
        {
            using(var context = new demoCRUDEntities()) 
            {
                context.Usuario.Add(model); 
                context.SaveChanges(); 
            }
            string message = "Usuário criado com sucesso!";
            ViewBag.Message = message;    
            return View(); 
        }

        [HttpGet] 
        public ActionResult Read()
        {
            using(var context = new demoCRUDEntities())
            {
                var data = context.Usuario.ToList(); 
                return View(data);
            }
            
        }


        public ActionResult Update(int usuarioId) 
        {
            using(var context = new demoCRUDEntities())
            {
                var data = context.Usuario.Where(x => x.UsuarioId == usuarioId).SingleOrDefault();
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Update(int usuarioId, Usuario model)
        {
            using(var context = new demoCRUDEntities())
            {
                var data = context.Usuario.FirstOrDefault(x => x.UsuarioId == usuarioId); 
                if (data != null) 
                {
                    data.Nome = model.Nome;
                    data.Endereco = model.Endereco;
                    data.Telefone = model.Telefone;
                    data.Email = model.Email;
                    data.DataCadastro = model.DataCadastro;
                    context.SaveChanges();
                    return RedirectToAction("Read"); 
                }
                else
                    return View();
            }
        }

        public ActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int usuarioId)
        {
            using(var context = new demoCRUDEntities())
            {
                var data = context.Usuario.FirstOrDefault(x => x.UsuarioId == usuarioId);
                if (data != null)
                {
                    context.Usuario.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }

        public ActionResult Details(int usuarioId) 
        {
            using (var context = new demoCRUDEntities())
            {
                var data = context.Usuario.Where(x => x.UsuarioId == usuarioId).SingleOrDefault();
  

                
                return View(data);
            }
        }
    }
}

// Just a small change