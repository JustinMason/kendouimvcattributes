using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KendoUIMvcAttributes;

namespace KendoUIAttributes.Models
{
    public class HomeViewModel
    {

        [Display(Order=0, Name="Name")]
        [KendoTextBox]
        public string Name { get; set; }

        [Display(Order = 1, Name = "Country")]
        [KendoComboBox("GetCountries", "Location", Watermark = "Select A Country")]
        public int CountryId { get; set; }

        [Display(Order = 2, Name = "State")]
        [KendoComboBox("GetStates", "Location", Watermark = "Select A State", CascadeFrom="CountryId")]
        public int StateId { get; set; }

        [Display(Order = 3, Name = "City")]
        [KendoComboBox("GetCities", "Location", Watermark = "Select A City", CascadeFrom="StateId")]
        public int? CityId { get; set; }

        [Display(Order = 4, Name = "Country")]
        [KendoMultiSelect("GetStates", "Location", Watermark = "Select A State",  CascadeFrom="CountryId")]
        public int CountryMsId { get; set; }

    }
}