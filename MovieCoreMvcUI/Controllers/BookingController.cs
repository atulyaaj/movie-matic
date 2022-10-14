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
    public class BookingController : Controller
    {
        private IConfiguration _configuration;

        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Booking> bookingresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/GetBookings";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        bookingresult = JsonConvert.DeserializeObject<IEnumerable<Booking>>(result);
                    }
                }
            }
            return View(bookingresult);
        }
        public List<SelectListItem> GetUserName()
        {
            List<SelectListItem> userid = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="Select User Name"},
                new SelectListItem{Value="2",Text="Ritik"},
                new SelectListItem{Value="3",Text="Harsh"},
                new SelectListItem{Value="4",Text="Aditya"},
                new SelectListItem{Value="5",Text="Ashutosh"}
            };
            return userid;
        }
        public List<SelectListItem> GetShowTime()
        {
            List<SelectListItem> showtimeid = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="Select Show Time"},
                new SelectListItem{Value="2",Text="2022-10-11 00:03:32.5680000"},
                new SelectListItem{Value="6",Text="2022-09-25 21:30:00.0000000"},
                new SelectListItem{Value="7",Text="2021-09-02 14:45:00.0000000"},
                new SelectListItem{Value="8",Text="2022-10-29 21:30:00.0000000"},
                new SelectListItem{Value="9",Text="2021-09-14 11:35:00.0000000"},
                new SelectListItem{Value="10",Text="2022-10-17 22:10:00.0000000"}
            };
            return showtimeid;
        }
        public IActionResult BookingEntry()
        {
            ViewBag.useridlist = GetUserName();
            ViewBag.showtimeidlist = GetShowTime();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingEntry(Booking booking)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/AddBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details saved successfully!";
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

        public async Task<IActionResult> EditBooking(int BookingId)
        {
            Booking booking = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/GetBookingById?bookingId=" + BookingId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        booking = JsonConvert.DeserializeObject<Booking>(result);
                    }
                }
            }
            ViewBag.useridlist = GetUserName();
            ViewBag.showtimeidlist = GetShowTime();
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> EditBooking(Booking booking)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/UpdateBooking";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details updated successfully!";
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
        public async Task<IActionResult> DeleteBooking(int BookingId)
        {
            Booking booking = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/GetBookingById?bookingId=" + BookingId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        booking = JsonConvert.DeserializeObject<Booking>(result);
                    }
                }
            }
            return View(booking);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteBooking(Booking booking)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/DeleteBooking?bookingId=" + booking.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details deleted successfully!";
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
