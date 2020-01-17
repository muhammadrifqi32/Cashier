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
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        public TransactionService() { }

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public int Create(TransactionVM transactionVM)
        {
            return _transactionRepository.Create(transactionVM);
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
                return _transactionRepository.Delete(Id);
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<Transaction> Get()
        {
            return _transactionRepository.Get();
            //throw new NotImplementedException();
        }

        public Transaction Get(int Id)
        {
            return _transactionRepository.Get(Id);
            //throw new NotImplementedException();
        }

        public int Update(int Id, TransactionVM transactionVM)
        {
            return _transactionRepository.Update(Id, transactionVM);
            //throw new NotImplementedException();
        }
    }
}
