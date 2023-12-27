using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Taobin
{
    internal class Coffee_Machine
    {
        public double water, coffee , milk , chocolate;

        public Coffee_Machine()
        {
            water = 500;
            coffee = 500;
            milk = 500;
            chocolate = 500;
        }

        public Coffee_Machine(double water , double coffee , double milk , double chocolate ) 
        {
            this.water = water;
            this.coffee = coffee;
            this.milk = milk;
            this.chocolate = chocolate;
        }

        public bool make_BlackCoffee()
        {
            if (water >= 300 && coffee >= 20)
            {
                // Black coffee makeable
                this.water -= 300 ; 
                this.coffee -= 20;
                return true;
            }

            else
            {
                // Black coffee unmakeable
                return false;
            }
        }

        public bool make_Latte()
        {
            if ( water >= 200 && coffee >= 20 && milk >= 10)
            {
                this.water -= 200;
                this.coffee -= 20;
                this.milk -= 10;
                return true;
            }

            else
            {
                
                return false;
            }
        }

        public bool make_HotChocolate()
        {
            if ( water >= 300 && chocolate >= 20)
            {
                this.water -= 300d; 
                this.chocolate -= 20;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool make_Mocca()
        {
            if (water >= 300 && coffee >= 20 && chocolate >= 10 )
            {
                this.water -= 300; 
                this.coffee -= 20;
                this.chocolate -= 10;
                return true;
            } 
            else
            {
                return false; 
            }
        }

        public void increase_material(double water, double coffee, double milk, double chocolate)
        {
            this.water += water*100;
            this.coffee += coffee*100;
            this.milk += milk*100;
            this.chocolate += chocolate*100;
        }

    }
}
