using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC.Models
{
    public class GameModel
    {
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string short_description { get; set; }
        public string game_url { get; set; }
        public string Platform { get; set; }

    }
}