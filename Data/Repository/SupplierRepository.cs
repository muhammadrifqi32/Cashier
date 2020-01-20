using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Context;
using Data.Model;
using Data.Repository.Interface;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        MyContext myContext = new MyContext();

        public int Create(SupplierVM supplierVM)
        {
            var supplier = myContext.Suppliers.Where(s => s.Name == supplierVM.Name);
            var result = 0;
            if (supplier != null)
            {
                var push = new Supplier(supplierVM);
                myContext.Suppliers.Add(push);
                return myContext.SaveChanges();
            }
            return result;
            //throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            var delete = myContext.Suppliers.Find(Id);
            if (delete != null)
            {
                delete.Delete();
                return myContext.SaveChanges();
            }
            return 0;
            //throw new NotImplementedException();
        }

        public IEnumerable<Supplier> Get()
        {
            return myContext.Suppliers.FromSqlRaw($"SP_GetAllSupplier").ToList();
            //throw new NotImplementedException();
        }

        //public IEnumerable<Supplier> Get(int Id)
        //{
        //    return myContext.Suppliers.FromSqlRaw($"SP_GetSupplierByID @p0", Id);
        //    //throw new NotImplementedException();
        //}

        public Supplier Get(int id)
        {
            return myContext.Suppliers.Find(id);
        }

        public int Update(int Id, SupplierVM supplierVM)
        {
            var result = 0;
            var update = myContext.Suppliers.Find(Id);
            update.Update(supplierVM);
            result = myContext.SaveChanges();
            return result;
            //throw new NotImplementedException();
        }
    }
}
