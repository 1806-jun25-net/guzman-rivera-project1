using System;
using System.Collections.Generic;


namespace ClassLibrary1.Models
{
    class Order2
    {
        public DateTime DateTime { get; private set; }


        public void SubmitOrder(string Pizza, int Price, List<int> toppins)
        {
            DateTime = DateTime.Now;







            /*
             * 
             *  Check if ther is items to creat pizza 
             *  
             */

            /*
             * 
             *  SQl to submit all
             * 
             * 
             */
            Console.Clear();
            Console.WriteLine("========== Thank you for using Pizza Paradise!==========");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(DateTime);
            //Console.WriteLine(user);
            Console.WriteLine("");
            Console.WriteLine(" Your order: ");
            Console.WriteLine(" " + Pizza + "           $" + Price + "");
            /*
             
             SQL set time 
              
             */
            
            Console.ReadLine();

        }

      
    }
}
