//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Аккредитационные_показатели
{
    using System;
    using System.Collections.Generic;
    
    public partial class Management_Master_degree_program
    {
        public int Code_management { get; set; }
        public int Code_teacher { get; set; }
        public string ResearchProject_management { get; set; }
        public string DomesticPublications_management { get; set; }
        public string ForeignPublications_management { get; set; }
        public string Approbation_management { get; set; }
    
        public virtual Teacher Teacher { get; set; }
    }
}
