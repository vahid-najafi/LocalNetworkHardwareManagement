using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class ActivitiesRepository: GenericRepository<Activities>, IActivitiesRepository
    {
        public ActivitiesRepository(LocalNetworkHardwareManagement_DBEntities db) : base(db)
        {
        }

        public IEnumerable<Activities> GetRecentActivities()
        {
            int count = _db.Activities.Count();
            if (count < 10)
                return _db.Activities.ToList();
            else
            {
                return _db.Activities.OrderBy(a => a.EventDate).Take(10).ToList();
            }
        }
    }
}
