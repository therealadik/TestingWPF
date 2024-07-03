using System.Windows.Input;
using Testing.Commands;
using Testing.Models;

namespace Testing.ViewModels
{
    /// <summary>
    ///реализация ViewModel для Document модели.
    /// </summary>
    
    internal sealed class DocumentViewModel : BaseViewModel
    {
        #region Поля и свойства
        /// <summary>
        /// Команда подписи документа.
        /// </summary>
        public ICommand SignDocumentCommand { get; set; }

        public string Name
        {
            get
            {
                return document.Name;
            }

            set
            {
                if (document.Name != value)
                {
                    document.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Body
        {
            get
            {
                return document.Body;
            }

            set
            {
                if (document.Body != value)
                {
                    document.Body = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Id => document.Id;
        /// <summary>
        /// Получение типа модели (например Задача или Документ).
        /// </summary>
        public string Type => document.Type.ToString();

        /// <summary>
        /// Получение подписи (пустая строка если подпись отсутствует).
        /// </summary>
        public string DigitalSignature => document.DigitalSignature == Guid.Empty ? string.Empty : document.DigitalSignature.ToString();

        /// <summary>
        /// Проверка можно ли подписывать документ.
        /// </summary>
        public bool CanSignDocument => document.DigitalSignature == Guid.Empty;

        /// <summary>
        /// Привязанный документ.
        /// </summary>
        private readonly Document document;
        #endregion Поля и свойства

        #region Методы
        /// <summary>
        /// Подписывает документ, если подпись пустая.
        /// </summary>
        private void SignDocument()
        {
            if (document.DigitalSignature == Guid.Empty)
            {
                document.DigitalSignature = Guid.NewGuid();
                OnPropertyChanged(nameof(DigitalSignature));
                OnPropertyChanged(nameof(CanSignDocument));
            }
        }
        #endregion Методы

        #region Конструкторы

        /// <summary>
        /// </summary>
        /// <param name="document">Создаваемый документ.</param>
        public DocumentViewModel(Document document)
        {
            this.document = document;
            SignDocumentCommand = new RelayCommand(_ => SignDocument(), _ => CanSignDocument);
        }
        #endregion Конструкторы
    }
}
