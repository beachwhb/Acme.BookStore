using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore
{
    [Table("Books")]
    public class Book : AuditedAggregateRoot<Guid> //继承聚合根
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }

    }
}
