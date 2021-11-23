using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.QuickAndRecent;
using TUSA.Domain.Models.QuickAndRecent.Request;

namespace TUSA.Service
{
    public interface IQuickAndRecentService : IBaseService<recently_accessed_screens>
    {
        List<form_details> GetRecentAccessesScreens(string LogInUser);
        List<form_details> GetQuickAccessesScreens(string LogInUser);
       ApiResponce AddQuickAccessesScreens(QuickAccessScreenAddRequest request, string LogInUser);

        ApiResponce AddformDetails(form_details_request request,string login_user);
    }
   public class QuickAndRecentService:BaseService<recently_accessed_screens>, IQuickAndRecentService
    {
        public QuickAndRecentService(IUnitOfWork uow) : base(uow)
        {

        }

        public List<form_details> GetRecentAccessesScreens(string LogInUser)
        {
            List<form_details> list = new List<form_details>();
            List<recently_accessed_screens> recently_accessed_screens= _UOW.GetRepository<recently_accessed_screens>().Get(x => x.user_master_Id == LogInUser).OrderBy(x => x.last_accessed).ToList();
            foreach (recently_accessed_screens screen in recently_accessed_screens)
            {
                list.Add(_UOW.GetRepository<form_details>().Single(x=>x.id==screen.form_details_id));
            }
            return list;
        }
        public List<form_details> GetQuickAccessesScreens(string LogInUser)
        {
            List<form_details> list = new List<form_details>();
            List<quick_access_screens> quick_accessed_screens = _UOW.GetRepository<quick_access_screens>().Get(x => x.user_master_Id == LogInUser).OrderBy(x => x.last_accessed).ToList();
            foreach (quick_access_screens screen in quick_accessed_screens)
            {
                list.Add(_UOW.GetRepository<form_details>().Single(x => x.id == screen.form_details_id));
            }
            return list;
        }

        public ApiResponce AddformDetails(form_details_request request, string login_user)
        {

            form_details fd = _UOW.GetRepository<form_details>().Single(x => x.relavent_name == request.relavent_name && x.form_id==request.form_id);
            try
            {
                if (fd == null)
                {
                    fd = new form_details();
                    fd.form_id = request.form_id;
                    fd.relavent_name = request.relavent_name;
                    fd.icon = request.icon;
                    fd.link = request.link;
                    _UOW.GetRepository<form_details>().Add(fd);
                    _UOW.SaveChanges();
                }
                else
                {
                    return new ApiResponce() { Status = false, Message = "Form already exist", ErrorType = false };
                }
            }
            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message = Ex.Message, ErrorType = false };
            }
            return new ApiResponce() { Status = true, Message = "", ErrorType = true };
        }

        public ApiResponce AddQuickAccessesScreens(QuickAccessScreenAddRequest request,string LogInUser)
        {
            try
            {
                form_details fd = _UOW.GetRepository<form_details>().Single(x => x.id==request.form_details_id);
                if(fd==null)
                {
                    return new ApiResponce() { Status = false, Message = "Form not exists", ErrorType = false };
                }
               
                quick_access_screens screen = _UOW.GetRepository<quick_access_screens>().Get(x => x.form_details_id == fd.id && x.user_master_Id == LogInUser).FirstOrDefault();
                if (screen == null)
                {
                    screen = new quick_access_screens()
                    {
                        user_master_Id = LogInUser,
                        form_details_id = fd.id,
                        last_accessed=DateTime.Now
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
