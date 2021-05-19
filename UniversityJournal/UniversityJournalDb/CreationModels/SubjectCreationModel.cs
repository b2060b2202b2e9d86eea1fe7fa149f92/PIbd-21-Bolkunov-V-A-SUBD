using System;
using System.Collections.Generic;

namespace UniversityJournalDb.CreationModels
{
    public class SubjectCreationModel
    {
        public SubjectCreationModel(string name, int teacherID)
        {
            Name = name;
            TeacherId = teacherID;
        }

        public readonly string Name;
        public readonly int TeacherId;
    }
}
