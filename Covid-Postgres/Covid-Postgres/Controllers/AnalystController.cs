using Covid_Postgres.DI.Interface;
using Covid_Postgres.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Postgres.Controllers
{
    public class AnalystController : Controller
    {
        private readonly IAnalystRepository _analystRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IPersonRepository _personRepository;
        public AnalystController(IAnalystRepository analystRepository, IPersonRepository personRepository,IActivityRepository activityRepository)
        {
            _analystRepository = analystRepository;
            _personRepository = personRepository;
            _activityRepository = activityRepository;

        }
        public IActionResult Index()
        {
            var x = new AnalystVm()
            {
                F0 = _analystRepository.QuantityOfF0(),
                F1 = _analystRepository.QuantityOfF1(),
                F2 = _analystRepository.QuantityOfF2(),
                F3 = _analystRepository.QuantityOfF3(),
                F4 = 0,
                Output = _analystRepository.GetExport().Count(),
                Input = _personRepository.GetAllPerson().Count(),
                Process =  _analystRepository.GetTreatment().Count(),
                Died = _analystRepository.GetDied().Count(),
            };
            return View(x);
        }

        public IActionResult AnalystPerDay(DateTime request)
        {
            ViewBag.Date = request;
            var x = new AnalystVm()
            {
                F0 = _analystRepository.QuantityOfF0PerDay(request),
                F1 = _analystRepository.QuantityOfF1PerDay(request),
                F2 = _analystRepository.QuantityOfF2PerDay(request),
                F3 = _analystRepository.QuantityOfF3PerDay(request),
                F4 = 0,
                Output = _analystRepository.GetExportDay(request).Count(),
                Input = _analystRepository.GetPeopleDay(request).Count(),
                Process = _analystRepository.GetTreatmentDay(request).Count(),
                Died = _analystRepository.GetDiedDay(request).Count()
            };
            if(x.F0 ==0 && x.F1 == 0 && x.F2 == 0 && x.F3 == 0 && x.F4==0)
            {
                ViewBag.Notice = "Không có trương hợp mới";
            }
            return View(x);
        }

        public IActionResult ActivityAction()
        {
            var ac = _activityRepository.GetAllActi();
            return View(ac);
        }

        public IActionResult GetExport()
        {
            var x = _analystRepository.GetExport();
            return View(x);
        }

        public IActionResult GetTreatment()
        {
            var x = _analystRepository.GetTreatment();
            return View(x);
        }

        public IActionResult GetDied()
        {
            var x = _analystRepository.GetDied();
            return View(x);
        }

        public IActionResult GetPeople()
        {
            var x = _analystRepository.GetPeople();
            return View(x);
        }

        public IActionResult GetExportDay(DateTime request)
        {
            ViewBag.Date = request;
            var x = _analystRepository.GetExportDay(request);
            return View(x);
        }

        public IActionResult GetTreatmentDay(DateTime request)
        {
            ViewBag.Date = request;
            var x = _analystRepository.GetTreatmentDay(request);
            return View(x);
        }

        public IActionResult GetDiedDay(DateTime request)
        {
            ViewBag.Date = request;
            var x = _analystRepository.GetDiedDay(request);
            return View(x);
        }

        public IActionResult GetPeopleDay(DateTime request)
        {
            ViewBag.Date = request;
            var x = _analystRepository.GetPeopleDay(request);
            return View(x);
        }

    }
}
