using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Base;
using Data.ViewModel;

namespace Data.Model
{
    public class Transaction : BaseModel
    {
        public DateTime OrderDate { get; set; }
        public Transaction()
        {
        }
        public Transaction(TransactionVM transactionVM)
        {
            this.OrderDate = transactionVM.OrderDate;
            this.CreateDate = DateTimeOffset.Now;
            this.IsDelete = false;
        }
        public void Update(TransactionVM transactionVM)
        {
            this.OrderDate = transactionVM.OrderDate;
            this.UpdateDate = DateTimeOffset.Now;
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now;
        }
    }
}
