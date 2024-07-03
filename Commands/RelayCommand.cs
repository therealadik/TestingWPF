using System.Windows.Input;

namespace Testing.Commands
{
    /// <summary>
    /// Реализация команд для обработки действий.
    /// </summary>
    internal sealed class RelayCommand : ICommand
    {
        #region Поля и свойства
        /// <summary>
        /// Делегат для выполнения логики команды.
        /// </summary>
        private readonly Action<object> execute;

        /// <summary>
        /// Делегат для определения, может ли команда выполняться.
        /// </summary>
        private readonly Func<object, bool> canExecute;
        #endregion Поля и свойства

        #region Методы
        /// <summary>
        /// Определяет, может ли команда выполняться.
        /// </summary>
        /// <param name="parameter">Параметр, используемый командой.</param>
        /// <returns>Значение <c>true</c>, если команда может выполняться; в противном случае — <c>false</c>.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Выполняет логику команды.
        /// </summary>
        /// <param name="parameter">Параметр, используемый командой.</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
        #endregion Методы

        #region События
        /// <summary>
        /// Событие, вызываемое при изменении состояния, указывающего, может ли команда выполняться.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion События

        #region Конструкторы
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">Логика команды, которая будет выполняться.</param>
        /// <param name="canExecute">Логика для определения, может ли команда выполняться.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion Конструкторы
    }
}
