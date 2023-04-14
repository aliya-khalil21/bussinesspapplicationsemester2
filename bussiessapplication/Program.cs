using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using bussiessapplication.BLL;

namespace bussiessapplication
{
    class Program
    {
        static void f()
        {
            /// loginn();
            string path = "product.txt";
            string path1 = "brand.txt";
            int option = sellermenu();
            if (option == 1)
            {
                List<Brand> user = sellerbrand();
               

                

                loaddatabrand(path1, user);
            }
            if (option == 2)
            {
               
                
                
                    Productname();
                   
                 
            }
            // List<Seller> user = new List<Seller>();
            /* if (option == 2)
             {
                 char m='n';
                 Productname();
                 Console.WriteLine("          Do you want to add more clothing?(y/n)");
                 m =char.Parse( Console.ReadLine());

                     if ((m == 'Y') || (m == 'y'))
                     {
                         Productname();
                     }
                 break;



                 //  loaddata(path, user);
             }*/
            if (option == 3)
            {
                List<Product> user = new List<Product>();
                loaddata(path, user);
            }
            if (option == 6)
            {
                string path3 = "feedback.txt";
                feedback(path3);
            }
            if (option == 5)
            {
                string path4 = "share.txt";
                feedback(path4);
            }
            if (option == 4)
            {
                string productname1;
                Console.WriteLine("enter productname1");
                productname1 = Console.ReadLine();
                deleteproduct(productname1);
            }
            if (option == 7)
            {
                Environment.Exit(0);

            }
        }

        static void Main(string[] args)
        {
            f();


        }
         static int sellermenu()
        {
            int option;
            Console.Clear();
            Console.WriteLine("1.press 1 if you want to add brands");
            Console.WriteLine("2.press 2 if you want to add product ,quantity and prices");
            Console.WriteLine("3.press 3 if you want to see about product");
            Console.WriteLine("4.press 4 if you want to delete product from collection");
            Console.WriteLine("5.press 5 if you want to see share product");
            Console.WriteLine("6.press 6 if you want to see feedback");
            
         
            Console.WriteLine("7.press 7 if you want to exit");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static List<Product> Productname()
        {
            Console.Clear();
            List<Product> user = new List<Product>();
            Product temp = new Product(); 
            Console.WriteLine("enter productname");
            temp.productname = Console.ReadLine();
            Console.WriteLine("enter color");
            temp.color = Console.ReadLine();
            Console.WriteLine("enter size(XS/S/M/L/XL/XXL");
            temp.size = Console.ReadLine();
            Console.WriteLine("enter product  price");
            temp.priceproduct = int.Parse(Console.ReadLine());
            Console.WriteLine("enter product quantity");
            temp.quantity =int.Parse(Console.ReadLine());
            addproductdata(temp);
            user.Add(temp);
            Console.WriteLine("clothing added successfully..");
            return user;
        }
        static void addproductdata(Product temp)
        {   
            string path = "product.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(temp.productname+","+temp.priceproduct+","+temp.quantity+","+temp.color+","+temp.size);
            file.Flush();
            file.Close();
        }
        static void loaddata(string path,List<Product> user)
        {
            Console.Clear();
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record=fileVariable.ReadLine())!=null)
                {
                    Product info = new Product();
                    info.productname = parsedata(record, 1);
                    info.priceproduct = int.Parse(parsedata(record, 2));
                    info.quantity = int.Parse(parsedata(record, 3));
                    info.color = parsedata(record, 4);
                    info.size = parsedata(record, 5);
                    user.Add(info);
                    Console.WriteLine($"Product name: {info.productname}, Price: {info.priceproduct}, Quantity: {info.quantity}, color: {info.color}, size: {info.size}");

                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("file not exit");
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("if you want to go main menu press any key");
            Console.ReadLine();

            f();
        }
        static string parsedata(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;

                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void deleteproduct(string productname1)
        {
            Console.Clear();
            string path = "product.txt";
            List<string> lines = File.ReadAllLines(path).ToList();

            bool productFound = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string[] fields = lines[i].Split(',');

                if (fields[0] == productname1)
                {
                    lines.RemoveAt(i);
                    productFound = true;
                    break;
                }
            }

            if (productFound)
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine($"Product '{productname1}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Product '{productname1}' not found.");
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("if you want to go main menu press any key");
            Console.ReadLine();

            f();
        }

      
        static List<Brand> sellerbrand()
        {
            Console.Clear();
            List<Brand> user = new List<Brand>();
            Brand temp = new Brand();
            Console.WriteLine("enter brandname");
            temp.brandname = Console.ReadLine();
            addbranddata(temp);
            user.Add(temp);
            return user;

        }
        
        static void addbranddata(Brand temp)
        {
            string path1 = "brand.txt";
            StreamWriter file = new StreamWriter(path1, true);
            file.WriteLine(temp.brandname);
            file.Flush();
            file.Close();
        }
        static void loaddatabrand(string path1, List<Brand> user)
        {
            Console.Clear();
            if (File.Exists(path1))
            {
                StreamReader fileVariable = new StreamReader(path1);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Brand info = new Brand();
                    info.brandname = record;
                    
                    user.Add(info);
                   // Console.WriteLine($"you have successfully added this brand: {info.brandname}");

                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("file not exit");
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("if you want to go main menu press any key");
            Console.ReadLine();

            f();
        }
        static void feedback(string path3)
        {
            Console.Clear();
            int x = 0;

            StreamReader fileVariable = new StreamReader(path3);
            string record;
            while (!fileVariable.EndOfStream)
            {
                record = fileVariable.ReadLine();


                Console.WriteLine(record);
                Console.ReadLine();


            }
            fileVariable.Close();
            //Console.Clear();
            // Console.WriteLine("IF YOU WANT TO GO MENU PLEASE ENTER ANY KEY");
            //Console.ReadKey();
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("if you want to go main menu press any key");
           

            f();

            Console.ReadKey();
        }
        static void share(string path4)
        { Console.Clear();
            int x = 0;

            StreamReader fileVariable = new StreamReader(path4);
            string record;
            while (!fileVariable.EndOfStream)
            {
                record = fileVariable.ReadLine();



                Console.WriteLine(record);
                Console.ReadLine();


            }
            fileVariable.Close();
            /*Console.Clear();
            Console.WriteLine("IF YOU WANT TO GO MENU PLEASE ENTER ANY KEY");
            Console.ReadKey();
            seller();
*/
            Console.ReadLine();
            Console.WriteLine("if you want to go main menu press any key");
            //Console.ReadLine();

            f();
            Console.ReadKey();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void readData(string pathh, List<Login> users)
        {
            if (File.Exists(pathh))
            {
                StreamReader fileVariable = new StreamReader(pathh);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Login info = new Login();
                    info.name = parseData(record, 1);
                    info.password = parseData(record, 2);
                    users.Add(info);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void signIn(string n, string p, List<Login> users)
        {
            bool flag = false;
            for (int x = 0; x < users.Count; x++)
            {
                if (n == users[x].name && p == users[x].password)
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        static void signUp(string pathh, string n, string p)
        {
            StreamWriter file = new StreamWriter(pathh, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        static void loginn()
        {
            List<Login> users = new List<Login>();
            string pathh = "loginfile.txt";
            int option;
            do
            {
                readData(pathh, users);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    signIn(n, p, users);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    signUp(pathh, n, p);
                }
            }
            while (option < 3);
            Console.Read();
        }
    }
}
 