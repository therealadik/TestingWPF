using System.Collections.ObjectModel;
using Testing.Models;

namespace Testing.ViewModels
{
    internal class AppTaskViewModel : BaseViewModel
    {
        public ObservableCollection<AppTaskState> States { get; set; }

        private AppTask appTask;

        public AppTaskViewModel(AppTask task)
        {
            this.appTask = task;
            States = [AppTaskState.InProgress, AppTaskState.Completed];
        }

        public int Id => appTask.Id;
        public string Name
        {
            get => appTask.Name;
            set
            {
                if (appTask.Name != value)
                {
                    appTask.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Type
        {
            get => appTask.Type.ToString();
        }

        public string Body
        {
            get => appTask.Body;
            set
            {
                if (appTask.Body != value)
                {
                    appTask.Body = value;
                    OnPropertyChanged();
                }
            }
        }

        public AppTaskState State
        {
            get => appTask.State;
            set
            {
                if (appTask.State != value)
                {
                    appTask.State = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
