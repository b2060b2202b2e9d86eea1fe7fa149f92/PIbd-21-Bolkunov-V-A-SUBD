using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UniversityJournalDb.Views;

namespace UniversityJournalDb.Storages
{
    public class ViewStorage
    {
        protected internal readonly UniversityJournalDbContext dbContext;
        public ViewStorage(UniversityJournalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<AllTasksView> GetAllTasksView()//Lab-3, View-1
        {
            return dbContext.AllTasksViews.ToList();
        }

        public ICollection<AllGradesView> GetAllGradesView()//Lab-3, View-2
        {
            return dbContext.AllGradesViews.ToList();
        }

        public ICollection<AllGradesWithinMonth> GetAllGradesViewWithinMonth()//Lab-3, View-3
        {
            return dbContext.AllGradesWithinMonths.ToList();
        }
    }
}
