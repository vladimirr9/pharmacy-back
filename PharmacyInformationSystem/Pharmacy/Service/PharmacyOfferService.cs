using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.PharmacyOfferRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class PharmacyOfferService : IPharmacyOfferService
    {
        private readonly IPharmacyOfferRepository pharmacyOfferRepository;
        private readonly IMedicationRepository medicationRepository;

        public PharmacyOfferService(IPharmacyOfferRepository pharmacyOfferRepository)
        {
            this.pharmacyOfferRepository = pharmacyOfferRepository;
        }

        public PharmacyOffer Create(PharmacyOffer offer) {
            return this.pharmacyOfferRepository.Create(offer);
        }

        public PharmacyOffer CreateOffer(List<PharmacyOfferComponent> pharmacyOfferComponents)
        {
            pharmacyOfferComponents.ForEach(component => component.Medication = medicationRepository.Get(component.Id));
            PharmacyOffer pharmacyOffer = new PharmacyOffer(pharmacyOfferComponents);
            return pharmacyOffer;
        }

        public bool Delete(long id)
        {
            return pharmacyOfferRepository.Delete(id);
        }

    }
}
