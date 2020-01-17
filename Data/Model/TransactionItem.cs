using System;
using System.Collections.Generic;
using System.Text;
using Data.Base;
using Data.ViewModel;

namespace Data.Model
{
    public class TransactionItem : BaseModel
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }
        public Transaction Transaction { get; set; }

        public TransactionItem() { }

        public TransactionItem(TransactionItemVM transactionItemVM)
        {
            this.Quantity = transactionItemVM.Quantity;
            this.CreateDate = DateTimeOffset.Now;
            this.IsDelete = false;
        }
        public void Update(TransactionItemVM transactionItemVM)
        {
            this.Quantity = transactionItemVM.Quantity;
            this.UpdateDate = DateTimeOffset.Now;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now;
        }
    }
}
