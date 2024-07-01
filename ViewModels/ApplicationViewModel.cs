using System.Collections.ObjectModel;
using System.Windows.Input;
using Testing.Commands;
using Testing.Models;
using Testing.Views;

namespace Testing.ViewModels
{
    internal class ApplicationViewModel : BaseViewModel
    {
        // Коллекция для хранения элементов типа DocumentViewModel и TaskViewModel
        public ObservableCollection<object> Items { get; set; }

        private object selectedItem;

        public object SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        // команды для добавления документов и задач
        public ICommand AddDocumentCommand { get; set; }
        public ICommand AddTaskCommand { get; set; }
        public ICommand OpenItemCommand { get; set; }

        public ApplicationViewModel()
        {
            GenerateExample();

            this.AddDocumentCommand = new RelayCommand(_ => AddDocument());
            this.AddTaskCommand = new RelayCommand(_ => AddTask());
            this.OpenItemCommand = new RelayCommand(OpenItem);
        }

        private void GenerateExample()
        {
            Items =
            [
                new DocumentViewModel(new Document(id: 1, name: "Оформление кода.doc")),
                new DocumentViewModel(new Document(id: 2, name: "Список задач.doc")),
                new DocumentViewModel(new Document(id: 3, name: "Заказы.doc")),

                new AppTaskViewModel(new AppTask(id: 4, name: "Оформи код")),
                new AppTaskViewModel(new AppTask(id: 5, name: "Посмотри задачи")),
                new AppTaskViewModel(new AppTask(id: 6, name: "Выполни заказы"))
            ];
        }

        private void AddDocument()
        {
            var newDocument = new DocumentViewModel(new Document(id: Items.Count + 1, name: "New Document"));
            this.Items.Add(newDocument); // Добавление нового документа в коллекцию
        }

        private void AddTask()
        {
            var newTask = new AppTaskViewModel(new AppTask(id: Items.Count + 1, name: "New Task"));
            this.Items.Add(newTask); // Добавление новой задачи в коллекцию
        }

        private void OpenItem(object item)
        {
            if (item is DocumentViewModel documentViewModel)
            {
                var documentView = new DocumentView
                {
                    DataContext = documentViewModel
                };

                documentView.ShowDialog();
            }
            else if (item is AppTaskViewModel appTaskViewModel)
            {
                var appTaskView = new AppTaskView
                {
                    DataContext = appTaskViewModel
                };

                appTaskView.ShowDialog();
            }
        }
    }
}
