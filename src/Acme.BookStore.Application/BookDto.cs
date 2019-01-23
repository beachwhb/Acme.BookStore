using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AutoMapper;

namespace Acme.BookStore
{
    /// <summary>
    /// 自动把DTO对象的字段映射到实体Book上
    /// </summary>
    [AutoMapFrom(typeof(Book))]
    public class BookDto:AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public BookType Type { get; set; }

        /// <summary>
        /// 发行日期
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }
    }
}
