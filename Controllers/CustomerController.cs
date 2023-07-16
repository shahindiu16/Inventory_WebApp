using INV.BLL;
using INV.BO;
using INV.COMMON;
using INV.IDAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Inventory_WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private IINV_Customers _iNV_Customers = null;

        public CustomerController()
        {
            _iNV_Customers = new BINV_Customers();
        }
        public IActionResult Index()
        {
            return View();
            
        }
        [HttpGet]
        public IActionResult Add()
        {
            //ViewBag.CustomerList = _iNV_Customers.GetList();
            return View();
        }

        //[HttpGet]
        //public IActionResult List([FromBody] SearchParameter obj)
        //{
        //    List<INV_Customers> dataList = null;
        //    try
        //    {
        //        dataList = _iNV_Customers.GetList();
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["msgException"] = ex.Message.ToString();
        //    }
        //    return Json(JsonConvert.SerializeObject(dataList));
        //}
    }
}
