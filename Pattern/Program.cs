using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Rachkova_Starikova
{
    public class Product
    {
        public string _name { get; set; }
        public decimal _cost_of_product { get; set; }
    }
    public class Item
    {
        public Product _product { get; set; }
        public int _count { get; set; }
    }
    public class ItemWithCost
    {
        public Item _item { get; set; }
        public decimal _cost_with_discount { get; set; }
    }
    public interface IDiscount
    {
        void GetDiscount(List<ItemWithCost> items);
    }
    public class Discount_on_concrete_product : IDiscount
    {

        public void GetDiscount(List<ItemWithCost> items)
        {
            decimal discount = 0.25M;
            foreach (var item in items)
            {
                //Для всех itemwithcost меняем cost с учётом скидки 
            }

        }
    }
    public class Discount_on_birthday : IDiscount
    {

        public void GetDiscount(List<ItemWithCost> items)
        {
            decimal discount = 0.20M;
            foreach (var item in items)
            {
                //Для всех itemwithcost меняем cost с учётом скидки 
            }

        }
    }
    public class Discount_on_all_Purchase : IDiscount
    {

        public void GetDiscount(List<ItemWithCost> items)
        {
            decimal discount = 0.4M;
            foreach (var item in items)
            {
                //Для всех itemwithcost меняем cost с учётом скидки 
            }

        }

    }
    public class Discount_on_customer_card : IDiscount
    {

        public void GetDiscount(List<ItemWithCost> items)
        {
            decimal discount = 0.1M;
            foreach (var item in items)
            {
                //Для всех itemwithcost меняем cost с учётом скидки 
            }

        }

    }

    public interface IDiscountCompatibleRule
    {
        bool IsCompatible(IDiscount d1, IDiscount d2);
    }
    public class DiscountCalculator
    {
        public IDiscountCompatibleRule _discountCompatibleRule;

    }
    public class Purchase
    {
        List<ItemWithCost> _purchase_items;

        DiscountCalculator _discountCalculator;
        public decimal GetTotalCost()
        {
            decimal total_Sum = 0;
            foreach (var item in _purchase_items)
            {
                total_Sum += item._cost_with_discount;
            }
            return total_Sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
