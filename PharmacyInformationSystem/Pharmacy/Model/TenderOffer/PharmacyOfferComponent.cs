using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyClassLib.Model.Relations
{
    public class PharmacyOfferComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long MedicationId { get; set; }
        public virtual Medication Medication { get; set; }
        public long Quantity { get; set; }
        public Double Price { get; set; }
        [ForeignKey("PharmacyOffer")]
        public long PharmacyOfferId { get; set; }


        public PharmacyOfferComponent() { }

        public PharmacyOfferComponent(long id,long quantity,Medication medication)
        {
            Id = id;
            MedicationId = medication.Id;
            Quantity = quantity;
            Medication = medication;
        }

        public PharmacyOfferComponent(long medicationId,long quantity,Double price)
        {
            this.MedicationId = medicationId;
            this.Quantity = quantity;
            this.Price = price;
        }

        public PharmacyOfferComponent(long id, long quantity,Double price,long medicationId)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Price = price;
            this.MedicationId = medicationId;
        }
    }
}
