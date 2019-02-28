using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudioManager.Models;

namespace StudioManager.Controllers
{
    public class HomeController : Controller
    {
        public List<StudioOrder> StudioOrderList = new List<StudioOrder>
        {
            new StudioOrder
            {
                Customer   = "Grab" ,
                Address = "Lĩnh Nam Hoàng Mai",
                Phonenumber = "0348340941",
                Location = "Ba Vì Hà Nôi"
            },
            new StudioOrder
            {
                Customer   = "Uber" ,
                Address = "Đội Cấn Ba đình",
                Phonenumber = "0348346574",
                Location = "Bãi đá sông hồng Hà Nôi"
            },
            new StudioOrder
            {
                Customer   = "Bee" ,
                Address = "Thụy khê Tây hồ",
                Phonenumber = "0348340941",
                Location = "Tuyệt tình cốc "
            },
            new StudioOrder
            {
                Customer   = "Emddi" ,
                Address = "Ngọc Khánh Kim Mã",
                Phonenumber = "03483234567",
                Location = "Lotte Bulding"
            }
        };
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            StudioOrder stu = new StudioOrder(); // tạo mới một đơn hàng rồi set các thuộc tính từ form html


            stu.Customer = collection["Customer"];
            stu.Phonenumber = collection["Phonenumber"];
            stu.Location = collection["Location"];
            stu.Address = collection["Address"];
            StudioOrderList.Add(stu);
            if (CreateConfirm(stu) == true)
            {
                return View(stu);
            }
            else
            {
                return View(new StudioOrder { Customer = "false", Phonenumber = "false", Location = "false", Address = "false" });
            }
        }
        public bool CreateConfirm(StudioOrder stu)
        {
            if (StudioOrderList.Contains(stu))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult ViewList()
        {
            return View(StudioOrderList);
        }

       [HttpGet]
        public ActionResult Delete(StudioOrder stu)
        {
            //StudioOrder stu = new StudioOrder();
              
            //stu.Customer = collection["Customer"];
            //stu.Phonenumber = collection["Phonenumber"];
            //stu.Address = collection["Address"];
            //stu.Location = collection["Location"];
            if (StudioOrderList.Contains(stu))
            {
                StudioOrderList.Remove(stu);
               
            }
            return View(stu);
        }

    }
}
