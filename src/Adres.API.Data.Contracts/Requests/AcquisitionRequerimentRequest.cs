using System;
using System.Collections.Generic;

namespace Adres.API.Data.Contracts.Requests
{
   

    public class AcquisitionRequerimentRequest
    {
        public decimal Budget { get; set; }
        public string BusinessUnity { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal UnitaryValue { get; set; }
        public string Provider { get; set; }
        public string Document { get; set; }        
    }   
   

    

    


}
