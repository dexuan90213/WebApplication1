using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class Lesson1Controller : Controller
    {
        // GET: Lesson1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1A()
        {
            // 在View()裡面強制寫上檢視畫面的「檔名」
            return View("IndexHello");
        }

        public ActionResult Index1B()
        {
            // 在View()裡面強制寫上檢視畫面的「完整路徑 與 檔名」
            return View("~/Views/Lesson1/IndexHello.cshtml");
        }

        // 重點！傳回值的資料型態改為 字串（string）
        public string Index1C()
        {   
            return "傳回一句話，字串 -- <h3>string</h3>";
        }

        public ActionResult Index1D()
        {   
            return Content("用Content傳回一句話，<h3>Content()</h3>");
            // 另一種寫法
            // return Content("用Content傳回一句話，<h3>Content()</h3>", "text/Plain", System.Text.Encoding.UTF8);  // 最後需要 System.Text 命名空間

            //參考資料  ActionResult
            //https://msdn.microsoft.com/zh-tw/library/system.web.mvc.actionresult(v=vs.118).aspx
        }


        public ActionResult Index1E()
        {   
            return Redirect("http://www.yahoo.com.tw/");   // 輸入URL網址，連到其他網站
        }

        // 如果找不到動作（Action）或是輸入錯誤的動作名稱，一律跳回首頁
        // Controller的 HandleUnknownAction方法為 virtual，所以可用override覆寫。
        // https://msdn.microsoft.com/zh-tw/library/dd492730(v=vs.118).aspx

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Redirect("http://公司首頁(網址)/");    // 自訂結果 -- 找不到動作就跳回首頁
            base.HandleUnknownAction(actionName);
        }
        public ActionResult Index3()
        {
            ViewData["A"] = "(1). 字串A";
            ViewBag.B = "(2). 字串B";
            TempData["C"] = "(3). 字串C";

            return View();
        }

        public ActionResult Index3A()
        {
            ViewData["XYZ"] = "** 您好：我是ViewData **";
            ViewBag.XYZ = "抱歉！改了內容，我是ViewBag";

            return View();
            // 補充教材：https://www.c-sharpcorner.com/UploadFile/db2972/datatable-in-viewdata-sample-in-mvc-day-3/
            // DataTable，透過 ViewBag傳遞給 檢視畫面使用
        }
    }
}