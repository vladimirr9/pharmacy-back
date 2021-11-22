using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class MedicationConsumptionService
    {
        public MedicationConsumptionService()
        {

        }

        public void SaveReport()
        {
            String filePath = Directory.GetCurrentDirectory();
            String fileName = "ConsumptionReport.pdf";
            String localFile = Path.Combine(filePath, fileName);
            String fileServer = @"\public\MedicationConsumptionReport.pdf";

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();
                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(fileServer, stream, null);
                }
                client.Disconnect();
            }

        }
    }
}
