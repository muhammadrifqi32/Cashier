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
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _supplierRepository;

        public SupplierService() { }

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public int Create(SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name))
            {
                return 0;
            }
            else
            {
                return _supplierRepository.Create(supplierVM);
            }
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
                return _supplierRepository.Delete(Id);
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<Supplier> Get()
        {
            return _supplierRepository.Get();
            //throw new NotImplementedException();
        }

        public IEnumerable<Supplier> Get(int Id)
        {
            return _supplierRepository.Get(Id);
            //throw new NotImplementedException();
        }

        public int Update(int Id, SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name))
            {
                return 0;
            }
            else
            {
                return _supplierRepository.Update(Id, supplierVM);
            }
            //throw new NotImplementedException();
        }
    }
}
