using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeforeApp.Data.Repositories;
using BeforeApp.Data.Entities;
using AutoMapper;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using BeforeApp.Models;

namespace BeforeApp.Data.Services
{
    public interface IEventService
    {
        public void Add(EventModel model);
        public EventModel Update(EventModel model, int id);
    }
}
