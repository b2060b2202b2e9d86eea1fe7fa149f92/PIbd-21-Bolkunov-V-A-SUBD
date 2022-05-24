using System;
using System.Collections.Generic;

namespace UniversityJournalDb.CreationModels
{
    public class TaskStudentCreationModel
    {
        public TaskStudentCreationModel(int taskId, int studentId, short grade, DateTime finishDate)
        {
            TaskId = taskId; StudentId = studentId; Grade = grade; FinishDate = finishDate;
        }

        public readonly int TaskId;
        public readonly int StudentId;
        public readonly short Grade;
        public readonly DateTime FinishDate;
    }
}
