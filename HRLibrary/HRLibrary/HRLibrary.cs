using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLibrary
{

    public enum CommodityUnits
    {
        Pieces,
        Kilogram,
        Tonne,
        Packaging
    }
    public class Commodity
    {

        // Создаем, описанные в документе, соответствующие свойства 
        public string ArticleNumber { get; private set; }
        public string Name { get; set; }
        public double WholesalePrice { get; set; }
        public double RetailPrice { get; set; }
        public CommodityUnits CommodityUnit { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }

        // Конструктор для нашего класса
        public Commodity(string name, string articleNumber, CommodityUnits commodityUnit,
            double wholeselePrice, double retailPrice)
        {
            Name = name;
            ArticleNumber = articleNumber;
            WholesalePrice = wholeselePrice;
            RetailPrice = retailPrice;
            CommodityUnit = commodityUnit;
        }

        // Переопределяем метод ToString(). Он будет выводить название и артикул продукта 
        public override string ToString()
        {
            return $"{Name} {ArticleNumber}";
        }

        // Метод для вывода всей информации.
        public virtual void PrintInfo()
        {
            Console.WriteLine(this);//Сначала мы ввыводим имя и фамилию посредством метода ToString. "this" означает,
            //что метод ToString применяется к объекту, с которым мы работаем в данный момент

            var commodityUnit = " ";

            // Разворачиваем наш enum 
            switch (CommodityUnit)
            {
                case CommodityUnits.Kilogram:
                    commodityUnit = "кг";
                    break;
                case CommodityUnits.Packaging:
                    commodityUnit = "пак";
                    break;
                case CommodityUnits.Pieces:
                    commodityUnit = "шт";
                    break;
                case CommodityUnits.Tonne:
                    commodityUnit = "т";
                    break;
            }
            // Выводим остальную информацию
            Console.WriteLine($"Оптовая цена за единицу товара: {WholesalePrice}руб. за {commodityUnit}," +
                $" Розничная цена за единицу товара {RetailPrice}руб. за {commodityUnit}," +
                $" Описание: {Description} На складе: {Count}");
        }
    }
}
