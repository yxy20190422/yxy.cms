using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.Models.DBModel;
using Sample.BLL;

namespace Sample.Controllers
{
    public class ContentController : Controller
    {
        private readonly List<Content> contents;
        //public ContentController(IOptions<List<Content>> option)
        //{
        //    contents = option.Value;
        //}
        public IActionResult Index()
        {
            
            SqlHelper helper = new SqlHelper();
            string sql = @"select * from content where id=@id;
select * from comment where content_id=@id;";
            Sample.Models.ContentWithComment param = new Models.ContentWithComment() { id = 1 };
            //var res= helper.test_select_one<Content>(sql, new Content { id = 3 });
             helper.ExcuiteQueryMultiple<Sample.Models.ContentWithComment>(sql, param);
            return View();
        }
    }
}