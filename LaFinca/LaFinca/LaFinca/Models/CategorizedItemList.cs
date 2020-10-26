using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LaFinca.Models
{
    public class CategorizedItemList : IEnumerable<MenuItem>
    {
        public string CategoryName { get; set; }
        public CategorizedItemList(string CategoryName, List<Models.MenuItem> categogrizedItems) : base(categogrizedItems)
        {
            this.CategoryName = CategoryName;
        }

        public IEnumerator<MenuItem> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
