using Microsoft.AspNetCore.Mvc;
using Student_Master_Areas.Areas.SEC_Register.Models;
using Student_Master_Areas.BAL;
using Student_Master_Areas.DAL;
using System.Reflection;

namespace Student_Master_Areas.Areas.SEC_Register.Controllers
{
    [CheckAccess]
    [CheckAdmin]
    [Area("SEC_Register")]
    [Route("SEC_Register/{controller}/{action}")]
    public class SEC_RegisterController : Controller
    {
        public IActionResult SEC_Register()
        {
            return View();
        }
        public IActionResult Register(SEC_RegisterModel sEC_RegisterModel) 
        {

            if (ModelState.IsValid)
            {
                // Handle the uploaded file
                var randomGenerator = new Random();
                var random = randomGenerator.Next(1, 1000000);
                if (sEC_RegisterModel.File != null && sEC_RegisterModel.File.Length > 0)
                {
                    // Save the file or process it as needed
                    var path = Path.Combine(Environment.CurrentDirectory, "wwwroot","img","UserImage", random.ToString()+"."+ sEC_RegisterModel.File.ContentType.Split('/')[1]);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        sEC_RegisterModel.File.CopyTo(stream);
                        Console.WriteLine("Image Done");
                    }
                }
                else
                {
                    Console.WriteLine("IMage Not DOne");
                }
                sEC_RegisterModel.ImageURL = random.ToString() + "." + sEC_RegisterModel.File.ContentType.Split('/')[1];
                SEC_DAL sEC_DAL = new SEC_DAL();
                sEC_DAL.Insert_New_User(sEC_RegisterModel);
                TempData["Login"] = "Accountry Created Login To Continue....";
                return RedirectToAction("SEC_Login", "SEC_Login", new { area = "SEC_Login" });
                // Process other form data
                // model.UserName

                // Redirect or return a response
            }
            else
            {
                return View("SEC_Register");
            }
            
            //Console.WriteLine(sEC_RegisterModel.File.FileName.ToString());
            //Console.WriteLine(sEC_RegisterModel.File.Name);
            //Console.WriteLine(sEC_RegisterModel.File.ContentType);
            
        }
    }
}
