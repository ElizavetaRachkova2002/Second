using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern
{
    // В данном случае применяется скидка на большую сумму(10*15=150 итоговая сумма чека,
    //т.к. сумма >=100 , то применяется DiscountOnAllProduct => 150- 30 =120)
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> first_List_of_product = new List<Product>();
            Product hammer = new Hammer(15);
            DiscountOnOneHammer discountOnOneHammer = new DiscountOnOneHammer();
            discountOnOneHammer.GetCost(0, hammer);
            PersonalDiscount personalDiscount = new PersonalDiscount();
            personalDiscount.GetCost(0, hammer);
            first_List_of_product.Add(hammer);
            Receipt FirstReceipt = new Receipt(first_List_of_product);
            FirstReceipt.GetSum();
           
            DiscountOnAllProduct discountOnAllProduct = new DiscountOnAllProduct();
            for (int i = 0; i < FirstReceipt.ProductReceipt.Count; i++)
            {
                discountOnAllProduct.GetCost(FirstReceipt.Sum, FirstReceipt.ProductReceipt[i]);

            }
            FirstReceipt.GetSum();
            Console.WriteLine(FirstReceipt.GetSum());
            Console.ReadKey();
        }
        public class Receipt
        {
            public List<Product> ProductReceipt = new List<Product>();
            public double Sum;
            public Receipt(List<Product> products)
            {
                ProductReceipt = products;
                Sum = 0;
            }

            public double GetSum()
            {
                double sum = 0;
                for (int i = 0; i < ProductReceipt.Count; i++)
                {
                    sum += (ProductReceipt[i].Product_Cost) * (ProductReceipt[i].Product_Count);
                }
                this.Sum = sum;
                return sum;
            }

        }

        public abstract class Product
        {
            public string Product_Name;
            public int    Product_Count;
            public double Product_Cost;
            public double Product_Discount;

            public Product(string name, double cost, double discont, int count)
            {
                this.Product_Name = name;
                this.Product_Cost = cost;
                this.Product_Discount = discont;
                this.Product_Count = count;
            }
            public abstract void GetCost(double sum);
        }

        public class Hammer : Product //создаём класс для конкртного продукта
        {
            public Hammer(int count) : base("молоток", 10, 0, count)
            {

            }
            public override void GetCost(double sum)
            {

            }
        }

        public interface IDiscount
        {
            void GetCost(double sum, Product product);
        }

        class PersonalDiscount : IDiscount//персональная скидка
        {


            public void GetCost(double sum, Product product)
            {
                double personal_discount = 4;
                if (product.Product_Discount < personal_discount)
                {
                    product.Product_Cost = (product.Product_Cost / (100 - product.Product_Discount) * 100) * ((100 - personal_discount) / 100);
                    product.Product_Discount = personal_discount;

                }
            }
        }

        class DiscountOnOneHammer : IDiscount //скидка на определенный товар
        {

            public void GetCost(double sum, Product product)
            {
                double discount_one_product = 3;
                if (product.Product_Discount < discount_one_product)
                {
                    product.Product_Cost = (product.Product_Cost / (100 - product.Product_Discount) * 100) * ((100 - discount_one_product) / 100);
                    product.Product_Discount = discount_one_product;

                }
            }
        }

        class DiscountOnFiveHammer : IDiscount //скидка на 5 и более единиц определённого товара
        {
            public void GetCost(double sum, Product product)
            {
                double discount_on_several_products = 10;
                if (product.Product_Discount < discount_on_several_products)
                {
                    if (product.Product_Count >= 5)
                    {
                        product.Product_Cost = (product.Product_Cost / (100 - product.Product_Discount) * 100) * ((100 - discount_on_several_products) / 100);
                        product.Product_Discount = discount_on_several_products;
                    }

                }
            }
        }

        class DiscountOnAllProduct : IDiscount //скидка большую сумму покупок
        {
            public void GetCost(double sum, Product product)
            {
                double discount_on_all_products = 20;
                double sum_of_large_receipte = 100;
                if (product.Product_Discount < discount_on_all_products && sum >= sum_of_large_receipte)
                {
                    product.Product_Cost = (product.Product_Cost / (100 - product.Product_Discount) * 100) * ((100 - discount_on_all_products) / 100);
                    product.Product_Discount = discount_on_all_products;

                }
            }
        }


    }
}