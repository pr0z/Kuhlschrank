using OnBarcode.Barcode.BarcodeScanner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BarCodeAnalyser
{
    /// <summary>
    /// Classe représentant l'analyseur de codes-barres
    /// Basée sur le moteur OnBarCode
    /// </summary>
    public class BarCodeAnalyser
    {
        private string FolderLocation { get; set; }

        /// <summary>
        /// Constructeur par défaut de la classe
        /// Initialise le nom du fichier où trouver les fichiers à analyser
        /// </summary>
        public BarCodeAnalyser()
        {
            FolderLocation = string.Format("Kuhlschrank-{0}",DateTime.Now.Date.ToString("dMyyyy"));
        }

        /// <summary>
        /// Analyse chaque fichier contenu dans le répertoire initialisé par le constructeur
        /// </summary>
        /// <returns>Dictionnaire contenant le nom du fichier et le résultat du scan</returns>
        public Dictionary<string, string> Analyse()
        {
            Dictionary<string, string> recognizedEAN = new Dictionary<string, string>();
            string filesDirectory = Path.Combine(Path.GetTempPath(), FolderLocation);

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