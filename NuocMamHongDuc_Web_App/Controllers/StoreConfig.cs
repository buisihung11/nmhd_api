using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMHD_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.Controllers
{
    [Route("api/storeconfig")]
    [ApiController]
    public class StoreConfigController : ControllerBase
    {
        private readonly NMHDDbContext _context;
        public StoreConfigController(NMHDDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public StoreConfig GetStoreConfig()
        {
            var storeConfig = _context.StoreConfigs.FirstOrDefault();
            return storeConfig;
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<StoreConfig> UpdateStoreConfig(int id, StoreConfig storeConfig)
        {
            var storeUpdate = _context.StoreConfigs.AsNoTracking().FirstOrDefault((s) => s.Id == id);
            if (storeUpdate == null)
            {
                return BadRequest();
            }
            storeConfig.Username = storeUpdate.Username;
            storeConfig.Password = storeUpdate.Password;
            _context.Update(storeConfig);
            _context.SaveChanges();
            return storeConfig;
        }
    }
}
