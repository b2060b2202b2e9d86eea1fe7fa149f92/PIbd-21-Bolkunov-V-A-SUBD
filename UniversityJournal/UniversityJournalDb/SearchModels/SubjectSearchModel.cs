using System;
using System.Collections.Generic;

namespace UniversityJournalDb.SearchModels
{
    public class SubjectSearchModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }
    }
}
