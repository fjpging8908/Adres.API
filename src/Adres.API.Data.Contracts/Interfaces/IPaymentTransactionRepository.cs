using Adres.API.Data.Contracts.Requests;
using Adres.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Adres.API.Data.Contracts.Interfaces
{
    public interface IAcquisitionRequirementRepository
    {
        AcquisitionRequirement Get(int id);     
        AcquisitionRequirement Add(AcquisitionRequirement paymentTransaction);
        AcquisitionRequirement Update(AcquisitionRequirement paymentTransaction);
        List<AcquisitionRequirement> GetByFilter(AcquisitionFilter filter);
        int GetLastRequirments();
        List<AcquisitionRequirement> GetHistorial(int id, string ReqNumber);
        bool Delete(AcquisitionRequirement Requirement);
    }
}