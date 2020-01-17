using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Data.ViewModel;

namespace API.Services.Interface
{
    public interface IItemService
    {
        IEnumerable<Item> Get();
        Item Get(int Id);
        int Create(ItemVM itemVM);
        int Update(int Id, ItemVM itemVM);
        int Delete(int Id);
    }
}
