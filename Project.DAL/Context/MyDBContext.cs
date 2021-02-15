using Project.DAL.Strategy;
using Project.MAP.Options;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class MyDBContext:DbContext
    {

        public MyDBContext():base("ProjectDB")
        {
            //bu alanda iki kez validation calıstırıp password length yüzünden hashleme sonrasındaki kontrolü tekrar yapmasını istemiyorsanız

            //Yine de illa validation'ı server side kullanmak istiyorsanız View Model yöntemini kullanırsınız.

            Configuration.ValidateOnSaveEnabled = false;


            //Unutmayın SetInitializer migration senaryolarında ayaga kalkmaz. Eger veritabanınızı illa bu verilerle olusturmak istiyorsanız bir yerde oraya bir istek göndermeniz gerekir.

            //Verileri yaratmak icin en basta alttaki kod satırının acık olması lazım. Ama veriler yaratıldıktan sonra artık gerek yok.

            Database.SetInitializer(new MyInitializer());




            //Yukarıdaki kod satırı ServerSide validation'ı tamamen sizin karar mekanizmalarınıza bırakır. 
            //Bunu yapmamızın nedeni bizim Client Side validation kullanacak olmamız ve validate'lerin cakısmasını istemiyor olmamızdandır.



        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new AppUserDetailMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserDetail> AppUserDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
       

    }
}
