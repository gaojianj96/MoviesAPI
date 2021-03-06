﻿using System.Collections.Generic;
using Movies.Models;
using Newtonsoft.Json;


namespace MoviesAPI.Models
{
    public class Credits
    {
        [JsonProperty("cast")]
        public List<Cast> Cast { get; set; }
        [JsonProperty("crew")]
        public List<Crew> Crew { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}