using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using UniversityJournalDb.CreationModels;
using UniversityJournalDb.Interfaces;
using UniversityJournalDb.Models;
using UniversityJournalDb.SearchModels;
using UniversityJournalDb.Storages;
using UniversityJournalView.MVVM;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UniversityJournalView.Views;

namespace UniversityJournalView.ViewModels
{
    public class StoragesViewModel:INotifyPropertyChanged
    {
        private List<IStorageCRUD> storages;
        public List<IStorageCRUD> Storages
        {
            get => storages;
        }

        public Command ShowViews
        {
            get => new Command
                (
                    o => true,
                    o =>
                    {
                        ViewsWindow viewsWindow = new ViewsWindow();
                        viewsWindow.ShowDialog();
                    }
                );
        }

        public Command AddCommand 
        {
            get => new Command
                (
                    o => true,
                    o =>
                    {
                        try
                        {
                            currentStorage.Create(parseEditStringToCreationModel());
                            refreshEntites();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                );
        }

        public Command RemoveCommand
        {
            get => new Command
                (
                    o => true,
                    o =>
                    {
                        try
                        {
                            currentStorage.Delete(selectedEntity);
                            refreshEntites();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                );
        }

        public Command EditCommand
        {
            get => new Command
                (
                    o => true,
                    o =>
                    {
                        try
                        { 
                            currentStorage.Update(selectedEntity, parseEditStringToCreationModel());
                            refreshEntites();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                );
        }

        public Command RefreshCommand
        {
            get => new Command
                (
                    o => true,
                    o =>
                    {
                        refreshEntites();
                    }
                );
        }

        public StoragesViewModel()
        {
            storages = new List<IStorageCRUD>();
            storages.Add(new GroupStorage());
            storages.Add(new StudentStorage());
            storages.Add(new SubjectStorage());
            storages.Add(new TaskStorage());
            storages.Add(new TaskStudentStorage());
            storages.Add(new TeacherStorage());
            currentStorage = storages[0];
            refreshEntites();
        }

        private IStorageCRUD currentStorage;
        public IStorageCRUD CurrentStorage
        {
            get => currentStorage;
            set
            {
                currentStorage = value;
                OnPropertyChanged();
                refreshEntites();
            }
        }

        private dynamic currentEntities;
        public dynamic CurrentEntities
        {
            get => currentEntities;
            set
            {
                currentEntities = value;
                OnPropertyChanged();
            }
        }

        private object selectedEntity;
        public object SelectedEntity
        {
            get => selectedEntity;
            set
            {
                selectedEntity = value;
                OnPropertyChanged();
                selectedEntityToEditString();
            }
        }

        private string editString;
        public string EditString
        {
            get => editString;
            set
            {
                editString = value;
                OnPropertyChanged();
            }
        }

        private void selectedEntityToEditString()
        {
            if (SelectedEntity is null) return;

            switch (SelectedEntity)
            {
                case GroupModel model:
                    EditString = $"{model.Name};{model.CreationYear}";
                    break;
                case StudentModel model:
                    EditString = $"{model.Name};{model.Birthday.ToShortDateString()};{model.GroupId}";
                    break;
                case SubjectModel model:
                    EditString = $"{model.Name};{model.TeacherId}";
                    break;
                case TaskModel model:
                    EditString = $"{model.Name};{model.SubjectId}";
                    break;
                case TaskStudentModel model:
                    EditString = $"{model.TaskId};{model.StudentId};{model.Grade};{model.FinishDate.ToShortDateString()}";
                    break;
                case TeacherModel model:
                    EditString = $"{model.Name};{model.Birthday.ToShortDateString()}";
                    break;
                default:
                    return;
            }
        }

        private dynamic parseEditStringToCreationModel()
        {
            if (editString == null || String.IsNullOrEmpty(editString)) return null;
            string[] tokens = editString.Split(';');
            switch (CurrentStorage)
            {
                case GroupStorage storage:
                    return new GroupCreationModel(tokens[0], short.Parse(tokens[1]));
                case StudentStorage storage:
                    return new StudentCreationModel(tokens[0], DateTime.Parse(tokens[1]), int.Parse(tokens[2]));
                case SubjectStorage storage:
                    return new SubjectCreationModel(tokens[0], int.Parse(tokens[1]));
                case TaskStorage storage:
                    return new TaskCreationModel(tokens[0], int.Parse(tokens[1]));
                case TaskStudentStorage storage:
                    return new TaskStudentCreationModel(int.Parse(tokens[0]), int.Parse(tokens[1]), short.Parse(tokens[2]), DateTime.Parse(tokens[3]));
                case TeacherStorage storage:
                    return new TeacherCreationModel(tokens[0], DateTime.Parse(tokens[1]));
                default:
                    return null;
            }
        }

        private void refreshEntites()
        {
            switch (CurrentStorage)
            {
                case GroupStorage storage:
                    CurrentEntities = new ObservableCollection<GroupModel>(storage.Read(null));
                    break;
                case StudentStorage storage:
                    CurrentEntities = new ObservableCollection<StudentModel>(storage.Read(null));
                    break;
                case SubjectStorage storage:
                    CurrentEntities = new ObservableCollection<SubjectModel>(storage.Read(null));
                    break;
                case TaskStorage storage:
                    CurrentEntities = new ObservableCollection<TaskModel>(storage.Read(null));
                    break;
                case TaskStudentStorage storage:
                    CurrentEntities = new ObservableCollection<TaskStudentModel>(storage.Read(null));
                    break;
                case TeacherStorage storage:
                    CurrentEntities = new ObservableCollection<TeacherModel>(storage.Read(null));
                    break;
                default:
                    return;
            }
            SelectedEntity = null;
            EditString = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
