using System;
using System.Collections.Generic;

#nullable disable

namespace UniversityJournalDb.Models
{
    public partial class TeacherModel
    {
        protected internal TeacherModel()
        {
            Subjects = new HashSet<SubjectModel>();
        }

        public int Id { get; protected internal set; }
        public string Name { get; protected internal set; }
        public DateTime Birthday { get; protected internal set; }

        public virtual ICollection<SubjectModel> Subjects { get; protected internal set; }
    }
}
