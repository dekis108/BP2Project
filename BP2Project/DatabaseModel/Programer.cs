//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Programer : Zaposleni
    {
        public Nullable<int> O_PROD { get; set; }
    
        public virtual Tim ClanTima { get; set; }
        public virtual Tim VodiTim { get; set; }
    }
}
