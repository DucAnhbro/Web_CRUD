using Microsoft.AspNetCore.Mvc;
using Web_CRUD.Models;

namespace Web_CRUD.Controllers
{
    public class EmployeController : Controller
    {

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employe model)
        {
            using (var context = new EmployessContext())
            {
                context.Employes.Add(model);
                context.SaveChanges();
            }
            string message = "Created the record successfully";

            ViewBag.Message = message;
            return View();
        }

        public ActionResult List()
        {
            using (var context = new EmployessContext())
            {
                var data = context.Employes.ToList();
                return View(data);
            }
        }
        public ActionResult Update(int Id)
        {
            using (var context = new EmployessContext())
            {
                var data = context.Employes.Where(x => x.Id == Id).SingleOrDefault();
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int Id, Employe model)
        {
            using (var context = new EmployessContext())
            {
                var data = context.Employes.FirstOrDefault(x => x.Id == Id);

                if (data != null)
                {
                    data.Id = model.Id;
                    data.Password = model.Password;
                    data.BirthDay = model.BirthDay;
                    data.Adress = model.Adress;
                    data.Email = model.Email;
                    data.Age = model.Age;
                    data.Gender = model.Gender;
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                    return View();
            }
        }
        public ActionResult Delete()
        {
            return View("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult
        Delete(int Id)
        {
            using (var context = new EmployessContext())
            {
                var data = context.Employes.FirstOrDefault(x => x.Id == Id);
                if (data != null)
                {
                    context.Employes.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                    return View();
            }
        }
    }
}
