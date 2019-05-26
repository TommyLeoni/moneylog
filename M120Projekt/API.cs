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
            Data.Finances newEntry = new Data.Finances();
            newEntry.TitleProduct = title;
            newEntry.AmountSpent = amount;
            newEntry.Currency = currency;
            newEntry.PaymentMethod = pm;
            newEntry.DateTimePurchased = DateTime;
            newEntry.Edited = false;
            Int64 newEntryID = newEntry.Create();
            Debug.Print("Artikel erstellt mit Id:" + newEntryID);
        }

        // Read
        public static IEnumerable<Data.Finances> ReadAll()
        {
            return Data.Finances.ReadAll();
        }
        // Update
        public static void Update(long id, String title, Double amount, String currency, String pm, DateTime dateTime)
        {
            Data.Finances entryToUpdate = Data.Finances.ReadID(id);
            entryToUpdate.TitleProduct = title;
            entryToUpdate.AmountSpent = amount;
            entryToUpdate.Currency = currency;
            entryToUpdate.PaymentMethod = pm;
            entryToUpdate.DateTimePurchased = dateTime;
            entryToUpdate.Edited = true;
            entryToUpdate.Update();
        }
        // Delete
        public static void Delete(int id)
        {
            Debug.Print("--- DemoADelete ---");
            Data.Finances.ReadID(id).Delete();
            Debug.Print("Artikel mit Id " + id + " gelöscht");
        }
        #endregion
    }
}
