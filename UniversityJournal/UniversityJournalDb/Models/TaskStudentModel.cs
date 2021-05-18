using System;
using System.Collections.Generic;

#nullable disable

namespace UniversityJournalDb.Models
{
    public partial class TaskStudentModel
    {
        protected internal TaskStudentModel()
        {

        }

        public int TaskId { get; protected internal set; }
        public int StudentId { get; protected internal set; }
        public short Grade { get; protected internal set; }
        public DateTime FinishDate { get; protected internal set; }

        public virtual StudentModel Student { get; protected internal set; }
        public virtual TaskModel Task { get; protected internal set; }
    }
}
