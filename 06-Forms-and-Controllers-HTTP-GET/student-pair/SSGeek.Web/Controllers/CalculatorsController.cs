﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class CalculatorsController : Controller
    {

       
        // INSTRUCTIONS
        // As a part of each exercise you will need to 
        // - develop a view for AlienAge, AlienWeight, and AlienTravel that displays a form to submit data
        // - create a new action to process the form submission (e.g. AlienAgeResult, AlienWeightResult, etc.)
        // - create a view that displays the submitted form result

        
        // GET: Calculators/AlienWeight
        public ActionResult AlienWeight()
        {
            AlienWeightModel alienWeight = new AlienWeightModel();
            return View(alienWeight);
        }

        // GET: calcualtors/alienweightresult?planet=xyz&weight=123
        public ActionResult AlienWeightResult(AlienWeightModel model)
        {
            return View(model);
        }
 

        public ActionResult AlienAge()
        {
            AlienAgeModel ageResult = new AlienAgeModel();
            return View(ageResult);
        }


        public ActionResult AlienAgeResult(AlienAgeModel model)
        {
            return View(model);
        }

        public ActionResult AlienTravel()
        {
            AlienTravelModel alienTravel = new AlienTravelModel();
            return View(alienTravel);
        }

        public ActionResult AlienTravelResult(AlienTravelModel model)
        {
            return View(model);
        }



        private List<SelectListItem> planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury" },
            new SelectListItem() { Text = "Venus" },
            new SelectListItem() { Text = "Mars" },
            new SelectListItem() { Text = "Jupiter" },
            new SelectListItem() { Text = "Saturn" },
            new SelectListItem() { Text = "Neptune" },
            new SelectListItem() { Text = "Uranus" }
        };

        private List<SelectListItem> transportationModes = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value="walking" },
            new SelectListItem() { Text = "Car", Value = "car" },
            new SelectListItem() { Text = "Bullet Train", Value = "bullet train" },
            new SelectListItem() { Text = "Boeing 747", Value = "boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "concorde" }
        };
    }
}