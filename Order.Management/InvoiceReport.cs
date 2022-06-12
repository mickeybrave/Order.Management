using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Management
{
    class InvoiceReport : Order
    {
        public int tableWidth = 73;
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + base.OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            return base.OrderedBlocks[0].NumberOfRedShape + base.OrderedBlocks[1].NumberOfRedShape +
                   base.OrderedBlocks[2].NumberOfRedShape;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * base.OrderedBlocks[0].AdditionalCharge;
        }
        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            var square = base.OrderedBlocks.FirstOrDefault(block => block.ShapeName == ShapeName.Square);
            PrintRow(ShapeName.Square.ToString(), square.NumberOfRedShape.ToString(),
                square.NumberOfBlueShape.ToString(), square.NumberOfYellowShape.ToString());

            var triangle = base.OrderedBlocks.FirstOrDefault(block => block.ShapeName == ShapeName.Triangle);
            PrintRow(ShapeName.Triangle.ToString(), triangle.NumberOfRedShape.ToString(), triangle.NumberOfBlueShape.ToString(),
                triangle.NumberOfYellowShape.ToString());

            var circle = base.OrderedBlocks.FirstOrDefault(block => block.ShapeName == ShapeName.Circle);
            PrintRow(ShapeName.Circle.ToString(), circle.NumberOfRedShape.ToString(), circle.NumberOfBlueShape.ToString(),
                circle.NumberOfYellowShape.ToString());
            PrintLine();
        }
        //table building is not dynamic and no separation of concern: table building should be in a separate class
        public void OrderSquareDetails()
        {
            var square = base.OrderedBlocks.FirstOrDefault(block => block.ShapeName == ShapeName.Square);
            Console.WriteLine("\nSquares 		  " +
                square.TotalQuantityOfShape() + " @ $" +
                square.Price + " ppi = $" + square.Total());
        }
        public void OrderTriangleDetails()
        {
            var triangle = base.OrderedBlocks.FirstOrDefault(block => block.ShapeName == ShapeName.Triangle);
            Console.WriteLine($"{ShapeName.Triangle}s 		  " +
                triangle.TotalQuantityOfShape() + " @ $" +
                triangle.Price + " ppi = $" + triangle.Total());
        }
        public void OrderCircleDetails()
        {
            var circle = base.OrderedBlocks.FirstOrDefault(block => block.ShapeName == ShapeName.Circle);
            Console.WriteLine($"{ShapeName.Circle}s 		  " +
               circle.TotalQuantityOfShape() +
                " @ $" + circle.Price + " ppi = $" + circle.Total());
        }
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {//there is a bug: if value is 0, should be printed "-"
                row += AlignCentre(column == "0" ? "-" : column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
