using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.user = "asp";
            ViewBag.pass = "asp";
            ViewBag.Rem = Request.Cookies["Name"];
            if(ViewBag.Rem != null)
            {
                return RedirectToAction("Op2N");
            }   
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult Login(string name , string pass ,string status , string b1)
        {
           
            
            if(name == "asp")
            {
                if (pass =="asp")
                {

                        ViewBag.status = "Valid User";
                        ViewBag.user = name;
                        ViewBag.pass = pass;
                    if(b1=="Rem")
                    {
                        CookieOptions obj = new CookieOptions();
                        obj.Expires = DateTime.Now.AddDays(7);
                        obj.Secure = true;
                        Response.Cookies.Append("Name", name, obj);
                        return RedirectToAction("Op2N");
                    }
                    else
                        return RedirectToAction("Op2N");
                    } 
               
                else
                {
                    ViewBag.user = name;
                    ViewBag.pass = pass;
                    ViewBag.status = "Invalid User";
                    return View();
                }
            }
            else
            {
                ViewBag.user = name;
                ViewBag.pass = pass;
                ViewBag.status = "Invalid User";
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Op2N()
        {
            ViewBag.No1 = 0;
            ViewBag.No2 = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Op2N(int No1 , int No2 , string b1)
        {
            if (b1 == "max")
            {
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.Res = Math.Max(No1, No2);
                return View();
            }
            else if(b1 == "min") 
            {
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.Res = Math.Min(No1, No2);
                return View();
            }
            else if (b1 == "avg")
            {
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.Res = (No1 + No2) / 2;
                return View();
            }
            else
            {
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                return View();
            }    
            
            
        }
        [HttpGet]
        public IActionResult Calc2N()
        {
            ViewBag.No1 = 0;
            ViewBag.No2 = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Calc2N(int No1, int No2 , string calcop)
        {
            if (calcop == "add")
            {
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.Calcop = calcop;
                ViewBag.Res = No1 + No2;
                return View();
            }
            else if (calcop == "sub")
            {
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.Res = No1 - No2;
                ViewBag.Calcop = calcop;
                return View();
            }
            else if (calcop == "div")
            {
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.Res = (Convert.ToDouble(No1)/ Convert.ToDouble(No2));
                ViewBag.Calcop = calcop;
                return View();
            }
            else
            {
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.Calcop = calcop;
                return View();
            }


        }

        [HttpGet]
        public IActionResult SecMin()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult SecMin(int No1, int No2, int No3)
        {
          
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.No3 = No3;
            if ((No1 > No2 && No1 < No3) || (No1 < No2 && No1 > No3))
            {
                ViewBag.res = No1;
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.No3 = No3;
            }
            else if ((No2 > No1 && No2 < No3) || (No2 < No1 && No2 > No3))
            {
                ViewBag.res = No2;
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.No3 = No3;
            }
            else
            {
                ViewBag.res = No3;
                ViewBag.No1 = No1;
                ViewBag.No2 = No2;
                ViewBag.No3 = No3;
            }


            return View();
            


        }
        [HttpGet]
        public IActionResult Op3N()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Op3N(int No1 , int No2 , int No3 , string op)
        {
            if (op == "Max")
            {
                TempData["Resault"] = Math.Max(No1, Math.Max(No3, No2));
                TempData["Operation"] = op;
                return RedirectToAction("Op3N2");
            }
            else
            {
                TempData["Resault"] = (No1 + No2+No3) / 3;
                TempData["Operation"] = op;
                return RedirectToAction("Op3N2");
            }
                
        }
        [HttpGet]
        public IActionResult Op3N2()
        {
            if (TempData["Operation"] != null)
                return View();
            else
                return RedirectToAction("Op3N");
        }
        [HttpPost]
        [ActionName("Op3N2")]
        public IActionResult Back()
        {

            return RedirectToAction("Op3N");
        }

        [HttpGet]
        public IActionResult PPC()
        {
            ViewBag.Prod = HttpContext.Session.GetString("prod");
            ViewBag.price = HttpContext.Session.GetString("price");
            ViewBag.count = HttpContext.Session.GetString("count");
            ViewBag.total = HttpContext.Session.GetString("total");
            return View();
        }
        [HttpPost]
        public IActionResult PPC(string prod , int price , int count)
        {
            HttpContext.Session.SetString("prod",prod);
            HttpContext.Session.SetString("price", price.ToString());
            HttpContext.Session.SetString("count", count.ToString());
            HttpContext.Session.SetString("total", (price*count).ToString());
            return RedirectToAction("PPC2");
        }

        [HttpGet]
        public IActionResult PPC2()
        {
            ViewBag.Prod = HttpContext.Session.GetString("prod");
            ViewBag.price = HttpContext.Session.GetString("price");
            ViewBag.count = HttpContext.Session.GetString("count");
            ViewBag.total = HttpContext.Session.GetString("total");
            if (ViewBag.total != null)
                return View();
            else
                return RedirectToAction("PPC");
            
        }
        [HttpPost]
        [ActionName("PPC2")]
        public IActionResult Backp()
        {

            return RedirectToAction("PPC");
        }

        [HttpGet]
        public IActionResult P1()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult P1(string User , string PName)
        {
            HttpContext.Session.SetString("User", User);
            HttpContext.Session.SetString("PName", PName);
            return RedirectToAction("P2");
        }
        [HttpGet]
        public IActionResult P2()
        {
            ViewBag.check = HttpContext.Session.GetString("User");
            if (ViewBag.check != null)
                return View();
            else
                return RedirectToAction("P1");

        }
        [HttpPost]
        public IActionResult P2(int price , int count)
        {
            TempData["price"]= price;
            TempData["count"]= count;
            TempData["total"] = price*count;
            return RedirectToAction("P3");
        }
        [HttpGet]
        public IActionResult P3()
        {
            ViewBag.name = HttpContext.Session.GetString("User");
            ViewBag.PName = HttpContext.Session.GetString("PName");
            if (TempData["total"] != null)
                return View();
            else
                return RedirectToAction("P1");

        }

        [HttpGet]
        public IActionResult Dept()
        {
           
            return View();

        }

        [HttpPost]
        public IActionResult Dept(string dept , string phone , string desc)
        {
            TempData["dept"]= dept;
            HttpContext.Session.SetString("phone",phone);
            CookieOptions obj = new CookieOptions();
            obj.Expires = DateTime.Now.AddDays(7);
            obj.Secure = true;
            Response.Cookies.Append("desc",desc,obj);
            return RedirectToAction("Dept1");

        }
        [HttpGet]
        public IActionResult Dept1()
        {
            ViewBag.phone = HttpContext.Session.GetString("phone");
            ViewBag.desc = Request.Cookies["desc"];
            return View();

        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();

        }

        [HttpGet]
        public IActionResult Index() 
        {
            return View();
        }
    }
}
