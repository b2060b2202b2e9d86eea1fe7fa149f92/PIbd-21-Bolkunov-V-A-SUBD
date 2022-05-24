using System;
using System.Collections.Generic;

namespace UniversityJournalDb.CreationModels
{
    public class TaskCreationModel
    {
        public TaskCreationModel(string name, int subjectID)
        {
            Name = name;
            SubjectId = subjectID;
        }

        public readonly string Name;
        public readonly int SubjectId;
    }
}
