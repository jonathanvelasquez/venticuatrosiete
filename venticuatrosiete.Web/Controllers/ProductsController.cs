using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using venticuatrosiete.Web.Data;
using venticuatrosiete.Web.Data.Entities;

namespace venticuatrosiete.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_repository.GetProducts());
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _repository.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
               await _repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _repository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateProduct(product);
                    await _repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repository.ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _repository.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _repository.GetProduct(id);
            _repository.RemoveProduct(product);
            await _repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
