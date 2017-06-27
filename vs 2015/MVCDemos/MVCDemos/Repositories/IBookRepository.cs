using MVCDemos.Models;
using System;
using System.Collections.Generic;

namespace MVCDemos.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Remove(Book book);
        Book GetById(int bookId);
        Book GetByName(string name);
        ICollection<Book> GetAll();
    }
}