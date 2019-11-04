using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienAgeModel
    {

        public string Planets { get; set; }
        public int Age { get; set; }


        public double CalculateAge(double Age)
        {
            Dictionary<string, double> alienAgeConversion = new Dictionary<string, double>()
            {

                {"Mercury", 87.96 },
                {"Venus", 224.68 },
                {"Mars", 686.98 },
                {"Jupiter", 4329.63 },
                {"Saturn", 10751.44 },
                {"Neptune", 60155.65 },
                { "Uranus", 30685.55 }

            };
            double earthAgeInDays = Age * 365;
            double alienAge = earthAgeInDays / alienAgeConversion[Planets];
            return alienAge;

        }
    }
}
