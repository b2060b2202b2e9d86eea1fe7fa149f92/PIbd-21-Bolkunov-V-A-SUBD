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
        public ViewStorage() { }

        public List<AllTasksView> GetAllTasksView()//Lab-3, View-1
        {
            return UniversityJournalDbContext.GetDbContext().AllTasksViews.ToList();
        }

        public List<AllGradesView> GetAllGradesView()//Lab-3, View-2
        {
            return UniversityJournalDbContext.GetDbContext().AllGradesViews.ToList();
        }

        public List<AllGradesWithinMonth> GetAllGradesViewWithinMonth()//Lab-3, View-3
        {
            return UniversityJournalDbContext.GetDbContext().AllGradesWithinMonths.ToList();
        }

        public override string ToString()
        {
            return "View Storage";
        }
    }
}
