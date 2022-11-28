using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
namespace PIMS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View("Index", "Masterpage");
        }

        //Database Access Layer class in modal
    
        public ActionResult Aboutus()
        {
            return View("Aboutus", "Masterpage");
        }
        public ActionResult Services()
        {
            return View("Services", "Masterpage");
        }
        public ActionResult HotelListView()
        {
            return View("HotelListView", "Masterpage");
        }
        public ActionResult RestaurantListView()
        {
            return View("RestaurantListView", "Masterpage");
        }
        public ActionResult FlightListView()
        {
            return View("FlightListView", "Masterpage");
        }
        public ActionResult CarListView()
        {
            return View("CarListView", "Masterpage");
        }

        public ActionResult Gallery()
        {
            return View("Gallery", "Masterpage");
        }
        public ActionResult Contactus()
        {
            return View("Contactus", "Masterpage");
        }
        public ActionResult HotelDetails()
        {
            return View("HotelDetails", "Masterpage");
        }
        public ActionResult FlightDetails()
        {
            return View("FlightDetails", "Masterpage");
        }
        public ActionResult CarDetails()
        {
            return View("CarDetails", "Masterpage");
        }
      
        public ActionResult visionandmission()
        {
            return View("visionandmission", "Masterpage");
        }
        public ActionResult CoreValues()
        {
            return View("CoreValues", "Masterpage");
        }
        public ActionResult Team()
        {
            return View("Team", "Masterpage");
        }
        public ActionResult Messeges()
        {
            return View("Messeges", "Masterpage");
        }
        public ActionResult PakistanTours()
        {
            return View("PakistanTours", "Masterpage");
        }
         public ActionResult  ecotourism()
        {
            return View("ecotourism", "Masterpage");
        }
         public ActionResult  adventuretourism()
        {
            return View("adventuretourism", "Masterpage");
        }
       
         public ActionResult  spiritualtourism()
        {
            return View("spiritualtourism", "Masterpage");
        }
         public ActionResult  heritagetourism()
        {
            return View("heritagetourism", "Masterpage");
        }
         public ActionResult sportstourism()
        {
            return View("sportstourism", "Masterpage");
        }
      public ActionResult TourIndex()
        {
            return View("TourIndex", "Masterpage");
        }
      public ActionResult AdventureTours()
        {
            return View("AdventureTours", "Masterpage");
        }
      public ActionResult TourAdventure()
        {
            return View("TourAdventure", "Masterpage");
        }
      public ActionResult FairyMeadowsHunza()
      {
          return View("FairyMeadowsHunza", "Masterpage");
      }

        //
      public ActionResult BuddhistPilgrimageTours()
      {
          return View("BuddhistPilgrimageTours", "Masterpage");
      }
      public ActionResult ReligiousEcoIslamabad()
      {
          return View("ReligiousEcoIslamabad", "Masterpage");
      }
      public ActionResult ReligiousEcoPeshawar()
      {
          return View("ReligiousEcoPeshawar", "Masterpage");
      }
      public ActionResult ReligiousAndEcoIslamabad()
      {
          return View("ReligiousAndEcoIslamabad", "Masterpage");
      }
     //
      public ActionResult EcoAndFamilyTours()
      {
          return View("EcoAndFamilyTours", "Masterpage");
      }
      public ActionResult TourToSkardu()
      {
          return View("TourToSkardu", "Masterpage");
      }
      public ActionResult HunzaTour()
      {
          return View("HunzaTour", "Masterpage");
      }
      public ActionResult PageComing()
      {
          return View("PageComing", "Masterpage");
      }
        public ActionResult HotelTwoStart()
        {
            return View("HotelTwoStart", "Masterpage");
        }
        public ActionResult HotelThreeStart()
        {
            return View("HotelThreeStart", "Masterpage");
        }
        public ActionResult HotelFourStart()
        {
            return View("HotelFourStart", "Masterpage");
        }
        public ActionResult HotelFiveStart()
        {
            return View("HotelFiveStart", "Masterpage");
        }
        public ActionResult HotelAbatabad()
        {
            return View("HotelAbatabad", "Masterpage");
        }
        public ActionResult HotelBesham()
        {
            return View("HotelBesham", "Masterpage");
        }
        public ActionResult HotelPeshawar()
        {
            return View("HotelPeshawar", "Masterpage");
        }
        public ActionResult HotelChitral()
        {
            return View("HotelChitral", "Masterpage");
        }
        public ActionResult HotelGilgit()
        {
            return View("HotelGilgit", "Masterpage");
        }

        public ActionResult HotelHunza()
        {
            return View("HotelHunza", "Masterpage");
        }
        public ActionResult HotelIslamabadRawalpindi()
        {
            return View("HotelIslamabadRawalpindi", "Masterpage");
        }
      
        public ActionResult HotelKarachi()
        {
            return View("HotelKarachi", "Masterpage");
        }
        public ActionResult HotelLahore()
        {
            return View("HotelLahore", "Masterpage");
        }
        public ActionResult HotelMuree()
        {
            return View("HotelMuree", "Masterpage");
        }
        public ActionResult HotelNaranShogranBalakot()
        {
            return View("HotelNaranShogranBalakot", "Masterpage");
        }
       
        public ActionResult HotelSkirdo()
        {
            return View("HotelSkirdo", "Masterpage");
        }
        public ActionResult HotelSwat()
        {
            return View("HotelSwat", "Masterpage");
        }
        public ActionResult HotelTaxila()
        {
            return View("HotelTaxila", "Masterpage");
        }
        
            public ActionResult TraveltoPakistan()
        {
            return View("TraveltoPakistan", "Masterpage");
        }
        public ActionResult WhatToSeeEatWearandBuy()
        {
            return View("WhatToSeeEatWearandBuy", "Masterpage");
        }
        public ActionResult HealthInformation()
        {
            return View("HealthInformation", "Masterpage");
        }
        public ActionResult CustomsFormalitiesAndAllowances()
        {
            return View("CustomsFormalitiesAndAllowances", "Masterpage");
        }
        public ActionResult ImportandExports()
        {
            return View("ImportandExports", "Masterpage");
        }
        public ActionResult CurrencyRegulations()
        {
            return View("CurrencyRegulations", "Masterpage");
        }
        public ActionResult DOSandDONTS()
        {
            return View("DOSandDONTS", "Masterpage");
        }
        public ActionResult PakistanNationalLanguageUrduGlossary()
        {
            return View("PakistanNationalLanguageUrduGlossary", "Masterpage");
        }
        public ActionResult EmergencyContactNumbers()
        {
            return View("EmergencyContactNumbers", "Masterpage");
        }
        public ActionResult OutBountedTours()
        {
            return View("OutBountedTours", "Masterpage");
        }
        public ActionResult AzerbaijanTours()
        {
            return View("AzerbaijanTours", "Masterpage");
        }
        public ActionResult EgyptTours()
        {
            return View("EgyptTours", "Masterpage");
        }
        public ActionResult Media()
        {
            return View("Media", "Masterpage");
        }
        
 public ActionResult Downloads()
        {
            return View("Downloads", "Masterpage");
        }


    }
}