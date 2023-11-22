using MyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCars.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult CarDetails()
        {
            CarsEntities db = new CarsEntities();

            // for getting records from multiple tables
            List<Automobile> automobilelist = db.Automobiles.ToList();
            Cars vmcars = new Cars();

            List<Cars> vmcarslist = automobilelist.Select(x => new Cars
            {
                AutomobileID = x.AutomobileID,
                ModelID = x.ModelID,
                ModelNumber = x.ModelDetail.ModelNumber,
                ModelName = x.ModelDetail.ModelName,
                ModelYear = x.ModelDetail.ModelYear,
                CompanyID = x.CompanyID,
                Name = x.AutomobilesCompany.Name,
                Status = x.Status,
                Price = x.Price
            }).ToList();

            //singleecord show code
            //utomobile automobile = db.Automobiles.SingleOrDefault(x => x.AutomobileID == 1);
            //Cars cars = new Cars();
            //cars.AutomobileID = automobile.AutomobileID;
            //cars.CompanyID = automobile.CompanyID;
            //cars.ModelID = automobile.ModelID;
            //cars.Status = automobile.Status;
            //cars.Price = automobile.Price;


            return View(automobilelist);
        }
    }
}