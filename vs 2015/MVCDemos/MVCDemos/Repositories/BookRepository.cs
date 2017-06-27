using System;
using System.Collections.Generic;
using MVCDemos.Models;
using NHibernate;
using NHibernate.Criterion;

namespace MVCDemos.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void Add(Book book)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(book);
                transaction.Commit();
            }
        }

        public ICollection<Book> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Book>().List();
            }
        }

        public Book GetById(int bookId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Book>(bookId);
        }

        public Book GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                Book product = session
                    .CreateCriteria(typeof(Book))
                    .Add(Restrictions.Eq("BookName", name))
                    .UniqueResult<Book>();
                return product;
            }
        }

        public void Remove(Book book)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(book);
                transaction.Commit();
            }
        }

        public void Update(Book book)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(book);
                transaction.Commit();
            }
        }
    }
}