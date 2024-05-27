using Adres.API.Data.Contracts.Dto;
using Adres.API.Data.Contracts.Requests;
using Adres.API.Model;
using LP.Common.Payin.Dtos;
using LP.Common.Payin.Requests;
using LP.Common.Payout.Requests;
using LP.Common.Payout.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adres.API.Services.Interfaces
{
    public interface IAcquisitionRequirementService
    {
        public List<AcquisitionRequirementDto> GetAcquisitionRequirements(AcquisitionFilter filter);
        public AcquisitionRequirementDto GetAcquisictionRequirements(int Id);
        public AcquisitionRequirementDto Create(AcquisitionRequerimentRequest request);
        public AcquisitionRequirementDto Update(int Id, AcquisitionRequerimentRequest request);
        public AcquisitionRequirementDto Unable(int  Id);

        public bool Delete(int Id);
    }
}