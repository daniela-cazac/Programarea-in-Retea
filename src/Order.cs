using Csv;
using System;

namespace Lab
{
    class Order
    {
        public string id;
        public decimal total;
        public int parent_id;
        public DateTime created;

        public Order(ICsvLine line)
        {
            id = line["id"];
            total = Convert.ToDecimal(line["total"], System.Globalization.CultureInfo.InvariantCulture);
            parent_id = Int32.Parse(line["category_id"]);
            created = DateTime.Parse(line["created"]);
        }
    }
}
