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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.PlayLists = new HashSet<PlayList>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string birthday { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string pay { get; set; }
        public bool isAdmin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayList> PlayLists { get; set; }
    }
}
