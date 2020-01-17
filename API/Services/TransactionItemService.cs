using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services.Interface;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;

namespace API.Services
{
    public class TransactionItemService : ITransactionItemService
    {
        private ITransactionItemRepository _transactionItemRepository;

        public TransactionItemService() { }

        public TransactionItemService(ITransactionItemRepository transactionItemRepository)
        {
            _transactionItemRepository = transactionItemRepository;
        }
        public int Create(TransactionItemVM transactionItemVM)
        {
            return _transactionItemRepository.Create(transactionItemVM);
            //throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
            {
                return 0;
            }
            else
            {
                return _transactionItemRepository.Delete(Id);
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<TransactionItem> Get()
        {
            return _transactionItemRepository.Get();
            //throw new NotImplementedException();
        }

        public TransactionItem Get(int Id)
        {
            return _transactionItemRepository.Get(Id);
            //throw new NotImplementedException();
        }

        public int Update(int Id, TransactionItemVM transactionItemVM)
        {
            return _transactionItemRepository.Update(Id, transactionItemVM);
            //throw new NotImplementedException();
        }
    }
}
