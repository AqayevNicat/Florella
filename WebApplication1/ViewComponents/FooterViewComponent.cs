using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.ViewComponenets
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly FlorellaDbContext _context;
        public FooterViewComponent(FlorellaDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _context.Settings.ToDictionaryAsync(x=>x.Key,x=>x.Value);
            return View(await Task.FromResult(setting));
        }
    }
}
