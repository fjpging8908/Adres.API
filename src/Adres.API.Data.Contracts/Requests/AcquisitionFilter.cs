using Adres.API.Model;
using System;

namespace Adres.API.Data.Contracts.Requests
{
    public class AcquisitionFilter
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string BusinessUnity { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal UnitaryValue { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public string Provider { get; set; }
        public string Document { get; set; }
        public bool Enable { get; set; }
        public int version { get; set; }

    }
}
