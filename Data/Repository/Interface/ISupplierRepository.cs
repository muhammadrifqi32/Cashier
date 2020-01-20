using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using Data.ViewModel;

namespace Data.Repository.Interface
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> Get();

        Supplier Get(int Id);
        //IEnumerable<Supplier> Get(int Id);
        int Create(SupplierVM supplierVM);
        int Update(int Id, SupplierVM supplierVM);
        int Delete(int Id);
    }
}
