using System;
using System.Collections.Generic;
using System.Text;
using Data.Base;
using Data.ViewModel;

namespace Data.Model
{
    public class Supplier : BaseModel
    {
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public Supplier()
        {

        }
        public Supplier(SupplierVM supplierVM)
        {
            this.Name = supplierVM.Name;
            this.JoinDate = supplierVM.JoinDate;
            this.CreateDate = DateTimeOffset.Now;
            this.IsDelete = false;
        }
        public void Update(SupplierVM supplierVM)
        {
            this.Name = supplierVM.Name;
            this.JoinDate = supplierVM.JoinDate;
            this.UpdateDate = DateTimeOffset.Now;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now;
        }
    }
}
