//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Anna
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.TheTurnoverOfBooks = new HashSet<TheTurnoverOfBooks>();
        }
    
        public int UsersId { get; set; }
        public string UsersName { get; set; }
        public string UsersFirstName { get; set; }
        public string UsersLastName { get; set; }
        public System.DateTime UsersDateOfBirth { get; set; }
        public string UsersCourse { get; set; }
        public string UsersGroupId { get; set; }
        public string UsersFloor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheTurnoverOfBooks> TheTurnoverOfBooks { get; set; }
    }
}
