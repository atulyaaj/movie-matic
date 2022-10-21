using BookMyShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUI.Controllers
{
    public class ShowTimingController : Controller
    {
        private IConfiguration _configuration;
        public ShowTimingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ShowTiming> showtimingresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTimings";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showtimingresult = JsonConvert.DeserializeObject<IEnumerable<ShowTiming>>(result);
                    }
                }
            }
            return View(showtimingresult);
        }
        public List<SelectListItem> GetMovieName()
        {
            List<SelectListItem> movieid = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="Select Movie Name"},
                new SelectListItem{Value="1",Text="URI"},
                new SelectListItem{Value="2",Text="Avengers"},
                new SelectListItem{Value="3",Text="Joker"},
      
            };
            return movieid;
        }
        public List<SelectListItem> GetTheatreName()
        {
            List<SelectListItem> theatreid = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="Select Theatre Name"},
                new SelectListItem{Value="1",Text="INOX II"},


            };
            return theatreid;
        }
        public IActionResult ShowTimingEntry()
        {
            ViewBag.movieidlist = GetMovieName();
            ViewBag.theatreidlist=GetTheatreName();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowTimingEntry(ShowTiming showTiming)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(showTiming), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTiming/AddShowTiming";
                using (var response = await client.PostAsync(endPoint, content))
                {

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        
                        ViewBag.status = "Ok";
                        ViewBag.message = "Details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> EditShowTiming(int ShowTimingId)
        {
            ShowTiming showTiming = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTimingById?showTimingId=" + ShowTimingId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTiming = JsonConvert.DeserializeObject<ShowTiming>(result);
                    }
                }
                
            }
            ViewBag.movieidlist = GetMovieName();
            ViewBag.theatreidlist = GetTheatreName();
            return View(showTiming);
        }

        [HttpPost]
        public async Task<IActionResult> EditShowTiming(ShowTiming showTiming)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(showTiming), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTiming/UpdateShowTiming";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Show Timing details updated successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
     
            return View();

        }
        public async Task<IActionResult> DeleteShowTiming(int ShowTimingId)
        {
            ShowTiming showTiming = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTiming/GetShowTimingById?showTimingId=" + ShowTimingId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTiming = JsonConvert.DeserializeObject<ShowTiming>(result);
                    }
                }
            }
            return View(showTiming);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteShowTiming(ShowTiming showTiming)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTiming/DeleteShowTiming?showTimingId=" + showTiming.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Show Timing details deleted successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View();

        }
    }
}
