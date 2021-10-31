using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities;

namespace TUSA.Service
{
    public interface IQuickAndRecentService : IBaseService<recently_accessed_screens>
    {
        IEnumerable<recently_accessed_screens> GetRecentAccessesScreens(string LogInUser);
        IEnumerable<quick_access_screens> GetQuickAccessesScreens(string LogInUser);
    }
   public class QuickAndRecentService:BaseService<recently_accessed_screens>, IQuickAndRecentService
    {
        public QuickAndRecentService(IUnitOfWork uow) : base(uow)
        {

        }

        public IEnumerable<recently_accessed_screens> GetRecentAccessesScreens(string LogInUser)
        {
            return _UOW.GetRepository<recently_accessed_screens>().Get(x => x.user_master.user_name == LogInUser,
                include:x=>x.Include(x=>x.forms_master)).OrderBy(x => x.form_list_order);
        }
        public IEnumerable<quick_access_screens> GetQuickAccessesScreens(string LogInUser)
        {
            return _UOW.GetRepository<quick_access_screens>().Get(x => x.user_master.user_name == LogInUser, 
                include: x => x.Include(x => x.forms_master)).OrderBy(x => x.form_list_order);
        }

    }
}
