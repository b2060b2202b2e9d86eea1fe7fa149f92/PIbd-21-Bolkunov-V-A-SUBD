using System;
using System.Collections.Generic;

namespace UniversityJournalDb.CreationModels
{
    public class StudentCreationModel
    {
        public StudentCreationModel(string name, DateTime birthday, int groupID)
        {
            Name = name;
            Birthday = birthday;
            GroupId = groupID;
        }

        public readonly string Name;
        public readonly DateTime Birthday;
        public readonly int GroupId;
    }
}
