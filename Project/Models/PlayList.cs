//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectVideo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlayList
    {
        public int ID { get; set; }
        public int idUser { get; set; }
        public int idVideo { get; set; }
    
        public virtual User User { get; set; }
        public virtual Video Video { get; set; }
    }
}
