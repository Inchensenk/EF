using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<User>Users { get;}

        //using Prism.Commands;
        public DelegateCommand ClickCommand { get; }

        

        public MainWindowViewModel()
        {
            ClickCommand = new DelegateCommand(OnClick);

            Users = new ObservableCollection<User>();
        }

        //Так как DbContext реализует интерфейс IDisposable(Предоставляет механизм для освобождения неуправляемых ресурсов.),
        //то MyDbContext можно поместить в блок using
        private void OnClick()
        {
            //Для каждого изменения, для каждого подключения к БД,
            //в using создаем новый экземпляр контекста
            //в момент создания эземпляра 
            using (MyDbContext context = new MyDbContext())
            {
                /*
                User user1 = new User { Name = "Tom", Age=33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                //Добавление в БД
                context.Users.AddRange(user1, user2);
                context.SaveChanges();
                */

                foreach (var user in context.Users)
                {
                    Users.Add(user);
                }
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