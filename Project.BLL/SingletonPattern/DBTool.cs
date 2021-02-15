using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.SingletonPattern
{
   public class DBTool
    {
        
        //Su anda Singleton pattern hicbir sıkıntı olmadan calısır. ANcak bu proje asynkron metotlarla calısma durumunuz olabilir. Bu durumda basınıza söyle bir şey gelebilir.

        private DBTool() { }

        private static MyDBContext _dbInstance;


        //lock mekanizması multi-threading durumlarda (aynı anda yapılan coklu işlemlerde)  bizim bu işlemleri kitlememizi saglayan bir yöntemdir. Burada aynı anda gelen işlemleri manuel olarak yönetirsiniz. Bunun icin ilgili sınıf tetiklendiginde global alanda olusan bir yapı eger object tipindeyse gelen asenkron metotları tamamen kitleyebilme mekanizmasında kullanılabilir. Böylece sınıf ayaga kalktıgında kendisi icerisinde otomatik olarak global alanda bir yapı yapacak. Karar mekanizmasında bu yapı lock keyword'uyle kitlendigi icin mecburi anlamda işlemler sıraya girmek zorunda olacak.

        private static object _lockSync = new object();


        public static MyDBContext DBInstance
        {
            get
            {

                if (_dbInstance == null)
                {

                    lock (_lockSync)
                    {
                        if (_dbInstance==null)
                        {
                            _dbInstance = new MyDBContext();
                        }
                    }

                   
                }

                return _dbInstance;

            }
        }






    }
}
