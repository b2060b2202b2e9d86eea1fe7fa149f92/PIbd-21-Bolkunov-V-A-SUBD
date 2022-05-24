using System;
using System.Collections.Generic;

namespace UniversityJournalDb.CreationModels
{
    public class GroupCreationModel
    {
        public GroupCreationModel(string name, short creationYear)
        {
            Name = name;
            CreationYear = creationYear;
        }

        public readonly string Name;
        public readonly short CreationYear;
    }
}
