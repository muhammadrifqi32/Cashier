using System;
using System.Collections.Generic;
using System.Text;
using Data.Base;
using Data.ViewModel;

namespace Data.Model
{
    public class Item : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Supplier Supplier { get; set; }

        public Item() { }
        public Item(ItemVM itemVM)
        {
            this.Name = itemVM.Name;
            this.Price = itemVM.Price;
            this.Stock = itemVM.Stock;
            this.CreateDate = DateTimeOffset.Now;
            this.IsDelete = false;
        }
        public void Update(ItemVM itemVM)
        {
            this.Name = itemVM.Name;
            this.Price = itemVM.Price;
            this.Stock = itemVM.Stock;
            this.UpdateDate = DateTimeOffset.Now;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now;
        }
    }
}
