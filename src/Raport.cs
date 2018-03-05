using Csv;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Lab
{
    class Raport
    {
        public string startDate;
        public string endDate;
        private Categories categories = new Categories();
        private Orders orders = new Orders();
        private CountdownEvent countEventObject = new CountdownEvent(2);
        private Categories parents = new Categories();

        public Raport()
        {
        }

        public void Download()
        {
            EnterDate();

            GetCategoriesOrders();

            countEventObject.Wait();

            GetParents();



            foreach (var p in parents.list)
            {
                
                Build(p.Value);
            }
    
        }
  
        public void Afisare()
        {

            Console.WriteLine(@"Lista de la  "+ startDate + " pina la "+ endDate , ConsoleColor.White);

            foreach (var e in parents.list)
            {
                Afisare(e.Value);
            }
        }

        private void Afisare(Category c)
        {
            if (c.childNr == 0)
            {
                Console.WriteLine();
            }

            for (int i = 0; i < c.childNr; ++i)
            {
                Console.Write("\t", ConsoleColor.White);
            }
            Console.Write($"+{c.name}", ConsoleColor.White);
            Console.WriteLine($"  {c.total}", ConsoleColor.White);

            foreach (var subCat in c.children.Values)
            {
                Afisare(subCat);
            }
        }
   
        private void Build(object obj)
        {
            Category p = (Category)obj;
            foreach (var el in categories.list)
            {
                if (!el.Value.marked && el.Value.parent_id == p.id)
                {
                    el.Value.marked = true;
                    if (orders.list.ContainsKey(el.Value.id))
                    {
                        el.Value.total = orders.list[(el.Value.id)].total;
                    }
                    el.Value.childNr = p.childNr + 1;
                    p.children.TryAdd(el.Key, el.Value);
                    Build(el.Value);
                }
            }
        }

        private void GetParents()
        {
            foreach (var category in categories.list)
            {
                if (category.Value.parent_id == 0)
                {
                    category.Value.marked = true;
                    if (orders.list.ContainsKey(category.Value.id))
                    {
                        category.Value.total = orders.list[(category.Value.id)].total;
                    }
                    parents.list[category.Key] = category.Value;
                }
            }
        }

        private void EnterDate()
        {
            Console.WriteLine("Enter orders date (yyyy-mm-dd) :");
            startDate = Console.ReadLine();
            Console.WriteLine("Enter categories date (yyyy-mm-dd) :");
            endDate = Console.ReadLine();
        }

        
        private void GetCategoriesOrders()
        {

            Task.Run(() => MakeRequest(@"https://evil-legacy-service.herokuapp.com/api/v101/orders/?" + $"start={startDate}&end={endDate}", "orders"));
            Task.Run(() => MakeRequest(@"https://evil-legacy-service.herokuapp.com/api/v101/categories/", "categories"));
        }

        private void MakeRequest(string url, string type)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 60 * 1000; // one minute
            request.Headers.Add("X-API-Key", "55193451-1409-4729-9cd4-7c65d63b8e76");
            request.Accept = "text/csv";
            HttpStatusCode responseCode;
            string result = "";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    responseCode = response.StatusCode;

                    result = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    response.Close();
                }
            }
            catch (WebException webException)
            {
                throw webException;
            }

            if (responseCode != HttpStatusCode.OK)
                throw new Exception("Invalid respone");

            if (type == "categories")
            {
                foreach (ICsvLine line in CsvReader.ReadFromText(result))
                {
                    categories.AddValidElement(line);
                }
            }
            else if (type == "orders")
            {
                foreach (ICsvLine line in CsvReader.ReadFromText(result))
                {
                    orders.AddValidElement(line);
                }
            }

            countEventObject.Signal();
        }
    }
}
