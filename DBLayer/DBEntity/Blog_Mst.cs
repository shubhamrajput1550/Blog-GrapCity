//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBLayer.DBEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blog_Mst
    {
        public int PK_Blog_id { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public string BlogContent { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int FK_User_Id { get; set; }
    
        public virtual User User { get; set; }
    }
}
