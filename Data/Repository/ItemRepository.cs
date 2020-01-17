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
    public class ItemRepository : IItemRepository
    {
        MyContext myContext = new MyContext();

        public int Create(ItemVM itemVM)
        {
            var item = myContext.Items.Where(I => I.Name.ToLower() == itemVM.Name.ToLower());
            var result = 0;
            if (item != null)
            {
                var push = new Item(itemVM);
                push.Supplier = myContext.Suppliers.Where(s => s.Id == itemVM.Supplier).FirstOrDefault();
                myContext.Items.Add(push);
                return myContext.SaveChanges();
            }
            return result;
            //throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            var delete = myContext.Items.Find(Id);
            if (delete != null)
            {
                delete.Delete();
                return myContext.SaveChanges();
            }
            return 0;
            //throw new NotImplementedException();
        }

        public IEnumerable<Item> Get()
        {
            return myContext.Items.Include("Supplier").Where(i => i.IsDelete == false).ToList();
            //throw new NotImplementedException();
        }

        public Item Get(int Id)
        {
            return myContext.Items.Include("Supplier").Where(i => i.Id == Id && i.IsDelete == false).FirstOrDefault();
            //throw new NotImplementedException();
        }

        public int Update(int Id, ItemVM itemVM)
        {
            var update = myContext.Items.Find(Id);
            update.Supplier = myContext.Suppliers.Where(s => s.Id == itemVM.Supplier).FirstOrDefault();
            update.Update(itemVM);
            return myContext.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
