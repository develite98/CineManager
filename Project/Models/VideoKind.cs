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
    using System.Collections.ObjectModel;

    public partial class VideoKind
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VideoKind()
        {
            this.Videos = new HashSet<Video>();
        }
    
        public int ID { get; set; }
        public string kindName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Videos { get; set; }
        public ObservableCollection<Video> listFilm { get; set; }
    }
}
