using System;
using System.Collections.Generic;

#nullable disable

namespace UniversityJournalDb.Models
{
    public partial class TaskModel
    {
        protected internal TaskModel()
        {
            TaskStudents = new HashSet<TaskStudentModel>();
        }

        public int Id { get; protected internal set; }
        public string Name { get; protected internal set; }
        public int SubjectId { get; protected internal set; }

        public virtual SubjectModel Subject { get; protected internal set; }
        public virtual ICollection<TaskStudentModel> TaskStudents { get; protected internal set; }

        public override string ToString()
        {
            return "Task";
        }
    }
}
