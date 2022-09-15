using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

        PolymorphismExample polymorphismExample = new PolymorphismExample();
        polymorphismExample.printSomething("hello");
        polymorphismExample.printSomething(1);

         Rectangle rectangle = new Rectangle(10, 7);
         Triangle triangle = new Triangle(10, 5);

         int rectangleArea = rectangle.area();
         int triangleArea = triangle.area();

         Console.WriteLine("Rectangle: {0}", rectangleArea);
         Console.WriteLine("Triangle: {0}", triangleArea);
        }
    }

    //Create a basic shape class t
       class Shape {
      protected int width, height;
      
      public Shape( int a = 0, int b = 0) {
         width = a;
         height = b;
      }
      public virtual int area() {
         Console.WriteLine("Parent class area :");
         return 0;
      }
   }

   //inherit rectangle from the shape class 
   class Rectangle: Shape {
      public Rectangle( int a = 0, int b = 0): base(a, b) {

      }
      //implement area
      public override int area () {
         return (width * height); 
      }
   }

   //create triangle class, inherit from Shape
   class Triangle: Shape {
      public Triangle(int a = 0, int b = 0): base(a, b) {
      }
      //implement areaw
      public override int area() {
         return (width * height / 2); 
      }
   }

    public class PolymorphismExample
    {
        //define method string as input 
        public void printSomething(string a)
        {
            Console.WriteLine("Printing string: {0}", a);
        }

        //define same method with int input 
        public void printSomething(int b)
        {
            Console.WriteLine("Printing int: {0}", b);
        }
    }
}
