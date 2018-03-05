using Csv;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Category
    {
        public int parent_id;
        public string name;
        public int id;
        public bool marked = false;
        public decimal total;
        public int childNr;
        public ConcurrentDictionary<int, Category> children = new ConcurrentDictionary<int, Category>();

        public Category(ICsvLine line)
        {
            this.name = line["name"];
            this.id = Int32.Parse(line["id"]);

            if (!String.IsNullOrWhiteSpace(line["category_id"]))
                this.parent_id = Int32.Parse(line["category_id"]);
            else
                this.parent_id = 0;
        }

    }
}
