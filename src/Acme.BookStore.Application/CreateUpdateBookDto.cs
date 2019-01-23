using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.AutoMapper;

namespace Acme.BookStore
{
    /// <summary>
    /// 创建||更新DTO
    /// </summary>
    [AutoMapTo(typeof(Book))]
    [AutoMapFrom(typeof(BookDto))]//从 BookDto 到 CreateUpdateBookDto 的对象映射
    public class CreateUpdateBookDto
    {
        /// <summary>
        /// 书名
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        public BookType Type { get; set; } = BookType.Undefined;//赋默认值
        /// <summary>
        /// 发行日期
        /// </summary>
        [Required]
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [Required]
        public float Price { get; set; }
    }
}
