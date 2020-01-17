using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Context;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;

namespace Data.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        MyContext myContext = new MyContext();

        public int Create(TransactionVM transactionVM)
        {
            var push = new Transaction(transactionVM);
            myContext.Transactions.Add(push);
            return myContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            var delete = myContext.Transactions.Find(Id);
            if (delete != null)
            {
                delete.Delete();
                return myContext.SaveChanges();
            }
            return 0;
            //throw new NotImplementedException();
        }

        public IEnumerable<Transaction> Get()
        {
            return myContext.Transactions.Where(t => t.IsDelete == false).ToList();
            //throw new NotImplementedException();
        }

        public Transaction Get(int Id)
        {
            return myContext.Transactions.Find(Id);
            //throw new NotImplementedException();
        }

        public int Update(int Id, TransactionVM transactionVM)
        {
            var result = 0;
            var update = myContext.Transactions.Find(Id);
            update.Update(transactionVM);
            result = myContext.SaveChanges();
            return result;
            //throw new NotImplementedException();
        }
    }
}
