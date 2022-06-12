using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Management
{
    class CuttingListReport : Order
    {
        public int tableWidth = 20;// magic number 
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(base.ToString());
            generateTable();
        }
        public void generateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");// table building is not dynamic
            PrintLine();
            PrintRow(ShapeName.Square.ToString(), base.OrderedBlocks.ToArray()[0].TotalQuantityOfShape().ToString());
            PrintRow(ShapeName.Triangle.ToString(), base.OrderedBlocks.ToArray()[1].TotalQuantityOfShape().ToString());
            PrintRow(ShapeName.Circle.ToString(), base.OrderedBlocks.ToArray()[2].TotalQuantityOfShape().ToString());
            PrintLine();
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
            {
                row += AlignCentre(column.ToString(), width) + "|";
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
