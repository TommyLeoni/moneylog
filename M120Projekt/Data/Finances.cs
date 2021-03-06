﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Finances
    {
        #region Datenbankschicht
        [Key]
        public Int64 EntryID { get; set; }
        [Required]
        public String TitleProduct { get; set; }
        [Required]
        public Double AmountSpent { get; set; }
        [Required]
        public String Currency { get; set; }
        [Required]
        public String PaymentMethod { get; set; }
        [Required]
        public DateTime DateTimePurchased { get; set; }
        [Required]
        public Boolean Edited { get; set; }
        #endregion
        #region Applikationsschicht
        public Finances() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "The getter holds code for attributes calculated throughout the duration";
            }
        }
        public static IEnumerable<Data.Finances> ReadAll()
        {
            return (from record in Data.Global.context.Finances select record);
        }
        public static Data.Finances ReadID(Int64 EntryID)
        {
            return (from record in Data.Global.context.Finances where record.EntryID == EntryID select record).FirstOrDefault();
        }
        public static IEnumerable<Data.Finances> ReadWhereAttribute(String suchbegriff)
        {
            return (from record in Data.Global.context.Finances where record.TitleProduct == suchbegriff select record);
        }
        public static IEnumerable<Data.Finances> ReadWhereAttributeLike(String suchbegriff)
        {
            return (from record in Data.Global.context.Finances where record.TitleProduct.Contains(suchbegriff) select record);
        }
        public Int64 Create()
        {
            if (this.TitleProduct == null || this.TitleProduct == "") this.TitleProduct = "leer";
            if (this.AmountSpent == 0.00) this.AmountSpent = 1.00;
            if (this.Currency == null || this.Currency == "") this.Currency = "leer";
            if (this.DateTimePurchased == null) this.DateTimePurchased = DateTime.Now;
            Data.Global.context.Finances.Add(this);
            Data.Global.context.SaveChanges();
            return this.EntryID;
        }
        public Int64 Update()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Modified;
            Data.Global.context.SaveChanges();
            return this.EntryID;
        }
        public void Delete()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
            Data.Global.context.SaveChanges();
        }
        public override string ToString()
        {
            return EntryID.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
