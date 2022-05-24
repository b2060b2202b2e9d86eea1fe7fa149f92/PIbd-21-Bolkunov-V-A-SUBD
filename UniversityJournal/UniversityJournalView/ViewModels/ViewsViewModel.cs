using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using UniversityJournalDb.Storages;
using UniversityJournalDb.CreationModels;
using UniversityJournalDb.SearchModels;
using UniversityJournalDb.Views;
using UniversityJournalView.MVVM;
using System.Collections.ObjectModel;

namespace UniversityJournalView.ViewModels
{
    public class ViewsViewModel:INotifyPropertyChanged
    {
        private ViewStorage storage;

        public Command RefreshCommand { get; private set; }

        public ViewsViewModel()
        {
            storage = new ViewStorage();
            refreshViews();

            RefreshCommand = new Command
                (
                    o => true,
                    o => 
                    {
                        refreshViews();
                    }
                );
        }

        private ObservableCollection<AllTasksView> allTasksViews;
        public ObservableCollection<AllTasksView> AllTasksViews 
        {
            get => allTasksViews;
            set
            {
                allTasksViews = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AllGradesView> allGradesViews;
        public ObservableCollection<AllGradesView> AllGradesViews
        {
            get => allGradesViews;
            set
            {
                allGradesViews = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AllGradesWithinMonth> allGradesViewWithinMonthViews;
        public ObservableCollection<AllGradesWithinMonth> AllGradesViewWithinMonthViews
        {
            get => allGradesViewWithinMonthViews;
            set
            {
                allGradesViewWithinMonthViews = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void refreshViews()
        {
            AllTasksViews =
                new ObservableCollection<AllTasksView>(storage.GetAllTasksView());
            AllGradesViews =
                new ObservableCollection<AllGradesView>(storage.GetAllGradesView());
            AllGradesViewWithinMonthViews =
                new ObservableCollection<AllGradesWithinMonth>(storage.GetAllGradesViewWithinMonth());
        }
    }
}
