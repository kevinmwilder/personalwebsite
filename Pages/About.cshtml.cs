using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using site;

namespace site.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
           Message = GeoLocation.LocationFromIp(
           HttpContext.Connection.RemoteIpAddress.ToString());
        }
    }
}
