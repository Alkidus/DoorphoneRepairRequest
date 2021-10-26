using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repository
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> GetAllList(); // получение всех объектов
        T GetByID(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Edit(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
    //public interface IRepository
    //{
    //    IEnumerable<Adress> GetAdressList();
    //    Adress GetAdress(int id);
    //    void CreateAdress(Adress item);
    //    void EditAdress(Adress item);
    //    void DeleteAdress(int id);
    //    void Save();
    //}
}
