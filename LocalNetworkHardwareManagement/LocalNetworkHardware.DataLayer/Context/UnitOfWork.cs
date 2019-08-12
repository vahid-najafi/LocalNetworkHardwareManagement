using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        LocalNetworkHardwareManagement_DBEntities db = 
            new LocalNetworkHardwareManagement_DBEntities();





        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
