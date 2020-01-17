using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Context;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class TransactionItemRepository : ITransactionItemRepository
    {
        MyContext myContext = new MyContext();
        public int Create(TransactionItemVM transactionItemVM)
        {
            var push = new TransactionItem(transactionItemVM);
            var transaction = myContext.Transactions.Find(transactionItemVM.Transaction);
            push.Transaction = transaction;
            var item = myContext.Items.Find(transactionItemVM.Item);
            push.Item = item;
            myContext.TransactionItems.Add(push);
            return myContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            var delete = myContext.TransactionItems.Find(Id);
            if (delete != null)
            {
                delete.Delete();
                return myContext.SaveChanges();
            }
            return 0;
            //throw new NotImplementedException();
        }

        public IEnumerable<TransactionItem> Get()
        {
            return myContext.TransactionItems.Include("Transaction").Include("Item").Where(ti => ti.IsDelete == false).ToList();
            //throw new NotImplementedException();
        }

        public TransactionItem Get(int Id)
        {
            return myContext.TransactionItems.Include("Transaction").Include("Item").Where(ti => ti.Id == Id && ti.IsDelete == false).FirstOrDefault();
            //throw new NotImplementedException();
        }

        public int Update(int Id, TransactionItemVM transactionItemVM)
        {
            var update = myContext.TransactionItems.Find(Id);
            update.Item = myContext.Items.Where(i => i.Id == transactionItemVM.Item).FirstOrDefault();
            update.Transaction = myContext.Transactions.Where(t => t.Id == transactionItemVM.Transaction).FirstOrDefault();
            update.Update(transactionItemVM);
            return myContext.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
