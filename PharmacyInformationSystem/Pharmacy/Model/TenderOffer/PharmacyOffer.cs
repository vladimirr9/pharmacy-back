using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class PharmacyOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime TimePosted { get; set; }
        public virtual IEnumerable<PharmacyOfferComponent> Components { get; set; }

        public PharmacyOffer(long id,DateTime timePosted, List<PharmacyOfferComponent> offerComponents)
        {
            Id = id;
            TimePosted = timePosted;
            Components = offerComponents;
        }

        public PharmacyOffer() { }

        public PharmacyOffer(List<PharmacyOfferComponent> offerComponents)
        {
            this.TimePosted = DateTime.Now;
            this.Components = offerComponents;
        }

        public double GetPrice()
        {
            return Components.Sum(component => component.Price * component.Quantity);
        }
    }
}
