using UniversityJournalDb.Models;
using UniversityJournalDb.SearchModels;
using UniversityJournalDb.CreationModels;
using System.Linq;
using System;

namespace UniversityJournalDb.Storages
{
    public class StudentStorage : AbstractStorage<StudentModel, StudentCreationModel, StudentSearchModel>
    {
        public StudentStorage() : base() { }

        protected override StudentModel creationModelToModel(StudentCreationModel model)
        {
            return new StudentModel() { Name = model.Name, Birthday = model.Birthday, GroupId = model.GroupId };
        }

        protected override bool isBinded(StudentModel model, StudentSearchModel creationModel)
        {
            return creationModel.Id != null && model.Id == creationModel.Id ||
                     creationModel.Name != null && model.Name == creationModel.Name ||
                     creationModel.Birthday != null && model.Birthday == creationModel.Birthday ||
                     creationModel.GroupId != null && model.GroupId == creationModel.GroupId;
        }

        protected override StudentModel updateModelData(StudentModel model, StudentCreationModel newData)
        {
            model.Name = newData.Name;
            model.Birthday = newData.Birthday;
            using (var context = new UniversityJournalDbContext())
            {
                if(!context.Groups.Contains(g => g.id == newData.GroupId))
                {
                    throw new NotFoundException("Group with id="+newData.GroupId+" was not found");
                }
            }
            model.GroupId = newData.GroupId;
            return model;
        }

        public override string ToString()
        {
            return "Student Storage";
        }
    }
}
