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
    
    public partial class DisciplinesSemester
    {
        public DisciplinesSemester()
        {
            this.AcademicLoad = new HashSet<AcademicLoad>();
        }
    
        public int Code_semester { get; set; }
        public int Code_adst { get; set; }
        public int Code_discipline { get; set; }
        public string Semester { get; set; }
        public string HoursLectures_discipline { get; set; }
        public string HoursPractice_discipline { get; set; }
        public string HoursLaboratory_discipline { get; set; }
        public string HoursCredits_discipline { get; set; }
        public string HoursExam_discipline { get; set; }
        public string HoursConsultation_discipline { get; set; }
        public string HoursCoursework_discipline { get; set; }
    
        public virtual ICollection<AcademicLoad> AcademicLoad { get; set; }
        public virtual Admission_student Admission_student { get; set; }
        public virtual Disciplines Disciplines { get; set; }
        public override string ToString() => Semester + " " + Disciplines.Title_discipline;
    }
}
