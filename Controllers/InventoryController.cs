using INV.BLL;
using INV.BO;
using INV.COMMON;
using INV.DAL;
using INV.IDAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Inventory_WebApp.Controllers
{
    public class InventoryController : Controller
    {
        private IINV_Inventories _iINV_Inventories  = null;
        private IINV_Customers _iNV_Customers = null;

        public InventoryController()
        {
            _iINV_Inventories = new BINV_Inventories();
            _iNV_Customers = new BINV_Customers();
        }
        public IActionResult Index()
        {
            ViewBag.CustomerList = _iNV_Customers.GetList();
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(INV_Inventories obj)
        {
            try
            {


                if (obj.InventoryId > 0)
                {
                    if (_iINV_Inventories.Update(obj, obj.InventoryId) > 0)
                    {
                        TempData["msgSuccess"] = " Update Successful";
                    }
                    else
                    {
                        TempData["msgNotSuccess"] = " Update Failed";
                    }
                }
                else
                {
                    if (_iINV_Inventories.Add(obj) > 0)
                    {
                        TempData["msgSuccess"] = "Save Success";
                    }
                    else
                    {
                        TempData["msgNotSuccess"] = "Save Failed";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["msgException"] = ex.Message.ToString();
            }
            return RedirectToAction("Index", "Inventory");
        }
        [HttpGet]
        public IActionResult List()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult List([FromBody] SearchParameter obj)
        {
            List<INV_Inventories> dataList = null;
            try
            {
                dataList = _iINV_Inventories.GetList();
            }
            catch (Exception ex)
            {
                TempData["msgException"] = ex.Message.ToString();
            }
            return Json(JsonConvert.SerializeObject(dataList));
        }

        public IActionResult Edit(int Id)
        {
            var obj = _iINV_Inventories.GetObjectById(Id);
            return View(obj);
        }

        public IActionResult Delete(int Id)
        {
            return View();
        }
    }
}
