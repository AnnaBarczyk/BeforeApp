﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeforeApp.Data.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string PlaceName { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}