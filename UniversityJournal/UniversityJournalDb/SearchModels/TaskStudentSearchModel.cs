using System;
using System.Collections.Generic;

namespace UniversityJournalDb.SearchModels
{
    public class TaskStudentSearchModel
    {
        public int? TaskId { get; set; }
        public int? StudentId { get; set; }
        public short? Grade { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
