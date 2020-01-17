﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Data.ViewModel;

namespace API.Services.Interface
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> Get();
        Transaction Get(int Id);
        int Create(TransactionVM transactionVM);
        int Update(int Id, TransactionVM transactionVM);
        int Delete(int Id);
    }
}
