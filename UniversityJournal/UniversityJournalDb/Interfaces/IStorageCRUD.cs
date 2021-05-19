using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace UniversityJournalDb.Interfaces
{
    public interface IStorageCRUD
    {
        object Create(object entityToCreate);
        IEnumerable Read(object entityToFind);
        object Update(object entityToUpdate, object newValues);
        void Delete(object entityToDelete);
    }
}
