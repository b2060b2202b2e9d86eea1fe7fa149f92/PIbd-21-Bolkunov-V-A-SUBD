using UniversityJournalDb.Models;
using UniversityJournalDb.SearchModels;
using UniversityJournalDb.CreationModels;

namespace UniversityJournalDb.Storages
{
    public class TaskStudentStorage : AbstractStorage<TaskStudentModel, TaskStudentCreationModel, TaskStudentSearchModel>
    {
        public TaskStudentStorage(UniversityJournalDbContext context) : base(context) { }

        protected override TaskStudentModel creationModelToModel(TaskStudentCreationModel model)
        {
            return new TaskStudentModel() { TaskId = model.TaskId, StudentId = model.StudentId, FinishDate = model.FinishDate, Grade = model.Grade };
        }

        protected override bool isBinded(TaskStudentModel model, TaskStudentSearchModel creationModel)
        {
            return creationModel.TaskId != null && model.TaskId == creationModel.TaskId ||
                     creationModel.StudentId != null && model.StudentId == creationModel.StudentId ||
                     creationModel.FinishDate != null && model.FinishDate == creationModel.FinishDate ||
                     creationModel.Grade != null && model.Grade == creationModel.Grade;
        }

        protected override TaskStudentModel updateModelData(TaskStudentModel model, TaskStudentCreationModel newData)
        {
            model.TaskId = newData.TaskId;
            model.StudentId = newData.StudentId;
            model.FinishDate = newData.FinishDate;
            model.Grade = newData.Grade;
            return model;
        }
    }
}
