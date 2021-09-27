using CMSEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Script.Serialization;

namespace CMSEditor.Controllers
{
    public class SaveFileController : Controller
    {

        public CMSSave GetSaveFile()
        {            
            string path = @"C:\Users\osama\AppData\LocalLow\Red Dot Games\Car Mechanic Simulator 2021\Save\profile0.cms21";
            StreamReader sr = new StreamReader(path, true);

            // Process Uploaded File            
            var SaveFile =   new JavaScriptSerializer() { MaxJsonLength = int.MaxValue }.Deserialize<CMSSave>(sr.ReadToEnd());
            sr.Close();
            return SaveFile;

        }

        // GET: SaveFile
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Upload()
        {
            
            
            return View("ViewSave", GetSaveFile());
        }
        public ActionResult ViewSave()
        {
            return View();
        }
        public ActionResult ViewOrder(int Id)
        {

            return View("Order", GetSaveFile().jobsData.selectedJobs.Where(x => x.id == Id).FirstOrDefault());
        }
        public ActionResult ViewCar(int Id, string CarLocation)
        {
            Car[] Cars = CarLocation == "Garage" ? GetSaveFile().carsInGarage : GetSaveFile().carsOnParking;
            return View("Car", Cars.Where(x=>x.index==Id).FirstOrDefault());
        }
    }
}