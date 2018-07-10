using System;
using System.Collections.Generic;


namespace ClassLibrary1.Models
{
    public class Order2
    {
        public DateTime DateTime { get; private set; }

        public string nAME { get;  set; }
        public string lASTnAME { get; set; }
        public string PhoneNumber { get; set; }



        public void SubmitOrder(string Pizza, int Price, List<int> toppins)
        {
            DateTime = DateTime.Now;

            Console.WriteLine(nAME);
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
            //Console.WriteLine(" Your order: " + nAME + " " + lASTnAME + " ");
            //Console.WriteLine(" Your phone: " + PhoneNumber);
            //Console.WriteLine(" " + Pizza + "           $" + Price + "");
            //Console.WriteLine(" " + nAME + "           $" + lASTnAME + "");
            Console.WriteLine("");
            /*
             
             SQL set time 
              
             */

            Console.ReadLine();

        }

      
    }
}
