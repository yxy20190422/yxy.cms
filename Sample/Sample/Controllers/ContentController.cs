using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.Models;

namespace Sample.Controllers
{
    public class ContentController : Controller
    {
        private readonly List<Content> contents;
        public ContentController(IOptions<List<Content>> option)
        {
            contents = option.Value;
        }
        public IActionResult Index()
        {
            //var contentList = new List<Content>();
            //for (var i = 0; i < 11; i++)
            //{
            //    contentList.Add(new Content()
            //    {
            //        Id = i,
            //        title = i.ToString() + "的标题",
            //        content = i.ToString() + "的内容",
            //        status = 1,
            //        createtime = DateTime.Now.AddDays(-i)
            //    });
            //}
            return View(new ContentViewModel() { Contents = contents });
        }
    }
}