//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shoppers.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductItem
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public Nullable<System.DateTime> LastDateUpdated { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<double> Qty { get; set; }
        public Nullable<int> CartId { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
