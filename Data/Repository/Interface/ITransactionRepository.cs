using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using Data.ViewModel;

namespace Data.Repository.Interface
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get();

        Transaction Get(int Id);
        int Create(TransactionVM transactionVM);
        int Update(int Id, TransactionVM transactionVM);
        int Delete(int Id);
    }
}
