﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;
    
    
    public partial class tComment
    {
        public int comment_id { get; set; }
        public Nullable<int> news_ids { get; set; }

        [Required(ErrorMessage ="нэрээ оруулна уу!!!")]
        public string name { get; set; }
        [Required(ErrorMessage = "И-майл оруулна уу!!!")]
        public string e_mails { get; set; }
        [Required(ErrorMessage = "Сэтгэгдэл бичнэ үү!!!")]
        public string comment { get; set; }
        public Nullable<System.DateTime> addedcomment { get; set; }
        public string http_posted { get; set; }
    
        public virtual tNews tNews { get; set; }
    }
}
