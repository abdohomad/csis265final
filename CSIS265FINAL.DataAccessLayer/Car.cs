using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIS265FINAL.DataAccessLayer
{
   public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Weight { get; set; }
        public int Mpg { get; set; }

        public Car()
        {

        }
        public Car(int Id, string Make, string Model, string Color, double Weight, int Mpg)
        {
            this.Id = Id;
            this.Make = Make;
            this.Model = Model;
            this.Color = Color;
            this.Weight = Weight;
            this.Mpg = Mpg;
        }

        public override string ToString()
        {
            string output = $"CAR: ID: {Id}   MAKE: {Make}   MODEL: {Model}   COLOR: {Color}   WGT: {Weight}  MPG: {Mpg}  ";
            return output;

           
        }

    }
}
