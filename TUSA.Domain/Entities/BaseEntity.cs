
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUSA.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime created_date { get; set; }
        public DateTime modified_date { get; set; }
        public string created_by { get; set; }
        public string modified_by { get; set; }
    }
    public class AuditEntity : BaseEntity
    {
     
    }
    public class DataGroupEntity : AuditEntity
    {
        //public int DataGroupId { get; set; } 
    }

    public class ValueText
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; }
    } 
}