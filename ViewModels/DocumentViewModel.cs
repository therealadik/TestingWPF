using System.Windows.Input;
using Testing.Commands;
using Testing.Models;

namespace Testing.ViewModels
{
    internal sealed class DocumentViewModel : BaseViewModel
    {
        public ICommand SignDocumentCommand { get; set; }

        private Document document;

        public DocumentViewModel(Document document)
        {
            this.document = document;
            SignDocumentCommand = new RelayCommand(_ => SignDocument(), _ => CanSignDocument);
        }

        public int Id => document.Id;
        public string Name
        {
            get => document.Name;
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
            get => document.Body;
            set
            {
                if (document.Body != value)
                {
                    document.Body = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Type
        {
            get => document.Type.ToString();
        }

        public string DigitalSignature => document.DigitalSignature == Guid.Empty ? "" : document.DigitalSignature.ToString();

        public bool CanSignDocument => document.DigitalSignature == Guid.Empty;

        public void SignDocument()
        {
            if (document.DigitalSignature == Guid.Empty)
            {
                document.DigitalSignature = Guid.NewGuid();
                OnPropertyChanged(nameof(DigitalSignature));
                OnPropertyChanged(nameof(CanSignDocument));
            }
        }
    }
}
