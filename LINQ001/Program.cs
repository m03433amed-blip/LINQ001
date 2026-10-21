using LINQ.DataSources;

namespace LINQ001
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ---------- 1 ----------
            var seafood = Source.ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in seafood)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");

            // ---------- 2 ----------
            var names = Source.ProductList.Select(p => p.ProductName);
            foreach (var n in names)
                Console.WriteLine(n);

            // ---------- 3 ----------
            var byPrice = Source.ProductList.OrderBy(p => p.UnitPrice);
            foreach (var p in byPrice)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C2}");

            // ---------- 4 ----------

            var productsInRange = from p in Source.ProductList
                                  where p.UnitPrice >= 10 && p.UnitPrice <= 30
                                  select new { p.ProductName, p.UnitPrice };

            foreach (var item in productsInRange)
                Console.WriteLine($"{item.ProductName}: {item.UnitPrice:C}");

            // ---------- 5 ----------

            var condiments = from p in Source.ProductList
                             where p.UnitsInStock > 0 &&
                                   p.Category.Contains("Condiments")
                             select new { p.ProductName, p.UnitPrice };

            foreach (var p in condiments)
                Console.WriteLine($"{p.ProductName}: {p.UnitPrice:C}");

            // ---------- 6 ------------------
            var anon = Source.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var a in anon)
                Console.WriteLine($"{a.Name} | {a.Price:C2} | {a.StockStatus}");

            // ---------- 7 -----------------
            var indexed = Source.ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
            foreach (var s in indexed)
                Console.WriteLine(s);

            // ---------- 8 --------------

            var byCategoryThenPrice =
                from p in Source.ProductList
                orderby p.Category ascending, p.UnitPrice descending
                select p;

            foreach (var product in byCategoryThenPrice)
            {
                Console.WriteLine(
                    $"{product.Category}: {product.ProductName} - {product.UnitPrice:C}");
            }

            // ---------- 9 ----------------
            var beverages = Source.ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var p in beverages)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

            // ---------- 10 -----------
            var orders =
                from c in Source.CustomerList
                from o in c.Orders
                where o.OrderDate.Year >= 1997
                select new { c.CustomerID, o.OrderDate };
            foreach (var o in orders)
                Console.WriteLine($"{o.CustomerID} - {o.OrderDate:d}");

            // ---------- 11 -----------
            var withIndex = Source.ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });
            foreach (var x in withIndex)
                Console.WriteLine($"{x.Position} - {x.ProductName}");

            // ---------- 12 -----------
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var words = Arr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in words)
                Console.WriteLine(w);

            // ---------- 13 ------------
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result = digits
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();
            foreach (var d in result)
                Console.WriteLine(d);
        }
    }
}
