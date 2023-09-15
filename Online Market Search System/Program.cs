using static Online_Market_Search_System.ListGenerators;
namespace Online_Market_Search_System
{
  
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Do you want to search by 'product name'[1] or by 'category'[2] ");
            bool IsEnteredOptionRight;
            int Option;

            do
            {
                Console.WriteLine("Do you want to search by 'product name'[1] or by 'category'[2] ");
                IsEnteredOptionRight = int.TryParse(Console.ReadLine(), out Option);


            } while (!IsEnteredOptionRight);



            if (Option == 1)
            {
                Console.WriteLine("Enter Product Name .....");
                string ProductName = Console.ReadLine();

                var ProductNamesList = ProductList.Select(product => product.ProductName);

                foreach (var name in ProductNamesList)
                {
                    if (name == ProductName)
                    {
                        var ReturnedProduct = ProductList.Single(product => product.ProductName == name);
                        Console.WriteLine(ReturnedProduct.ToString());
                    }
                }


            }

            else if (Option == 2)
            {

                Console.WriteLine("Enter Category Name .....");
                string CategoryName = Console.ReadLine();

                bool IsEnteredOrderdRight;
                int Order;

                do
                {
                    Console.WriteLine(" press 1 : for ordering by name / 2 : for ordering by unit in stock / 3 : for ordering by price  .....");
                    IsEnteredOrderdRight = int.TryParse(Console.ReadLine(), out Order);


                } while (!IsEnteredOrderdRight);

                var CategoryNamesList = ProductList.Select(product => product.Category).Distinct().ToList();




                foreach (var name in CategoryNamesList)
                {

                    if (name == CategoryName)
                    {
                        var ReturnedProducts = ProductList.Where(product => product.Category == CategoryName).ToList();
                        var ReturnedOrderedProduct = ReturnedProducts.OrderByDescending(prod => prod.ProductID);
                        if (Order == 1)
                        {
                             ReturnedOrderedProduct
                           = ReturnedProducts.OrderByDescending(prod => prod.ProductName);
                        }
                        else if (Order == 2)
                        {
                             ReturnedOrderedProduct
                          = ReturnedProducts.OrderByDescending(prod => prod.UnitsInStock);
                        }
                        else if (Order == 3)
                        {
                             ReturnedOrderedProduct
                          = ReturnedProducts.OrderByDescending(prod => prod.UnitPrice);

                        }


                        foreach (var product in ReturnedOrderedProduct)
                        {
                            Console.WriteLine(product.ToString());
                        }

                    }

                }


            }
            else Console.WriteLine("That's Not Right Option  ,Try Again !");



        }
    }
}