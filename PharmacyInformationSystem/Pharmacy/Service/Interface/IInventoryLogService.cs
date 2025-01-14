﻿using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service.Interface
{
    public interface IInventoryLogService
    {
        List<InventoryItem> GetPharmacyInventory(long id);

        List<MedicationDistribution> GetMedicationDistribution(long id);

        List<InventoryLog> GetLogsByPharmacyWithQuantity(long pharmacyId, int quantity);

        List<InventoryLog> GetLogsByMedicationWithQuantity(long medicationId, int quantity);

        void RemoveMedicineReferences(long id);

        void RemovePharmacyReferences(long id);

        bool AddMedication(long pharmacyID, long medicationID, long quantity);

        bool RemoveMedication(long pharmacyID, long medicationID, long quantity);

        bool CheckIfQuantityExists(string medicationName, int quantity);

        bool CheckIfLogExistsInPharmacy(long pharmacyId, long medicationId, long quantity);
    }
}
