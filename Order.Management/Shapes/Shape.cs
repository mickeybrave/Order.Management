
namespace Order.Management
{
    public class Shape
    {
        public ShapeName ShapeName { get; protected set; }
        public int Price { get; protected set; }
        public int AdditionalCharge { get; protected set; }
        public int NumberOfRedShape { get; protected set; }
        public int NumberOfBlueShape { get; protected set; }
        public int NumberOfYellowShape { get; protected set; }
        public int TotalQuantityOfShape()
        {
            return NumberOfRedShape + NumberOfBlueShape + NumberOfYellowShape;
        }

        public Shape(ShapeName shapeName, int redNumber, int blueNumber, int yellowNumber, int shapePrice, int additionalPrice)
        {
            Price = shapePrice;
            AdditionalCharge = additionalPrice;
            ShapeName = shapeName;
            //base.Price = shapePrice;
            //AdditionalCharge = 1;
            NumberOfRedShape = redNumber;
            NumberOfBlueShape = blueNumber;
            NumberOfYellowShape = yellowNumber;
        }

        //should not be public
        protected int AdditionalChargeTotal()//it is not in use - it is a bug we do not include additional price for a red shape
        {
            return NumberOfRedShape * AdditionalCharge;
        }

        public int Total()
        {
            return RedTrianglesTotal() + BlueTrianglesTotal() + YellowTrianglesTotal();
        }

        public int RedTrianglesTotal()
        {
            return (NumberOfRedShape * (AdditionalChargeTotal() + Price));
        }
        public int BlueTrianglesTotal()
        {
            return (NumberOfBlueShape * Price);
        }
        public int YellowTrianglesTotal()
        {
            return (NumberOfYellowShape * Price);
        }

    }
}
