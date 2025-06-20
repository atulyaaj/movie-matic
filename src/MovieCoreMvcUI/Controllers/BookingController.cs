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
            //List<Booking> booking = new List<Booking>();
            //List<SelectListItem> userid = new List<SelectListItem>();
            //foreach (var item in booking)
            //{
            //    new Booking
            //    {
            //       UserId=item.User.FirstName,

            //    };
            //        //new SelectListItem{Value="2",Text="Ritik"}
            //}
            List<SelectListItem> userid = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="Select User Name"},
                new SelectListItem{Value="1",Text="Atulya"},

            };
            return userid;
        }
        public List<SelectListItem> GetShowTime()
        {
            List<SelectListItem> showtimeid = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="Select Show Time"},
                new SelectListItem{Value="1",Text="2022-10-19 00:30:00.0000000"},
                new SelectListItem{Value="2",Text="2022-10-20 09:30:00.0000000"},
                new SelectListItem{Value="3",Text="2022-10-20 23:45:00.0000000"},
                
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
