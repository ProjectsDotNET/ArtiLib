using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace ArtiLib.Data.DaoUtils
{
    public class DaoOperations<T> : ConnectionAccess
    {
        public virtual void DeleteAll()
        {
            using (var Transaction = new TransactionScope())
            {
                Connection.Execute(typeof(T).DeleteAllQuery());
                Transaction.Complete();
            }
        }

        public virtual void DeleteByCriteria(object criteria, object value)
        {
            using (var Transaction = new TransactionScope())
            {
                Connection.Execute(typeof(T).DeleteByCriteriaQuery(criteria), value);
                Transaction.Complete();
            }
        }

        public virtual void DeleteById(int Id)
        {
            using (var Transaction = new TransactionScope())
            {
                Connection.Execute(typeof(T).DeleteByIdQuery(), new { Id });
                Transaction.Complete();
            }
        }

        public virtual void DeleteByWhereExpression(string whereExpression)
        {
            using (var Transaction = new TransactionScope())
            {
                Connection.Execute(typeof(T).DeleteAllQuery());
                Transaction.Complete();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<T>(typeof(T).GetAllQuery());
                Transaction.Complete();
                return result;
            }
        }

        public virtual IEnumerable<T> GetByCriteria(object criteria, object value)
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<T>(typeof(T).GetByCriteriaQuery(criteria), value);
                Transaction.Complete();
                return result;
            }
        }

        public virtual T GetById(int Id)
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<T>(typeof(T).GetByIdQuery(), new { Id }).Single();
                Transaction.Complete();
                return result;
            }
        }

        public virtual IEnumerable<T> GetByWhereExpression(string whereExpression)
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<T>(typeof(T).GetByGetByWhereExpressionQuery(whereExpression));
                Transaction.Complete();
                return result;
            }
        }

        public virtual int Insert(T entity)
        {
            using (var Transaction = new TransactionScope())
            {
                var result = Connection.Query<int>(typeof(T).InsertQuery(), entity).Single();
                Transaction.Complete();
                return result;
            }
        }

        public virtual void Update(T entity)
        {
            using (var Transaction = new TransactionScope())
            {
                Connection.Execute(typeof(T).UpdateQuery(), entity);
                Transaction.Complete();
            }
        }

        public virtual void UpdateAll(T entity)
        {
            using (var Transaction = new TransactionScope())
            {
                Connection.Execute(typeof(T).UpdateQuery(false));
                Transaction.Complete();
            }
        }
    }
}