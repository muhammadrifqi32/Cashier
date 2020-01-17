using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Data.ViewModel;

namespace API.Services.Interface
{
    public interface ITransactionItemService
    {
        IEnumerable<TransactionItem> Get();
        TransactionItem Get(int Id);
        int Create(TransactionItemVM transactionItemVM);
        int Update(int Id, TransactionItemVM transactionItemVM);
        int Delete(int Id);
    }
}
