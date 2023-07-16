using INV.BLL;
using INV.BO;
using INV.COMMON;
using INV.IDAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Inventory_WebApp.Controllers
{

    public class ProductController : Controller
    {
        private IINV_Products _iINV_Products = null;

        public ProductController()
        {
            _iINV_Products = new BINV_Products();
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult List()
        //{
        //    //try
        //    //{
        //    //    Sha1 sha1Obj = new Sha1();
        //    //    var cook = HttpContext.Request.Cookies[CommonCookie.cookName.userCook.ToString()];
        //    //    if (cook != null)
        //    //    {
        //    //        if (!new MemberShips().CheckMemberShip(sha1Obj.GetDecryptString(Request.Cookies[CommonCookie.CookValue.userName.ToString().ToString()]), Request.Cookies[CommonCookie.CookValue.password.ToString().ToString()]))
        //    //        {
        //    //            return RedirectToAction("Login", "UserAuthenticate");
        //    //        }
        //    //        else
        //    //        {
        //    //            if (HttpContext.Session.GetString(UserSession.UserName.ToString()) == null)
        //    //            {
        //    //                return RedirectToAction("LockScreen", "UserAuthenticate");
        //    //            }
        //    //            //if (!new ValidRole().SetVisibility(1) && !new ValidRole().SetVisibility(2) && !new ValidRole().SetVisibility(3) && !new ValidRole().SetVisibility(4))
        //    //            //{
        //    //            //    return RedirectToAction("Login", "UserAuthenticate");
        //    //            //}
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        return RedirectToAction("Login", "UserAuthenticate");
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    TempData["msgException"] = ex.Message.ToString();
        //    //}
        //    return View();
        //}
        [HttpGet]
        public IActionResult List([FromBody] SearchParameter obj)
        
        
        {
            List<INV_Products> dataList = null;
            try
            {
                dataList = _iINV_Products.GetList();
            }
            catch (Exception ex)
            {
                TempData["msgException"] = ex.Message.ToString();
            }
            return Json(JsonConvert.SerializeObject(dataList));
        }

        public JsonResult GetItemList()
        {
            var itemList = _iINV_Products.GetList();
            return Json(itemList);
        }
    }
}
