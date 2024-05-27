
using Adres.API.Data.Contracts.Interfaces;
using Adres.API.Data.Contracts.Requests;
using Adres.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Adres.API.Data.Repositories
{
    public class AcquisitionRequirementRepository : IAcquisitionRequirementRepository
    {
        private readonly AdresContext _context;

        public AcquisitionRequirementRepository(AdresContext context)
        {
            _context = context;
        }

        public AcquisitionRequirement Get(int id)
        {
            return _context.AcquisitionRequirement
                .FirstOrDefault(x => x.Id == id);
        }

        public List<AcquisitionRequirement> GetByFilter(AcquisitionFilter filter)
        {
            var query = _context.AcquisitionRequirement
                .Where(x =>
                        x.Enable && 
                        (string.IsNullOrEmpty(filter.BusinessUnity) || x.BusinessUnity == filter.BusinessUnity) &&
                        (filter.Id == 0 || filter.Id == x.Id) &&
                        (string.IsNullOrEmpty(filter.Type) || filter.Type == x.Type) &&
                        (string.IsNullOrEmpty(filter.Number) || filter.Number == x.Number) &&
                        (filter.AcquisitionDate==null || filter.AcquisitionDate.Value.Date == x.AcquisitionDate.Date)
                        )
                .AsQueryable();


            return query.ToList();

        }


        public AcquisitionRequirement Add(AcquisitionRequirement Requirement)
        {
            _context.AcquisitionRequirement.Add(Requirement);
            _context.SaveChanges();

            return Requirement;
        }

        public AcquisitionRequirement Update(AcquisitionRequirement Requirement)
        {
            _context.AcquisitionRequirement.Update(Requirement);
            _context.SaveChanges();

            return Requirement;
        }

        public bool Delete(AcquisitionRequirement Requirement)
        {
            _context.AcquisitionRequirement.Remove(Requirement);
            _context.SaveChanges();

            return true;
        }

        public int GetLastRequirments()
        {
            var last = _context.AcquisitionRequirement.OrderByDescending(x => x.Number).FirstOrDefault()?.Number;
            if (string.IsNullOrEmpty(last))
                return 1;
            else
                return int.Parse(last.Replace("REQ", "")) + 1;
        }

        public List<AcquisitionRequirement> GetHistorial(int id, string ReqNumber)
        {
            return _context.AcquisitionRequirement
                .Where(x => x.Id != id && x.Number==ReqNumber).ToList();
        }
    }
}