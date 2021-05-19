using System;
using System.Collections.Generic;

#nullable disable

namespace UniversityJournalDb.Models
{
    public partial class SubjectModel
    {
        protected internal SubjectModel()
        {
            Tasks = new HashSet<TaskModel>();
        }

        public int Id { get; protected internal set; }
        public string Name { get; protected internal set; }
        public int TeacherId { get; protected internal set; }

        public virtual TeacherModel Teacher { get; protected internal set; }
        public virtual ICollection<TaskModel> Tasks { get; protected internal set; }

        public override string ToString()
        {
            return "Subject";
        }
    }
}
