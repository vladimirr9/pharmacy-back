using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.TenderingRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Service
{
    public class TenderingService : ITenderingService
    {
        private readonly ITenderingRepository tenderingRepository;

        public TenderingService(ITenderingRepository tenderingRepository)
        {
            this.tenderingRepository = tenderingRepository;
        }
        public Tender Create(Tender tender)
        {
           return this.tenderingRepository.Create(tender);
        }

        public Tender Get(long id)
        {
            return this.tenderingRepository.Get(id);
        }

        public List<Tender> GetAll()
        {
            return this.tenderingRepository.GetAll();
        }

        public bool Remove(Tender tender)
        {
            return this.tenderingRepository.Delete(tender.Id);
        }

        public Tender Update(Tender tender)
        {
            return this.tenderingRepository.Update(tender);
        }
    }
}
