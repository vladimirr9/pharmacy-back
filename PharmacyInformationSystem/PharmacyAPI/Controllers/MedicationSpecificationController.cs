using Microsoft.AspNetCore.Mvc;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationSpecificationController : ControllerBase
    {
        private readonly IMedicationService medicationService;

        public MedicationSpecificationController(IMedicationService medicationService)
        {
            this.medicationService = medicationService;
        }
        [HttpGet]
        public List<Medication> GetAllMedications()
        {
            return medicationService.GetAll();
        }

        [HttpPost]
        public string GetMedicineSpecification([FromBody]string medicationName)
        {
            if (medicationService.isExistMedication(medicationName))
            {
                medicationService.GenerateReport(medicationName);
                return "OK";
            }
            return "Medication don't exist";
        }
    }
}
