using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienWeightModel
    {
        public string planets { get; set; }
        public double weightLbs { get; set; }


        public double CalculateWeight(double weightLbs)
        {
            Dictionary<string, double> alienWeightConversion = new Dictionary<string, double>()
            {

                {"Mercury", .37 },
                {"Venus", .90 },
                {"Mars", .38 },
                {"Jupiter", 2.65 },
                {"Saturn", 1.13 },
                {"Neptune", 1.43 },
                { "Uranus", 1.09 }

            };

            double alienWeight = weightLbs * alienWeightConversion[planets];
            return alienWeight;

        }

    }
}