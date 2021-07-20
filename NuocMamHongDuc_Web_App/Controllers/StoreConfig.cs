using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("{id}")]
        public ActionResult<StoreConfig> UpdateStoreConfig(int id, StoreConfig storeConfig)
        {
            if (id != storeConfig.Id)
            {
                return BadRequest();
            }
            _context.Update(storeConfig);
            _context.SaveChanges();
            return storeConfig;
        }
    }
}
