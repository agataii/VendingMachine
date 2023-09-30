internal class Program
{
    private static void Main(string[] args)
    {
        string inputs = File.ReadAllText("C:\\AGU\\avtomatdb.txt");

        string[] lines = inputs.Split('\n');

        Product[] products = new Product[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] productValues = lines[i].Split(';');

            products[i] = new Product
            {
                Index = Convert.ToInt32(productValues[0]),
                Name = productValues[1],
                Price = Convert.ToInt32(productValues[2]),
                Quantity = Convert.ToInt32(productValues[3]),
            };
        }

        while (true) {
            Console.WriteLine("Привет, чтобы выбрать товар введите ИНДЕКС товара");
            PrintProducts(products);

            int enteredPrice = EnteredPrice();

            Console.WriteLine("Введите индекс: ");
            int selectedIndex = Convert.ToInt32(Console.ReadLine());

            Product selectedProduct = null;
            foreach (var product in products)
            {
                if (product.Index == selectedIndex)
                {
                    selectedProduct = product;
                }
            }

            if (selectedProduct is null)
            {
                Console.WriteLine("Продукт не существует. Выберите другой товар");
                Console.ReadKey();
                Console.Clear();
                continue;
            }
            Console.WriteLine($"Вы выбрали продукт - {selectedProduct.Name}. Цена - {selectedProduct.Price} тг. Введите количество продукта:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Итого - {selectedProduct.Price * quantity} тг.");
priceproverka:            
            if (enteredPrice >= (selectedProduct.Price * quantity))
            {
                Console.WriteLine($"Спасибо за покупку. Ваша сдача {enteredPrice - (selectedProduct.Price * quantity)} тг");
                break;
            }
            else
            {
                Console.WriteLine($"Сумма недостаточно. Пополните {(selectedProduct.Price * quantity) - enteredPrice} тг.");
                int additionallyPrice = Convert.ToInt32(Console.ReadLine());
                enteredPrice += additionallyPrice;
                goto priceproverka;
            }
        }
    }
    public static void PrintProducts(Product[] products)
    {
        Console.WriteLine("ИНДЕКС - Товар");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Index} - {product.Name} ({product.Price} тг.)");
        }
    }

    public static int EnteredPrice()
    {
        Console.WriteLine("Ввведите деньги:");
        int price = Convert.ToInt32(Console.ReadLine());

        return price;
    }

}