using UniversityJournalDb.Models;
using UniversityJournalDb.SearchModels;
using UniversityJournalDb.CreationModels;

namespace UniversityJournalDb.Storages
{
    public class SubjectStorage : AbstractStorage<SubjectModel, SubjectCreationModel, SubjectSearchModel>
    {
        public SubjectStorage() : base() { }

        protected override SubjectModel creationModelToModel(SubjectCreationModel model)
        {
            return new SubjectModel() { Name = model.Name, TeacherId = model.TeacherId };
        }

        protected override bool isBinded(SubjectModel model, SubjectSearchModel creationModel)
        {
            return creationModel.Id != null && model.Id == creationModel.Id ||
                     creationModel.Name != null && model.Name == creationModel.Name ||
                     creationModel.TeacherId != null && model.TeacherId == creationModel.TeacherId;
        }

        protected override SubjectModel updateModelData(SubjectModel model, SubjectCreationModel newData)
        {
            model.Name = newData.Name;
            model.TeacherId = newData.TeacherId;
            return model;
        }

        public override string ToString()
        {
            return "Subject Storage";
        }
    }
}
