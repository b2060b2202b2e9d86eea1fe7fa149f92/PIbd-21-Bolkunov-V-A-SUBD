using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UniversityJournalDb.Storages
{
    public abstract class AbstractStorage<TModel, TCreate, TSearch> 
        where TModel : class 
        where TCreate : class 
        where TSearch : class
    {
        protected internal readonly DbContext dbContext;
        public AbstractStorage(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
    }
}
