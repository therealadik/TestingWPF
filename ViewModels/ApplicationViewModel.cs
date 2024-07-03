using System.Collections.ObjectModel;
using System.Windows.Input;
using Testing.Commands;
using Testing.Models;
using Testing.Views;

namespace Testing.ViewModels
{
    /// <summary>
    /// Модель представления для приложения, которая управляет коллекцией элементов.
    /// и командами для добавления и открытия документов и задач.
    /// </summary>
    internal sealed class ApplicationViewModel
    {
        #region Поля и свойства
        /// <summary>
        /// Коллекция для хранения элементов типа DocumentViewModel и AppTaskViewModel.
        /// </summary>
        public ObservableCollection<object> Items { get; set; }

        /// <summary>
        /// Комманда для добавления документа.
        /// </summary>
        public ICommand AddDocumentCommand { get; set; }

        /// <summary>
        /// Команда для добавления задачи.
        /// </summary>
        public ICommand AddTaskCommand { get; set; }

        /// <summary>
        /// Команда открытия элемента.
        /// </summary>
        public ICommand OpenItemCommand { get; set; }
        #endregion Поля и свойства

        #region Методы
        /// <summary>
        /// Создание начальных обьектов в приложении.
        /// </summary>
        private void GenerateExample()
        {
            Items =
            [
                new DocumentViewModel(new Document(1,"Оформление кода.doc")),
                new DocumentViewModel(new Document(2, "Список задач.doc")),
                new DocumentViewModel(new Document(3, "Заказы.doc")),

                new AppTaskViewModel(new AppTask(4, "Оформи код")),
                new AppTaskViewModel(new AppTask(5,  "Посмотри задачи")),
                new AppTaskViewModel(new AppTask(6,"Выполни заказы"))
            ];
        }

        /// <summary>
        /// Добавление документа.
        /// </summary>
        private void AddDocument()
        {
            var newDocument = new DocumentViewModel(new Document(Items.Count + 1, "New Document"));
            this.Items.Add(newDocument);
        }

        /// <summary>
        /// Добавление задачи.
        /// </summary>
        private void AddTask()
        {
            var newTask = new AppTaskViewModel(new AppTask(Items.Count + 1, "New Task"));
            this.Items.Add(newTask);
        }

        /// <summary>
        /// Открыть элемент.
        /// </summary>
        /// <param name="item">Открываемый элемент.</param>
        private void OpenItem(object item)
        {
            if (item is DocumentViewModel documentViewModel)
            {
                var documentView = new DocumentView { DataContext = documentViewModel };
                documentView.ShowDialog();
            }
            else if (item is AppTaskViewModel appTaskViewModel)
            {
                var appTaskView = new AppTaskView { DataContext = appTaskViewModel };
                appTaskView.ShowDialog();
            }
        } 
        #endregion Методы

        #region Конструктор
        /// <summary>
        /// Конструктор с генерацией элементов и привязкой команд.
        /// </summary>
        public ApplicationViewModel()
        {
            GenerateExample();

            this.AddDocumentCommand = new RelayCommand(_ => AddDocument());
            this.AddTaskCommand = new RelayCommand(_ => AddTask());
            this.OpenItemCommand = new RelayCommand(OpenItem);
        }
        #endregion Конструктор
    }
}
