using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adres.API.Model
{
    public class AcquisitionRequirement
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Budget { get; set; }
        public string BusinessUnity { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal UnitaryValue { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Provider { get; set; }
        public string Document { get; set; }

        public bool Enable { get; set; }

        public int version { get; set; }


        public AcquisitionRequirement()
        {
            AcquisitionDate = DateTime.Now;
            TotalAmount = this.UnitaryValue * this.Quantity;
            version = 0;
            Enable = true;
        }

        public void createNewVersion(AcquisitionRequirement oldVersion)
        {
            this.version = oldVersion.version + 1;                        
            this.Number=oldVersion.Number;
            this.AcquisitionDate=oldVersion.AcquisitionDate;
        }
    }
}
