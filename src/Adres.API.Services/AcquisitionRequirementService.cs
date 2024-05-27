using Adres.API.Data.Contracts.Dto;
using Adres.API.Data.Contracts.Interfaces;
using Adres.API.Data.Contracts.Requests;
using Adres.API.Model;
using Adres.API.Services.Interfaces;
using Amazon.SQS.Model.Internal.MarshallTransformations;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adres.API.Services
{
    public class AcquisitionRequirementService : IAcquisitionRequirementService
    {
        private readonly IAcquisitionRequirementRepository _requirementRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AcquisitionRequirementService> _logger;


        public AcquisitionRequirementService(ILogger<AcquisitionRequirementService> logger, IAcquisitionRequirementRepository requirementRepository, IMapper mapper)
        {
            _requirementRepository = requirementRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public AcquisitionRequirementDto Create(AcquisitionRequerimentRequest request)
        {
            try
            {
                AcquisitionRequirement item = _mapper.Map<AcquisitionRequirement>(request);
                item.Number = $"REQ{_requirementRepository.GetLastRequirments()}";
                item.TotalAmount = item.Quantity * item.UnitaryValue;
                var itemSave = _requirementRepository.Add(item);
                var result = _mapper.Map<AcquisitionRequirementDto>(itemSave);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public bool Delete(int Id)
        {
            var req = _requirementRepository.Get(Id);
            if (req != null)
            {
                return _requirementRepository.Delete(req);
            }
            else
                return false;
        }

        public AcquisitionRequirementDto GetAcquisictionRequirements(int Id)
        {
            var find = _requirementRepository.Get(Id);
            if (find != null)
            {
                var historial = _requirementRepository.GetHistorial(find.Id, find.Number);
                var result = _mapper.Map<AcquisitionRequirementDto>(find);
                result.History = historial.Select(x => _mapper.Map<AcquisitionRequirementDto>(x)).ToList();
                return result;
            }
            return null;
        }

        public List<AcquisitionRequirementDto> GetAcquisitionRequirements(AcquisitionFilter filter)
        {
            try
            {
                var result = _requirementRepository.GetByFilter(filter);
                if (result != null)
                    return result.Select(x => _mapper.Map<AcquisitionRequirementDto>(x)).ToList();
                else
                    return null;
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message); return null;
            }
        }

        public AcquisitionRequirementDto Unable(int Id)
        {
            var req = _requirementRepository.Get(Id);
            if (req != null)
            {
                req.Enable = false;
                var result = _requirementRepository.Update(req);
                return _mapper.Map<AcquisitionRequirementDto>(result);
            }
            else
                return null;
        }     

        public AcquisitionRequirementDto Update(int Id, AcquisitionRequerimentRequest request)
        {
            var find = _requirementRepository.Get(Id);
            find.Enable = false;

            AcquisitionRequirement newItem = _mapper.Map<AcquisitionRequirement>(request);
            newItem.createNewVersion(find);
            var saveOld = _requirementRepository.Update(find);
            var saveNew = _requirementRepository.Add(newItem);
            var result = _mapper.Map<AcquisitionRequirementDto>(saveNew);
            return result;
        }
    }
}