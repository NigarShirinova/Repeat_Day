
using task2;


class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Product elave edin");
            Console.WriteLine("2. Product satin");
            Console.WriteLine("3. Gelire baxin");
            Console.WriteLine("4. Qalan producta baxin");
            Console.WriteLine("Seciminizi daxil edin:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(shop);
                    break;
                case "2":
                    SellProduct(shop);
                    break;
                case "3":
                    Console.WriteLine($"Total Income: {shop.TotalIncome}");
                    break;
                case "4":
                    ViewProducts(shop);
                    break;
                default:
                    Console.WriteLine("Yanlis secim, yeniden cehd edin.");
                    break;
            }
        }
    }

    static void AddProduct(Shop shop)
    {
        Console.WriteLine("Product Name daxil edin:");
        string name = Console.ReadLine();

        Console.WriteLine("Product Price daxil edin:");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Product Count daxil edin:");
        int count = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Product Type daxil edin (c for Coffee, t for Tea):");
        string type = Console.ReadLine();

        if (type == "c")
        {
            shop.AddProduct(new Coffee { Name = name, Price = price, Count = count });
        }
        else if (type == "t")
        {
            shop.AddProduct(new Tea { Name = name, Price = price, Count = count });
        }
        else
        {
            Console.WriteLine("Yanlis product type, yeniden cehd edin.");
        }
    }

    static void SellProduct(Shop shop)
    {
        Console.WriteLine("Satilacaq productun adini daxil edin:");
        string name = Console.ReadLine();

        Console.WriteLine("Satilacaq productun sayini daxil edin:");
        int count = Convert.ToInt32(Console.ReadLine());

        bool result = shop.SellProduct(name, count);

        if (!result)
        {
            Console.WriteLine("Satis ugursuz oldu. Mehsul yetesizdir veya tapilmadi.");
        }
    }

    static void ViewProducts(Shop shop)
    {
        foreach (var product in shop.Products)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Count: {product.Count}");
        }
    }
}
