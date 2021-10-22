using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TUSA.Data;
using Ref = TUSA.Domain.Entities;
using TUSA.Data.Paging;
using TUSA.Domain.Models;
using System.Linq;
using System;
using TUSA.Core.Result;
using TUSA.Domain.Entities;

namespace TUSA.Service
{
    public interface ISequenceNoService : IBaseService<Ref.SequenceNo>
    {
        IEnumerable<SequenceNo> UpdateRange(IEnumerable<SequenceNo> sequenceNos);
        Tuple<int, string> NextSequenceNo(string entity, string attribute);
        void Initialize(string entity, string attribute);
        Tuple<int, string> NextSequenceNo();
        void Update();
        string DisplaySeqNo(string entity, string attribute);
        void AddSequenceAttribute(string entity, string attribute);
    }

    public class SequenceNoService : BaseService<Ref.SequenceNo>, ISequenceNoService
    {
        private SequenceNo sequenceNo;
        public SequenceNoService(IUnitOfWork uow) : base(uow)
        {

        }

        public override IEnumerable<SequenceNo> GetList(string OrderBy)
        {
            return _UOW.GetRepository<SequenceNo>().Get(orderBy: o => o.OrderBy(x => x.EntityName));
        }

        public IEnumerable<SequenceNo> UpdateRange(IEnumerable<SequenceNo> items)
        {
            foreach (SequenceNo item in items)
            {
                SequenceNo sequenceNo = _UOW.GetRepository<SequenceNo>().Single();// x => x.ID == item.ID);
                if (sequenceNo != null)
                {
                    sequenceNo.NextNo = item.NextNo;
                    sequenceNo.Prefix = item.Prefix;
                    _UOW.GetRepository<SequenceNo>().Update(sequenceNo);
                }
            }
            _UOW.SaveChanges();
            return _UOW.GetRepository<SequenceNo>().GetAllList("");
        }

        public virtual Tuple<int, string> NextSequenceNo(string entity, string attribute)
        {
            sequenceNo = _UOW.GetRepository<SequenceNo>().Single(x => x.EntityName == entity && x.Attribute == attribute);
            if (sequenceNo != null)
            {
                int seq = sequenceNo.NextNo++;
                _UOW.GetRepository<SequenceNo>().Update(sequenceNo);
                return new Tuple<int, string>(seq, getNo(sequenceNo.Prefix, seq));
            }
            else { throw new NullReferenceException("Unable to generate next sequenceNo"); }
        }
        public void Initialize(string entity, string attribute)
        {
            sequenceNo = _UOW.GetRepository<SequenceNo>().Single(x => x.EntityName == entity && x.Attribute == attribute);
        }
        public Tuple<int, string> NextSequenceNo()
        {
            if (sequenceNo != null)
            {
                int seq = sequenceNo.NextNo++;
                return new Tuple<int, string>(seq, getNo(sequenceNo.Prefix, seq));
            }
            else { throw new NullReferenceException("Unable to generate next sequenceNo"); }
        }
        public void Update()
        {
            _UOW.GetRepository<SequenceNo>().Update(sequenceNo);
        }
        public string DisplaySeqNo(string entity, string attribute)
        {
            SequenceNo sequenceNo = _UOW.GetRepository<SequenceNo>().Single(x => x.EntityName == entity && x.Attribute == attribute);
            if (sequenceNo != null)
            {
                int seq = sequenceNo.NextNo++;
                return getNo(sequenceNo.Prefix, seq);
            }
            return "00000";
        }

        public void AddSequenceAttribute(string entity, string attribute)
        {
            _UOW.GetRepository<SequenceNo>().Add(new SequenceNo { EntityName = entity, Attribute = attribute });
        }
        private string getNo(string Prefix, int seq)
        {
            return $"{(string.IsNullOrEmpty(Prefix) ? "A" : Prefix)}{seq.ToString().PadLeft(5, '0')}";
        }
    }
}
