using System;
using System.Collections.Generic;

namespace UniversityJournalDb.SearchModels
{
    public class StudentSearchModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public int? GroupId { get; set; }
    }
}
