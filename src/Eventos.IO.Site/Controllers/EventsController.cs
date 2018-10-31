using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.IO.Site.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventAppService _eventAppService;

        public EventsController(IEventAppService eventAppService)
        {
            _eventAppService = eventAppService;
        }

        public IActionResult Index()
        {
            return View(_eventAppService.GetAll());
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = _eventAppService.GetById(id);

            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventViewModel eventViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventViewModel);
            }

            _eventAppService.New(eventViewModel);

            return View(eventViewModel);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = _eventAppService.GetById(id.Value);

            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EventViewModel eventViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventViewModel);
            }

            _eventAppService.Update(eventViewModel);

            // TODO: Validate if the operation was succeed

            return View(eventViewModel);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = _eventAppService.GetById(id.Value);

            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            _eventAppService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}