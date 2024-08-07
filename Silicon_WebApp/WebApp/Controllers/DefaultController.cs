using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace WebApp.Controllers;

public class DefaultController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;
    public IActionResult Home()
    {
        return View();
    }

    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if(ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7266/api/subscribe", content);
            if(response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "You are now subscribed";
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                TempData["StatusMessage"] = "You are already subscribed";
            }
        }
        else
        {
            TempData["StatusMessage"] = "Invalid Email address";
        }

        return RedirectToAction("Home", "Default", "subscribe");
    }
}
