using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace KendoUIAttributes.Controllers
{
    public class LocationController : Controller
    {
        //
        // GET: /Location/

        public JsonResult GetCountries()
        {

            var result = new List<ListItem>();
            result.Add( new ListItem("USA", "1"));
            result.Add(new ListItem("Canada", "2"));
            result.Add(new ListItem("Germany", "3"));


            return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetStates(int? countryId)
        {
            var result = new List<ListItem>();

            if (countryId.HasValue)
            {
                switch (countryId.Value)
                {
                    case 1:
                        result.Add(new ListItem("Texas", "1"));
                        result.Add(new ListItem("Virgina", "2"));
                        result.Add(new ListItem("Alabama", "3"));
                        break;

                    case 2:
                        result.Add(new ListItem("C1", "4"));
                        result.Add(new ListItem("C2", "5"));
                        result.Add(new ListItem("C3", "6"));
                        
                        break;

                    case 3:
                        result.Add(new ListItem("Heidlburg", "7"));
                        result.Add(new ListItem("Hamburg", "8"));
                        result.Add(new ListItem("Berlin", "9"));

                        break;

                }
            }

            return new JsonResult() {Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public JsonResult GetCities(int? stateID)
        {
            
            var result = new List<ListItem>();

            if (stateID.HasValue)
            {
                switch (stateID.Value)
                {
                    case 1:
                        result.Add(new ListItem("City 1", "1"));
                        result.Add(new ListItem("City 2", "2"));
                        result.Add(new ListItem("City 3", "3"));
                        break;

                    case 2:
                        result.Add(new ListItem("City 4", "4"));
                        result.Add(new ListItem("City 5", "5"));
                        result.Add(new ListItem("City 6", "6"));
                        break;

                    case 3:
                        result.Add(new ListItem("City 7", "7"));
                        result.Add(new ListItem("City 8", "8"));
                        result.Add(new ListItem("City 9", "9"));

                        break;

                }
            }

            return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


    }
}
