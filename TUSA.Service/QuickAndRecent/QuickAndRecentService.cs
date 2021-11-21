using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain;
using TUSA.Domain.Entities;
using TUSA.Domain.Models.QuickAndRecent.Request;

namespace TUSA.Service
{
    public interface IQuickAndRecentService : IBaseService<recently_accessed_screens>
    {
        List<forms_master> GetRecentAccessesScreens(string LogInUser);
        List<forms_master> GetQuickAccessesScreens(string LogInUser);
       ApiResponce AddQuickAccessesScreens(QuickAccessScreenAddRequest request, string LogInUser);
    }
   public class QuickAndRecentService:BaseService<recently_accessed_screens>, IQuickAndRecentService
    {
        public QuickAndRecentService(IUnitOfWork uow) : base(uow)
        {

        }

        public List<forms_master> GetRecentAccessesScreens(string LogInUser)
        {
            List<forms_master> list = new List<forms_master>();
            List<recently_accessed_screens> recently_accessed_screens= _UOW.GetRepository<recently_accessed_screens>().Get(x => x.user_master_Id == LogInUser).OrderBy(x => x.form_list_order).ToList();
            foreach (recently_accessed_screens screen in recently_accessed_screens)
            {
                list.Add(_UOW.GetRepository<forms_master>().Single(x=>x.form_id==screen.form_Id));
            }
            return list;
        }
        public List<forms_master> GetQuickAccessesScreens(string LogInUser)
        {
            List<forms_master> list = new List<forms_master>();
            List<quick_access_screens> quick_accessed_screens = _UOW.GetRepository<quick_access_screens>().Get(x => x.user_master_Id == LogInUser).OrderBy(x => x.form_list_order).ToList();
            foreach (quick_access_screens screen in quick_accessed_screens)
            {
                list.Add(_UOW.GetRepository<forms_master>().Single(x => x.form_id == screen.form_Id));
            }
            return list;
        }

        public ApiResponce AddQuickAccessesScreens(QuickAccessScreenAddRequest request,string LogInUser)
        {
            try
            {
                forms_master master = _UOW.GetRepository<forms_master>().Single(x => x.form_id == request.form_id);
                quick_access_screens screen = _UOW.GetRepository<quick_access_screens>().Get(x => x.form_Id == request.form_id && x.user_master_Id == LogInUser).FirstOrDefault();
                if (screen == null && master != null)
                {
                    screen = new quick_access_screens()
                    {
                        user_master_Id = LogInUser,
                        form_list_order = 1,
                        form_Id = request.form_id,
                        created_date = DateTime.Now,
                        created_by = LogInUser
                    };
                    _UOW.GetRepository<quick_access_screens>().Add(screen);
                    _UOW.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message = Ex.Message, ErrorType = false };
            }
            return new ApiResponce() { Status = true, Message = "", ErrorType = true };
        }

    }
}
