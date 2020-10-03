using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
       public async Task<IActionResult> IndexAsync(){
            List<string> output = new List<string>();
            //foreach (long? len in await MyAsyncMethods.GetPageLengths(output, "apress.com", "microsoft.com", "amazon.com"))
            //{
            //    output.Add($"Page length: { len}");
            //}

            await foreach (long? len in MyAsyncMethods.GetPageLengths(output, "apress.com", "microsoft.com", "amazon.com"))
            {
                output.Add($"Page length: { len}");
            }
            return View();
       }

        [HttpGet]
       public ViewResult RsvpForm() 
       {
           return View();
       }

       [HttpPost]
       public ViewResult RsvpForm(GuestResponse guestResponse)
       {
            string por = null;
           if(ModelState.IsValid){
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
           }else{
               return View();
           }
       }

       public ViewResult ListResponses()
       {
           return View(Repository.Responses.Where(x =>x.WillAttend == true));
       }
    }
}
