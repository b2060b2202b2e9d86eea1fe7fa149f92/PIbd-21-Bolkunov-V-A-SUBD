using System;
using System.Collections.Generic;

#nullable disable

namespace UniversityJournalDb.Models
{
    public partial class StudentModel
    {
        protected internal StudentModel()
        {
            TaskStudents = new HashSet<TaskStudentModel>();
        }

        public int Id { get; protected internal set; }
        public string Name { get; protected internal set; }
        public DateTime Birthday { get; protected internal set; }
        public int GroupId { get; protected internal set; }

        public virtual GroupModel Group { get; protected internal set; }
        public virtual ICollection<TaskStudentModel> TaskStudents { get; protected internal set; }

        public override string ToString()
        {
            return "Student";
        }
    }
}
