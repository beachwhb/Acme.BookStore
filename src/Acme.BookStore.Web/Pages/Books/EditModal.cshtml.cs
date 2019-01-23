using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.BookStore.Pages.Books
{
    public class EditModalModel : BookStorePageModelBase
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]//SupportsGet 从Http请求的查询字符串中获取Id的值
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }

        private readonly IBookAppService _bookAppService;

        public EditModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        /// <summary>
        /// 将 BookAppService.GetAsync 方法返回的 BookDto 映射成 CreateUpdateBookDto 并赋值给Book属性
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            var bookDto = await _bookAppService.GetAsync(Id);
            Book = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto);
        }

        /// <summary>
        /// 直接使用 BookAppService.UpdateAsync 来更新实体.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.UpdateAsync(Id, Book);
            return NoContent();
        }

    }
}