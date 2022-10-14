using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart
{
    /// <summary>
    /// Модель представления
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //using Prism.Commands;
        public DelegateCommand ClickCommand { get; }

        

        public MainWindowViewModel()
        {
            ClickCommand = new DelegateCommand(OnClick);
        }

        //DbContext реализует интерфейс IDisposable(Предоставляет механизм для освобождения неуправляемых ресурсов.)
        private void OnClick()
        {
            using (MyDbContext context = new MyDbContext())
            {

            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
/*
https://learn.microsoft.com/ru-ru/dotnet/api/system.runtime.compilerservices.callermembernameattribute?view=net-6.0
https://habr.com/ru/post/201396/
[CallerMemberName]
Позволяет получить имя свойства или метода вызывающего метод объекта.
 
DbContext реализует интерфейс IDisposable(Предоставляет механизм для освобождения неуправляемых ресурсов.)
 */