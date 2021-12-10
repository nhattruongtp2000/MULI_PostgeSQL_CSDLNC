using Covid_Postgres.DI.Interface;
using Covid_Postgres.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Covid_Postgres.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonRepository _ipersonRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly IAnalystRepository _analystRepository;
        private readonly IActivityRepository _activityRepository;
        public HomeController(ILogger<HomeController> logger,IPersonRepository ipersonRepository,IPlaceRepository placeRepository,IAnalystRepository analystRepository,IActivityRepository activityRepository)
        {
            _logger = logger;
            _ipersonRepository = ipersonRepository;
            _placeRepository = placeRepository;
            _analystRepository = analystRepository;
            _activityRepository = activityRepository;
        }

        public IActionResult Index(int PersonId)
        {
            if (PersonId == 0)
                PersonId = 1;
            var Home = new HomeVm();
            var people = _ipersonRepository.GetAllPerson();
            var person = _ipersonRepository.GetPerson(PersonId);
            var place = _placeRepository.GetAllPlace();
            var related = _ipersonRepository.GetRelatedPerson(PersonId);
            Home.People = people;
            Home.Person = person;
            Home.Place = place;
            Home.RelatedPerson = related;
            ViewBag.CountAll = _ipersonRepository.GetAllPerson().Count();
            ViewBag.CountExport = _analystRepository.GetExport().Count();
            ViewBag.Process = _analystRepository.GetTreatment().Count();
            ViewBag.ProcessToDay = _analystRepository.GetTreatmentDay(DateTime.Now).Count();
            ViewBag.AllToday = _analystRepository.GetPeopleDay(DateTime.Now).Count;
            ViewBag.ExportToday = _analystRepository.GetExportDay(DateTime.Now).Count();
            ViewBag.Died = _analystRepository.GetDied().Count();
            ViewBag.DiedToDay = _analystRepository.GetDiedDay(DateTime.Now).Count();
            

            return View(Home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }     


        public IActionResult GetPersonDetail(int PersonId)
        {
            if (TempData["StatusChange"] != null)
            {
                ViewBag.StatusChange = TempData["StatusChange"];
            }
            if (TempData["DiedPerson"] != null)
            {
                ViewBag.DiedPerson = TempData["DiedPerson"];
            }
            if (TempData["ExportPerson"] != null)
            {
                ViewBag.ExportPerson = TempData["ExportPerson"];
            }

           

            var x = _ipersonRepository.GetPerson(PersonId);
            var place = _placeRepository.GetPlace(x.PlaceOfTreatmentId);
            ViewBag.Place = place.PlaceName;
            var liststatus = new List<SelectListItem>();
            for(int i = 0; i < x.PersonStatus; i++)
            {
                var status = new SelectListItem()
                {
                    Value = i.ToString(),
                    Text = "F" + i
                };
                liststatus.Add(status);
            }
            ViewBag.Status = liststatus;
            ViewBag.StatusF = "F" + x.PersonStatus;
            if (x.ChangeStatus != null)
            {
                ViewBag.ChangeStatus = "F"+x.ChangeStatus;
            }
            

            return View(x);
        }


        public IActionResult DeletePerson(int personid)
        {
            _ipersonRepository.DeletePerson(personid);
            TempData["DeletePerson"] = "Xóa bệnh nhân thành công";
            var name = User.Identity.Name;
            _activityRepository.AddActivity(name, "đã xóa bênh nhân số "+personid);
            return RedirectToAction("GetAllListPerson");
        }

        public IActionResult DeletePlace(int placeid)
        {
            _placeRepository.Delete(placeid);
            TempData["DeletePlace"] = "Xóa nơi điều trị "+placeid+ " thành công";
            return RedirectToAction("GetAllPlace");
        }

        public IActionResult EditPlace(int placeid)
        {
            var x = _placeRepository.GetPlace(placeid);
            return View(x);
        }

        [HttpPost]
        public IActionResult EditPlace(PlaceOfTreatment request)
        {
            TempData["EditPlace"] = "Chỉnh sửa thông tin nơi điều trị số" + request.PlaceId + "thành công"; 
            _placeRepository.EditPlace(request);
            return RedirectToAction("GetAllPlace");
        }


        [HttpPost]
        public IActionResult GetPerson(int PersonId)
            {

            var Home = new HomeVm();
            var place = _placeRepository.GetAllPlace();
            var people = _ipersonRepository.GetAllPerson();
            var person = _ipersonRepository.GetPerson(PersonId);
            var related = _ipersonRepository.GetRelatedPerson(PersonId);
            Home.People = people;
            Home.Person = person;
            Home.Place = place;
            Home.RelatedPerson = related;
            return View(Home);
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult AddPerson()
        {
            var listid= _ipersonRepository.GetListPersonId();
            ViewBag.Listid = listid.Select(x => new SelectListItem() { 
            Text=x.ToString(),
            Value=x.ToString()           
            });

            var listplace = _placeRepository.GetAllPlace();
            ViewBag.ListPlace = listplace.Select(x => new SelectListItem()
            {
                Text = x.PlaceName,
                Value = x.PlaceId.ToString()
            });

            var l = new List<SelectListItem>();
            var li = new SelectListItem()
            {
                Value = "1",
                Text = "Nữ"
            };
            l.Add(li);
            var li2 = new SelectListItem()
            {
                Value="2",
                Text="Nam"
            };
            l.Add(li2);
            ViewBag.ListGender = l;
    
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person request)
        {
            _ipersonRepository.AddPerson(request);
            var name = User.Identity.Name;
            TempData["AddPerson"] = "Thêm bệnh nhân mới thành công";
            _activityRepository.AddActivity(name, "đã thêm bệnh nhân mới");

            return RedirectToAction("GetAllListPerson");
        }

        public IActionResult AddPlace()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlace(PlaceOfTreatment request)
        {
            _placeRepository.AddPlace(request);
            var name = User.Identity.Name;
            TempData["AddPlace"] = "Thêm bệnh nơi điều trị thành công";
            _activityRepository.AddActivity(name, "đã thêm nơi điều trị mới");

            return RedirectToAction("GetAllPlace");
        }

        [HttpPost]
        public IActionResult SearchPerson(int personId)
        {
            var Home = new HomeVm();
            var place = _placeRepository.GetAllPlace();
            var people = _ipersonRepository.SearchWithCode(personId);
            if (people.Count == 0)
            {
                return Content("Không tìm thấy bệnh nhân");
            }
            var person = _ipersonRepository.SearchWithCode(personId).FirstOrDefault();
            var related = _ipersonRepository.GetRelatedPerson(personId);
            Home.People = people;
            Home.Person = person;
            Home.Place = place;
            Home.RelatedPerson = related;
            return View(Home);
        }

        [HttpPost]
        public IActionResult SearchWithName(string name)
        {
            var x = _ipersonRepository.SearchWithName(name);
            return View(x);
        }

        public IActionResult EditPerson(int personid)
        {
            var listplace = _placeRepository.GetAllPlace();
            ViewBag.ListPlace = listplace.Select(x => new SelectListItem()
            {
                Text = x.PlaceName,
                Value = x.PlaceId.ToString()
            });

            var l = new List<SelectListItem>();
            var li = new SelectListItem()
            {
                Value = "1",
                Text = "Nữ"
            };
            l.Add(li);
            var li2 = new SelectListItem()
            {
                Value = "2",
                Text = "Nam"
            };
            l.Add(li2);
            ViewBag.ListGender = l;

            var x = _ipersonRepository.GetEditPerson(personid);
            ViewBag.Date = DateTime.Parse(x.DateOfBirth).ToString("yyyy-MM-dd");

            var place = _placeRepository.GetPlace(x.PlaceOfTreatmentId);
            ViewBag.Place = new SelectListItem() {
                Text = place.PlaceName,
                Value = place.PlaceId.ToString()
            
            };
            return View(x);
        }

        [HttpPost]
        public IActionResult EditPerson(EditPerson request)
        {
            
            TempData["EditPerson"] = "Thay đổi thông tin bệnh nhân số " + request.PersonId + " thành công!";
            var name = User.Identity.Name;
            var person = _ipersonRepository.GetPerson(request.PersonId);
            if (person.PlaceOfTreatmentId != request.PlaceOfTreatmentId)
            {
                _placeRepository.ChangeQuantity(request.PlaceOfTreatmentId, person.PlaceOfTreatmentId);
            }
            _ipersonRepository.EditPerson(request);
            _activityRepository.AddActivity(name, "đã thay đổi thông tin bệnh nhân số " + request.PersonId );
            return RedirectToAction("GetAllListPerson");   
        }

        [HttpPost]
        public IActionResult OrderByName()
        {
            var x = _ipersonRepository.OrderByName();
            return View(x);
        }

        [HttpPost]
        public IActionResult OrderByCreateDate()
        {
            var x = _ipersonRepository.OrderByCreateDate();
            return View(x);
        }

        [HttpPost]
        public IActionResult OrderByName2()
        {
            var x = _ipersonRepository.OrderByName();
            return View(x);
        }

        [HttpPost]
        public IActionResult OrderByCreateDate2()
        {
            var x = _ipersonRepository.OrderByCreateDate();
            return View(x);
        }

        [HttpPost]
        public IActionResult OrderById()
        {
            var x = _ipersonRepository.OrderById();
            return View(x);
        }

        [HttpPost]
        public IActionResult ChangeStatusPerson(int personid, string status)
        {
            var name = User.Identity.Name;
            _ipersonRepository.ChangeStatusPerson(personid, status);
            TempData["StatusChange"] = "Thay đổi tình trạng bệnh nhân thành công";
            _activityRepository.AddActivity(name,"đã thay tình trạng bệnh nhân số " + personid);
            return RedirectToAction("Index");

        }

        public IActionResult PersonExport(int personid)
        {
            _ipersonRepository.ExportPerson(personid);
            var name = User.Identity.Name;
            TempData["ExportPerson"] = "Cho bệnh nhân xuất viện thành công";
            _activityRepository.AddActivity(name, "đã xác nhân bệnh cho nhân số " + personid + " xuất viện");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DiedPerson(int personid)
        {          
            _ipersonRepository.DiedPerson(personid);
            var name = User.Identity.Name;
            TempData["DiedPerson"] = "Xác nhận bệnh nhân tử vong thành công";
            _activityRepository.AddActivity(name, "đã xác nhân bệnh nhân số " + personid+" tử vong");
            
            return RedirectToAction("Index");
        }

        public IActionResult GetAllListPerson(int? page)
        {
            if (TempData["AddPerson"] != null)
            {
                ViewBag.AddPerson = TempData["AddPerson"];
            }
            if (TempData["EditPerson"] != null)
            {
                ViewBag.EditPerson = TempData["EditPerson"];
            }
            if (TempData["DeletePerson"] != null)
            {
                ViewBag.DeletePerson = TempData["DeletePerson"];
            }
            var x = _ipersonRepository.GetAllListPerson(page);
            return View(x);
        }

        public IActionResult SearchPerson2(int PersonId)
        {
            var x = _ipersonRepository.SearchWithCode(PersonId);
            if (x.Count()>0 )
            {
                return View(x);
            }
            return Content("Mã bệnh nhân không phù hợp");
        }

        public IActionResult GetAllPlace()
        {
            if (TempData["DeletePlace"] != null)
            {
                ViewBag.DeletePlace = TempData["DeletePlace"];
            }

            if(TempData["EditPlace"] != null)
            {
                ViewBag.EditPlace = TempData["EditPlace"];
            }


            if (TempData["AddPlace"] != null)
            {
                ViewBag.AddPlace = TempData["AddPlace"];
            }
            var x = _placeRepository.GetAllPlace();
            return View(x);
        }

    }
}
