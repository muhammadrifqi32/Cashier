using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Data.ViewModel;

namespace API.Services.Interface
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> Get();
        //Supplier Get(int Id);
        IEnumerable<Supplier> Get(int Id);
        int Create(SupplierVM supplierVM);
        int Update(int Id, SupplierVM supplierVM);
        int Delete(int Id);
    }
}
