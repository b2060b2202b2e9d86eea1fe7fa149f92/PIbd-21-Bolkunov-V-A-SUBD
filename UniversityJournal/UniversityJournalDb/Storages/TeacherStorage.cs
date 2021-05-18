using UniversityJournalDb.Models;
using UniversityJournalDb.SearchModels;
using UniversityJournalDb.CreationModels;

namespace UniversityJournalDb.Storages
{
    public class TeacherStorage : AbstractStorage<TeacherModel, TeacherCreationModel, TeacherSearchModel>
    {
        public TeacherStorage(UniversityJournalDbContext context) : base(context) { }

        protected override TeacherModel creationModelToModel(TeacherCreationModel model)
        {
            return new TeacherModel() { Name = model.Name, Birthday = model.Birthday };
        }

        protected override bool isBinded(TeacherModel model, TeacherSearchModel creationModel)
        {
            return creationModel.Id != null && model.Id == creationModel.Id ||
                     creationModel.Name != null && model.Name == creationModel.Name ||
                     creationModel.Birthday != null && model.Birthday == creationModel.Birthday;
        }

        protected override TeacherModel updateModelData(TeacherModel model, TeacherCreationModel newData)
        {
            model.Name = newData.Name;
            model.Birthday = newData.Birthday;
            return model;
        }
    }
}
