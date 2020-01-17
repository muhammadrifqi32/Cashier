using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using Data.ViewModel;

namespace Data.Repository.Interface
{
    public interface ITransactionItemRepository
    {
        IEnumerable<TransactionItem> Get();
        TransactionItem Get(int Id);
        int Create(TransactionItemVM transactionItemVM);
        int Update(int Id, TransactionItemVM transactionItemVM);
        int Delete(int Id);
    }
}
