using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // Finances
            Data.Finances klasseA1 = new Data.Finances();
            klasseA1.TitleProduct = "Artikel 1";
            klasseA1.DateTimePurchased = DateTime.Today;
            Int64 klasseA1Id = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        public static void DemoACreateKurz()
        {
            Data.Finances klasseA2 = new Data.Finances { TitleProduct = "Artikel 2", Edited = true, DateTimePurchased = DateTime.Today };
            Int64 klasseA2Id = klasseA2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Finances klasseA in Data.Finances.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.EntryID + " Name:" + klasseA.TitleProduct);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            /* Debug.Print("--- DemoAUpdate ---");
            // Finances ändert Attribute
            Data.Finances klasseA1 = Data.Finances.LesenID(1);
            klasseA1.TitleProduct = "Artikel 1 nach Update";
            klasseA1.Aktualisieren(); */
        }
        // Delete
        public static void DemoADelete()
        {
            /* Debug.Print("--- DemoADelete ---");
            Data.Finances.LesenID(1).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht"); */
        }
        #endregion
    }
}
