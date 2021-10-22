using TUSA.Data;
using TUSA.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace TUSA.Service
{
    public interface ILookupService : IBaseService<LookUpValues>
    {

    } 

    public class LookupService : BaseService<LookUpValues>, ILookupService
    {
        public LookupService(IUnitOfWork uow) : base(uow)
        {

        }

        public override LookUpValues Add(LookUpValues item)
        {
            var items = _UOW.GetRepository<LookUpValues>().GetList(x => x.Code == item.Code).Items;
            item.Value = items.Count + 1;
            return base.Add(item);
        }

        public override IEnumerable<LookUpValues> Search(string code1)
        {
            var items = _UOW.GetRepository<LookUpValues>().GetList(x => x.Code == code1, orderBy: x => x.OrderBy(o => o.Text)).Items;

            return items;
        }
    }

}
