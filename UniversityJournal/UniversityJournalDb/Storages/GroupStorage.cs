using UniversityJournalDb.Models;
using UniversityJournalDb.SearchModels;
using UniversityJournalDb.CreationModels;

namespace UniversityJournalDb.Storages
{
    public class GroupStorage : AbstractStorage<GroupModel, GroupCreationModel, GroupSearchModel>
    {
        public GroupStorage(UniversityJournalDbContext context) : base(context) { }

        protected override GroupModel creationModelToModel(GroupCreationModel model)
        {
            return new GroupModel() { Name = model.Name, CreationYear = model.CreationYear };
        }

        protected override bool isBinded(GroupModel model, GroupSearchModel creationModel)
        {
            return creationModel.Id != null && model.Id == creationModel.Id ||
                    creationModel.Name != null && model.Name == creationModel.Name ||
                    creationModel.CreationYear != null && model.CreationYear == creationModel.CreationYear;
        }

        protected override GroupModel updateModelData(GroupModel model, GroupCreationModel newData)
        {
            model.Name = newData.Name;
            model.CreationYear = newData.CreationYear;
            return model;
        }
    }
}
