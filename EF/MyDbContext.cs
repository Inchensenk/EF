using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFCoreStart
{
    public class MyDbContext : DbContext
    {

        /// <summary>
        /// Создаем таблицу пользователей
        /// 
        /// DbSet 
        /// Описывает набор сущностных классов, который затем можно использовать в коде для создания запросов CRUD(create, read, update, delete) к данным.
        /// С помощью экземпляров этого класса описываются различные объекты базы данных (таблицы, представления, хранимые процедуры и т.д.)
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;

        //Конструктор вызовится после переопределенного метода OnConfiguring
        /// <summary>
        /// Конструктор по умолчанию
        /// EnsureCreated(): гарантирует, что БД будет создана.
        /// </summary>
        public MyDbContext()
        {
           //Database.EnsureCreated();//если БД не создана то она создастся

            //var canConnect = Database.CanConnect();//дает ответ, можем подключиться к бд или нет
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=s-dev-01; Database=EntityExplanationDb; Trusted_Connection=True; Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Выбираем сущность User, для нее выбираем при помощи экспрешна Id
            //HasColumnName("user_id") название коллонки в базе данных
            //изменение схемы
            modelBuilder.Entity<User>().Property(n => n.Id).HasColumnName("User_id");

            modelBuilder.Entity<User>().Ignore(n => n.PhoneNumber);
        }

    }
}
/*
DbContext
Является базовым классом Entity Framework и предоставляет широкие возможности по работе с базой данных: 
создание запросов, отслеживание изменений и сохранение данных в базе.

DbSet
Описывает набор сущностных классов, который затем можно использовать в коде для создания запросов CRUD (create, read, update, delete) к данным. 
С помощью экземпляров этого класса описываются различные объекты базы данных (таблицы, представления, хранимые процедуры и т.д.)


https://metanit.com/sharp/efcore/2.16.php 

Метод Database.EnsureCreated() и его асинхронная версия Database.EnsureCreatedAsync():
гарантируют, что база данных будет создана.

Метод Database.EnsureDeleted() и его асинхронная версия Database.EnsureDeletedAsync():
гарантируют, что база данных будет удалена.

Database.CanConnect
Еще один метод, который стоит отметить, это Database.CanConnect() и его асинхронная версия Database.CanConnectAsync(). 
Данный метод возвращает true, если бд доступна, и false, если бд не доступна:

using (ApplicationContext db = new ApplicationContext())
{
    bool isAvalaible = db.Database.CanConnect();
    // bool isAvalaible2 = await db.Database.CanConnectAsync();
    if (isAvalaible) Console.WriteLine("База данных доступна");
    else Console.WriteLine("База данных не доступна");
}



 */