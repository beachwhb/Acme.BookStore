using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore
{
    public interface IBookAppService : IAsyncCrudAppService<//定义了CRUD方法
        BookDto, //用来展示书籍
        Guid, //Book实体的主键
        PagedAndSortedResultRequestDto, //获取书籍的时候用于分页和排序
        CreateUpdateBookDto, //用于创建书籍
        CreateUpdateBookDto //用户更新书籍
        >
    {
        //IAsyncCrudAppService中定义了基础的 CRUD方法:GetAsync, GetListAsync, CreateAsync, UpdateAsync 和 DeleteAsync
    }
}
