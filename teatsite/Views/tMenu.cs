//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace teatsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tMenu
    {
        public tMenu()
        {
            this.tNews = new HashSet<tNews>();
            this.tSubmenu = new HashSet<tSubmenu>();
        }
    
        public int menu_id { get; set; }
        public string name { get; set; }
        public string Url { get; set; }
        public string images { get; set; }
        public Nullable<System.DateTime> addeddate { get; set; }
    
        public virtual ICollection<tNews> tNews { get; set; }
        public virtual ICollection<tSubmenu> tSubmenu { get; set; }
    }
}