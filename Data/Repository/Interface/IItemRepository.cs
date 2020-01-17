using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using Data.ViewModel;

namespace Data.Repository.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> Get();

        Item Get(int Id);
        int Create(ItemVM itemVM);
        int Update(int Id,ItemVM itemVM);
        int Delete(int Id);
    }
}
