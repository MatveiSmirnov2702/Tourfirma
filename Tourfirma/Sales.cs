//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tourfirma
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales
    {
        public int Number_sale { get; set; }
        public Nullable<int> Number_client { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Number_tour { get; set; }
        public Nullable<System.DateTime> Date_sale { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Tours Tours { get; set; }
    }
}