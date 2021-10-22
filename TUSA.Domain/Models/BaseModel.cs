using System;
using System.ComponentModel.DataAnnotations;

namespace TUSA.Domain.Models
{
    public class BaseModel
    {
        public int ID { get; set; }

        //public virtual string DependentIdName { get; set; }
    }

    //public class LookUpValues
    //{
    //    public string Text { get; set; }
    //    public int Value { get; set; }
    //}
}