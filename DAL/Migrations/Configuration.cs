namespace DAL.Migrations
{
    using DAL.EF.Models;
    using DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.FoodContext>
    {
        Random rand = new Random();

        string[] locations = { "Gulshan", "Uttara", "Dhanmondi", "Banani", "Bashundhara", "Banasree", "Khilgaon", "Malibagh" };
        string[] firstNames = { "Nadia", "Danielle", "Krish", "Corey", "Jadyn", "Lexie", "Daniella", "Hayden", "Joyce", "Leia", "Norah", "Bryan", "Noah", "Lillian" };
        string[] lastNames = { "Arroyo", "Duarte", "Santana", "Knox", "Santiago", "Watts", "Barton", "Payne", "Pena", "Schneider", "Silva", "Sky", "Amy" };
        string[] items = { "Pasta", "Pizza", "Honey", "Oats", "Cheesecake" };
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.FoodContext context)
        {
            //Seeders for admin
            List<User> User = new List<User>();
            List<Admin> Admin = new List<Admin>();
            for (int i = 2; i < 6; i++)
            {
                int firstName = rand.Next(firstNames.Length);
                int lastName = rand.Next(lastNames.Length);
                var nameF = firstNames[firstName];
                var nameL = lastNames[lastName];
                User.Add(new User
                {
                    user_id = i,
                    user_name = (nameF + "_" + nameL).ToLower() + "@admin.com",
                    password = "password",
                    role = "Admin"
                });
                Admin.Add(new Admin
                {
                    admin_name = nameF,
                    email = (nameF + "_" + nameL).ToLower() + "@admin.com",
                    password = "password",
                    contact = "123-123-1234",
                    user_id = i
                });
            }
            context.Users.AddOrUpdate(User.ToArray());
            context.Admins.AddOrUpdate(Admin.ToArray());

            //Seeders for Customer
            List<User> UserCustomer = new List<User>();
            List<Customer> Customer = new List<Customer>();
            for (int i = 6; i < 13; i++)
            {
                int firstName = rand.Next(firstNames.Length);
                int lastName = rand.Next(lastNames.Length);
                int location = rand.Next(locations.Length);
                var nameF = firstNames[firstName];
                var nameL = lastNames[lastName];
                UserCustomer.Add(new User
                {
                    user_id = i,
                    user_name = (nameF + "_" + nameL).ToLower() + "@customer.com",
                    password = "password",
                    role = "Customer"
                });
                Customer.Add(new Customer
                {
                    customer_name = nameF,
                    email = (nameF + "_" + nameL).ToLower() + "@customer.com",
                    password = "password",
                    contact = "123-123-1234",
                    location = locations[location],
                    user_id = i
                });
            }
            context.Users.AddOrUpdate(UserCustomer.ToArray());
            context.Customers.AddOrUpdate(Customer.ToArray());

            //Seeders for Courier
            List<User> UserCourier = new List<User>();
            List<Courier> Courier = new List<Courier>();
            var random = new Random();
            for (int i = 13; i < 19; i++)
            {
                int firstName = rand.Next(firstNames.Length);
                int lastName = rand.Next(lastNames.Length);
                int location = rand.Next(locations.Length);
                var nameF = firstNames[firstName];
                var nameL = lastNames[lastName];
                UserCourier.Add(new User
                {
                    user_id = i,
                    user_name = (nameF + "_" + nameL).ToLower() + "@courier.com",
                    password = "password",
                    role = "Courier"
                });
                Courier.Add(new Courier
                {
                    courier_name = nameF,
                    email = (nameF + "_" + nameL).ToLower() + "@courier.com",
                    password = "password",
                    contact = "123-123-1234",
                    location = locations[location],
                    income = random.Next(1000, 5000),
                    user_id = i
                });
            }
            context.Users.AddOrUpdate(UserCourier.ToArray());
            context.Couriers.AddOrUpdate(Courier.ToArray());


            //Seeder for Sale
            List<Sale> Sale = new List<Sale>();
            for (int i = 1; i < 5; i++)
            {
                Sale.Add(new Sale
                {
                    sales_id = i,
                    expense = 0,
                    revenue = 0,
                    date = DateTime.Now
                });
            }
            context.Sales.AddOrUpdate(Sale.ToArray());

            //Seeder for Item
            List<Item> Item = new List<Item>();
            for (int i = 1; i < 5; i++)
            {
                int item = rand.Next(items.Length);
                Item.Add(new Item
                {
                    item_id = i,
                    item_name = items[item],
                    stock = 500,
                    unit_price = 20,
                    man_date = DateTime.Now,
                    exp_date = DateTime.Now
                });
            }
            context.Items.AddOrUpdate(Item.ToArray());

            //Seeder for Order
            List<Order> Order = new List<Order>();
            for (int i = 1; i < 5; i++)
            {
                Order.Add(new Order
                {
                    order_id = i,
                    customer_id = rand.Next(1, 8),
                    item_id = rand.Next(1, 3),
                    total_price = 0,
                    status = 0,
                    delivered_by = rand.Next(1, 7)
                });

            }
            context.Orders.AddOrUpdate(Order.ToArray());




            //Seeders for User
            //List<User> User = new List<User>();
            //User.Add(new User
            //{
            //    user_name = "tonmoysaha@admin.com",
            //    password = "password",
            //    role = "Admin"
            //});
            //for (int i = 2; i < 5; i++)
            //{
            //    int firstName = rand.Next(firstNames.Length);
            //    int lastName = rand.Next(lastNames.Length);
            //    User.Add(new User
            //    {
            //        user_name = (firstNames[firstName] + "_" + lastNames[lastName]).ToLower() + "@admin.com",
            //        password = "password",
            //        role = "Admin"
            //    });
            //}
            //context.Users.AddOrUpdate(User.ToArray());

            //////Seeders for Admin
            //List<Admin> Admin = new List<Admin>();
            //for (int i = 1; i < 5; i++)
            //{
            //    var data = User.First(u => u.user_id.Equals(i));
            //    Admin.Add(new Admin
            //    {
            //        admin_name = data.user_name.Substring(0, data.user_name.IndexOf("_")),
            //        email = data.user_name,
            //        password = data.password,
            //        contact = "123-123-1234".
            //        user_id =
            //    });
            //}
            ////Admin.Add(new Admin
            ////{
            ////    admin_name = "Tonmoy",
            ////    email = "tonmoy@admin.com",
            ////    password = "password",
            ////    contact = "123-123-1234",
            ////});
            ////for (int i = 2; i < 5; i++)
            ////{
            ////    int firstName = rand.Next(firstNames.Length);
            ////    int lastName = rand.Next(lastNames.Length);

            ////    Admin.Add(new Admin
            ////    {
            ////        admin_name = firstNames[firstName] + " " + lastNames[lastName],
            ////        email = (firstNames[firstName] + "_" + lastNames[lastName]).ToLower() + "@admin.com",
            ////        password = "password",
            ////        contact = "123-123-1234"
            ////    });
            ////}
            //context.Admins.AddOrUpdate(Admin.ToArray());

            //Seeders for Customer
            //List<Customer> Customer = new List<Customer>();
            //for (int i = 1; i < 10; i++)
            //{
            //    int firstName = rand.Next(firstNames.Length);
            //    int lastName = rand.Next(lastNames.Length);
            //    int courier_location = rand.Next(locations.Length);

            //    Customer.Add(new Customer
            //    {
            //        customer_id = i,
            //        customer_name = firstNames[firstName] + " " + lastNames[lastName],
            //        email = (firstNames[firstName] + "_" + lastNames[lastName]).ToLower() + "@customer.com",
            //        password = "password",
            //        contact = "123-123-1234",
            //        location = locations[courier_location]
            //    });
            //}
            //context.Customers.AddOrUpdate(Customer.ToArray());

            ////Seeders for Courier
            //List<Courier> Courier = new List<Courier>();
            //for (int i = 1; i < 5; i++)
            //{
            //    int firstName = rand.Next(firstNames.Length);
            //    int lastName = rand.Next(lastNames.Length);
            //    int courier_location = rand.Next(locations.Length);

            //    Courier.Add(new Courier
            //    {
            //        courier_id = i,
            //        courier_name = firstNames[firstName] + " " + lastNames[lastName],
            //        email = (firstNames[firstName] + "_" + lastNames[lastName]).ToLower() + "@courier.com",
            //        password = "password",
            //        contact = "123-123-1234",
            //        location = locations[courier_location],
            //    });
            //}
            //context.Couriers.AddOrUpdate(Courier.ToArray());
        }
    }
}