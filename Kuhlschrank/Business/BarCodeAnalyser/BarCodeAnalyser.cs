using OnBarcode.Barcode.BarcodeScanner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BarCodeAnalyser
{
    public class BarCodeAnalyser
    {
        private string FolderLocation { get; set; }

        public BarCodeAnalyser()
        {
            FolderLocation = DateTime.Now.Date.ToString("dMyyyy");
        }

        public Dictionary<string, string> Analyse()
        {
            Dictionary<string, string> recognizedEAN = new Dictionary<string, string>();
            string filesDirectory = Path.Combine(Path.GetTempPath(), string.Format("Kuhlschrank-{0}", FolderLocation));

            foreach (string file in Directory.GetFiles(filesDirectory))
            {
                string[] barcode = BarcodeScanner.Scan(file, BarcodeType.EAN13);
                if (barcode.Count() != 0)
                    recognizedEAN.Add(file, barcode.First());
                else
                    recognizedEAN.Add(file, null);
            }

            return recognizedEAN;
        }
    }
}