using ClassLibrary1.DB;
using System;
using System.Collections.Generic;


namespace ClassLibrary1.Models
{
    public class Order2
    {
        //public DateTime DateTime { get; private set; }

        ///////////////////////////////////
            /// <summary>
            /// ///////////
            /// </summary>
        public Pizza2 LaOrden = new Pizza2();
        public List<Pizza2> lasPizzas = new List<Pizza2>();

        public void SubmitOrder(string Pizza, int Price, List<int> toppins, List<User2> user3, int thelocation,  string size)
        {

            var repo = new OrderRepository(new PizzaPalacedbContext());
            //DateTime = DateTime.Now;
            string Beli = "Belitos Pizza";
            string Angel = "Angelitos pizza";
            string Palace = "Pizza Palace";
            string ellocation;
            var top = new List<string>();


            top.Clear();
            top.Add("doug");
            top.Add("Cheese");
            top.Add("Pepperoni");
            top.Add("Sausage");
            top.Add("Bacon");
            top.Add("Onion");
            top.Add("Chicken");
            top.Add("Sauce");
            top.Add("Chorizo");

            if (thelocation == 1)
            {
                ellocation = Palace;
            }
            else if (thelocation == 2)
            {
                ellocation = Angel;
            }
            else if(thelocation == 3)
            {
                ellocation = Beli;
            }else
            {
                ellocation = "No Location";
            }
            /* 
             * location
             * pizza
             * order
             * usuario
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
            //Console.WriteLine(" " + DateTime);
            //Console.WriteLine(user);
            Console.WriteLine("");
            user3.ForEach(item => Console.WriteLine(" Name: " + item.Name + " " + item.LastName + "\n" +
                " Phone Number:" + item.PhoneNumber));
            //Console.WriteLine(" Location: " + ellocation);
            //Console.WriteLine(" " + size + " " + Pizza + "           $" + Price + "");
            //Console.WriteLine("   - " + top[1] + " " + toppins[1]); // cheese
            //Console.WriteLine("   - " + top[2] + " " + toppins[2]); // Peeperoni
            //Console.WriteLine("   - " + top[3] + " " + toppins[3]); // Sausage
            //Console.WriteLine("   - " + top[4] + " " + toppins[4]); // Bacon
            //Console.WriteLine("   - " + top[5] + " " + toppins[5]); // Onion
            //Console.WriteLine("   - " + top[6] + " " + toppins[6]); // Chicken
            //Console.WriteLine("   - " + top[8] + " " + toppins[8]); // Chorizo
            Console.WriteLine("");

            LaOrden.Pizza1 = Pizza;
            LaOrden.Size = size;
            LaOrden.Doug = toppins[0];
            LaOrden.Cheese = toppins[1];
            LaOrden.pepperoni = toppins[2];
            LaOrden.Sausage = toppins[3];
            LaOrden.bacon = toppins[4];
            LaOrden.Onion = toppins[5];
            LaOrden.Chiken = toppins[6];
            LaOrden.Sausage = toppins[7];
            LaOrden.chorizo = toppins[8];
            LaOrden.PizzaPrice = Price;


            lasPizzas.Add(LaOrden);

            

            show(lasPizzas);
            //repo.CustumizeInventory(toppins);
            //repo.Addpizza(lasPizzas);
            //repo.Addpizza(lasPizzas);
            //repo.Addpizza(lasPizzas);

            /*
             
             SQL set time 
              
             */

            Console.ReadLine();

        }

        public void show(List<Pizza2> PizzaObj)
        {
            foreach(Pizza2 i in PizzaObj)
            {
                Console.WriteLine("--" + i.Pizza1 + "\n Price: --" + i.PizzaPrice + "\n" +
               " Size:--" + i.Size);
            }
            //PizzaObj.ForEach(item => Console.WriteLine(" Name: " + item.Pizza1 + "\nPrice" + item.PizzaPrice + "\n" +
            //   " Size:" + item.Size));

        }
      
    }
}
