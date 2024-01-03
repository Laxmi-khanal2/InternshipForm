using InternshipForm.Data;
using InternshipForm.Models;
using InternshipForm.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InternshipForm.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDBContext _context;
        public FormController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreatePost ()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(InternshipFormViewModel model)
        {
            if (ModelState.IsValid)
            {
               var personalInfo = _context.PersonalInformation.Add(model.PersonalInformation);
                _context.SaveChanges();
            //    var PersonalId = personalInfo.Entity.Id;
            //    model.Education.PersonalID = PersonalId;
            //    model.GuardianDetails.PersonalID = PersonalId;
            //    model.References.PersonalID = PersonalId;
            //    SaveEducation(model.Education);
            }
            return View(model);
        }

        private Education SaveEducation(Education model)
        {
            _context.Education.Add(model);
            _context.SaveChanges();
            return model;
        }
        private Education SaveGuardian(Education model)
        {
            _context.Education.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
