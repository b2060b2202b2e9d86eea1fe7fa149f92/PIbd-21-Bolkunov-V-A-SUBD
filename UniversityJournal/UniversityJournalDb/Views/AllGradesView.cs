using System;
using System.Collections.Generic;

#nullable disable

namespace UniversityJournalDb.Views
{
    public partial class AllGradesView
    {
        public string GroupName { get; set; }
        public short? CreationYear { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string TaskName { get; set; }
        public short? Grade { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
