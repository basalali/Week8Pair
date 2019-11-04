using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienTravelModel
    {
        public string Planet { get; set; }
        public string Mode { get; set; }
        public double Age { get; set; }
        public double Years { get; set; }


        Dictionary<string, double> alienDistanceConversion = new Dictionary<string, double>()
            {

                {"Mercury", 56974146 },
                {"Venus", 25724767 },
                {"Mars", 48678219 },
                {"Jupiter", 390674710 },
                {"Saturn", 792248270 },
                {"Neptune", 2703959960 },
                { "Uranus", 1692662530 },

            };

        Dictionary<string, double> alienTravelTimeConversion = new Dictionary<string, double>()
            {

                {"Walking", 3 },
                {"Car", 100 },
                {"Bullet Train", 200},
                {"Boeing 747", 570 },
                {"Concorde", 1350 },

            };

        public double GetYears()
        {
            double totalHours = alienDistanceConversion[Planet] / alienTravelTimeConversion[Mode];
            Years = totalHours / 8760;
            return Years;
        }


    }
}
