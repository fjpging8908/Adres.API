using Adres.API.Model;
using System;
using System.Collections.Generic;

namespace Adres.API.Data.Contracts.Dto
{
    public class AcquisitionRequirementDto
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

        public List<AcquisitionRequirementDto> History { get; set; }

    }
}
