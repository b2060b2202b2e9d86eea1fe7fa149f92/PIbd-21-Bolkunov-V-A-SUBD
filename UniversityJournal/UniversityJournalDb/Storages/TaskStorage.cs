using UniversityJournalDb.Models;
using UniversityJournalDb.SearchModels;
using UniversityJournalDb.CreationModels;

namespace UniversityJournalDb.Storages
{
    public class TaskStorage : AbstractStorage<TaskModel, TaskCreationModel, TaskSearchModel>
    {
        public TaskStorage(UniversityJournalDbContext context) : base(context) { }

        protected override TaskModel creationModelToModel(TaskCreationModel model)
        {
            return new TaskModel() { Name = model.Name, SubjectId = model.SubjectId };
        }

        protected override bool isBinded(TaskModel model, TaskSearchModel creationModel)
        {
            return creationModel.Id != null && model.Id == creationModel.Id ||
                     creationModel.Name != null && model.Name == creationModel.Name ||
                     creationModel.SubjectId != null && model.SubjectId == creationModel.SubjectId;
        }

        protected override TaskModel updateModelData(TaskModel model, TaskCreationModel newData)
        {
            model.Name = newData.Name;
            model.SubjectId = newData.SubjectId;
            return model;
        }
    }
}
