using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace PresentationLayer.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            HospitalEntities db = new HospitalEntities();
            List<Patient> pList = db.Patients.ToList();
            return View(pList);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View(new HospitalEntities().Patients.First(q => q.PatientId == id));
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            HospitalEntities db = new HospitalEntities();
            Patient p = db.Patients.Where(q => q.PatientId.Equals(id)).FirstOrDefault();
            if (p != null)
            {
                db.Patients.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
