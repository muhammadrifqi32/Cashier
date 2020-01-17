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
    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository;

        public ItemService() { }

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public int Create(ItemVM itemVM)
        {
            if (string.IsNullOrWhiteSpace(itemVM.Name) || string.IsNullOrWhiteSpace(itemVM.Supplier.ToString()))
            {
                return 0;
            }
            else
            {
                return _itemRepository.Create(itemVM);
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
                return _itemRepository.Delete(Id);
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<Item> Get()
        {
            return _itemRepository.Get();
            //throw new NotImplementedException();
        }

        public Item Get(int Id)
        {
            return _itemRepository.Get(Id);
            //throw new NotImplementedException();
        }

        public int Update(int Id, ItemVM itemVM)
        {
            if (string.IsNullOrWhiteSpace(itemVM.Name) || string.IsNullOrWhiteSpace(itemVM.Supplier.ToString()))
            {
                return 0;
            }
            else
            {
                return _itemRepository.Update(Id, itemVM);
            }
            //throw new NotImplementedException();
        }
    }
}
