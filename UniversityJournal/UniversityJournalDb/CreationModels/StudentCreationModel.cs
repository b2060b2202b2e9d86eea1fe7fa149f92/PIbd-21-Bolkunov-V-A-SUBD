using System;
using System.Collections.Generic;

namespace UniversityJournalDb.CreationModels
{
    public class StudentCreationModel
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int GroupId { get; set; }
    }
}
