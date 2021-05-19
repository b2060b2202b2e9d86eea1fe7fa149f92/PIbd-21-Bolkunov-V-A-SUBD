using System;
using System.Collections.Generic;

#nullable disable

namespace UniversityJournalDb.Models
{
    public partial class GroupModel
    {
        protected internal GroupModel()
        {
            Students = new HashSet<StudentModel>();
        }

        public int Id { get; protected internal set; }
        public string Name { get; protected internal set; }
        public short CreationYear { get; protected internal set; }

        public virtual ICollection<StudentModel> Students { get; protected internal set; }

        public override string ToString()
        {
            return "Group";
        }
    }
}
