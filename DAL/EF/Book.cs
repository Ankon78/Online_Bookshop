//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.Buys = new HashSet<Buy>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public int languageId { get; set; }
        public int quantity { get; set; }
        public int amount { get; set; }
        public string bShopName { get; set; }
        public string description { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
    }
}