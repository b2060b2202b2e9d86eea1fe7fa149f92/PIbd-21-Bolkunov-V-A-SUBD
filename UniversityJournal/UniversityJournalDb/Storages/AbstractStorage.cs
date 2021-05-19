using System.Collections.Generic;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniversityJournalDb.Interfaces;

namespace UniversityJournalDb.Storages
{
    public abstract class AbstractStorage<TModel, TCreate, TSearch> : IStorageCRUD
        where TModel : class 
        where TCreate : class 
        where TSearch : class
    {
        private DbContext dbContext { get => UniversityJournalDbContext.GetDbContext(); }

        public AbstractStorage() { }

        public TModel Create(TCreate creationModel)
        {
            if (creationModel is null) return null;
            var newEntry = creationModelToModel(creationModel);
            dbContext.Set<TModel>().Add(newEntry);
            dbContext.SaveChanges();
            return newEntry;
        }

        public void Delete(TModel entityToDelete)
        {
            if (entityToDelete is null) return;
            dbContext.Set<TModel>().Remove(entityToDelete);
            dbContext.SaveChanges();
        }

        public ICollection<TModel> Read(TSearch entityToFind)
        {
            if (entityToFind is null) return dbContext.Set<TModel>().ToList();
            return dbContext.Set<TModel>().Where(mod => isBinded(mod, entityToFind)).ToList();
        }

        public TModel Update(TModel entityToUpdate, TCreate newValues)
        {
            if (entityToUpdate is null || newValues is null) return null;
            updateModelData(entityToUpdate, newValues);
            dbContext.Set<TModel>().Update(entityToUpdate);
            dbContext.SaveChanges();
            return entityToUpdate;
        }

        protected abstract TModel creationModelToModel(TCreate model);
        protected abstract bool isBinded(TModel model, TSearch creationModel);
        protected abstract TModel updateModelData(TModel model, TCreate newData);

        public object Create(object entityToCreate)
        {
            return Create((TCreate)entityToCreate);
        }

        public IEnumerable Read(object entityToFind)
        {
            return Read((TSearch)entityToFind);
        }

        public object Update(object entityToUpdate, object newValues)
        {
            return Update((TModel)entityToUpdate, (TCreate)newValues);
        }

        public void Delete(object entityToDelete)
        {
            Delete((TModel)entityToDelete);
        }
    }
}
