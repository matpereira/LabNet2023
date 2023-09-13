using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lab.EF.MVC.Models;
using Newtonsoft.Json;

namespace Lab.EF.MVC.Controllers
{
    public class FreeToGameController : Controller
    {

        private readonly string apiUrl = "https://www.freetogame.com/api/games";

        public async Task<ActionResult> Index(string platformFilter)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        List<GameModel> games = JsonConvert.DeserializeObject<List<GameModel>>(data);

                        // Obtén una lista de todas las plataformas disponibles
                        var allPlatforms = games.Select(game => game.Platform).Distinct().ToList();

                        if (!string.IsNullOrEmpty(platformFilter))
                        {
                            // Aplica el filtro si se ha seleccionado una plataforma
                            games = games.Where(game => game.Platform == platformFilter).ToList();
                        }

                        // Configura ViewBag con la lista completa de plataformas
                        ViewBag.AllPlatforms = new SelectList(allPlatforms);

                        ViewBag.platformFilter = platformFilter;

                        return View(games);
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error al obtener datos de la API.";
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }



    }
}
