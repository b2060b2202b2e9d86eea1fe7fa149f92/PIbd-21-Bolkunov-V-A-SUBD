using System;
using System.Collections.Generic;

namespace UniversityJournalDb.CreationModels
{
    public class TeacherCreationModel
    {
        public TeacherCreationModel(string name, DateTime birthday)
        {
            Name = name; Birthday = birthday;
        }

        public readonly string Name;
        public readonly DateTime Birthday;
    }
}
