using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class API
    {
        #region KlasseA
        // Create
        public static void Create(String title, Double amount, String currency, String pm, DateTime DateTime)
        {
            Data.Entry newEntry = new Data.Entry();
            newEntry.TitleProduct = title;
            newEntry.AmountSpent = amount;
            newEntry.Currency = currency;
            newEntry.PaymentMethod = pm;
            newEntry.DateTimePurchased = DateTime;
            newEntry.Edited = false;
            Int64 newEntryID = newEntry.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + newEntryID);
        }
        public static void DemoACreateKurz()
        {
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Entry klasseA in Data.Entry.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.EntryID + " Name:" + klasseA.TitleProduct);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            /* Debug.Print("--- DemoAUpdate ---");
            // Entry ändert Attribute
            Data.Entry klasseA1 = Data.Entry.LesenID(1);
            klasseA1.TitleProduct = "Artikel 1 nach Update";
            klasseA1.Aktualisieren(); */
        }
        // Delete
        public static void DemoADelete()
        {
            /* Debug.Print("--- DemoADelete ---");
            Data.Entry.LesenID(1).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht"); */
        }
        #endregion
    }
}
