using System;
using System.Collections.Generic;

namespace UniversityJournalDb.SearchModels
{
    public class TaskSearchModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? SubjectId { get; set; }
    }
}
