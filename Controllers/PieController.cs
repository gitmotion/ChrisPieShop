using ChrisPieShop.Models;
using ChrisPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChrisPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //First method
            //ViewBag.CurrentCategory = "Cheese cakes";
            //return View(_pieRepository.AllPies);

            // View Model
            PieListViewModel piesListViewModel = new PieListViewModel
                (_pieRepository.AllPies, "Cheese cakes");

            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if(pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
