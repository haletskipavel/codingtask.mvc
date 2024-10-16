using CodingTask.Mvc.Domain.Entities;
using CodingTask.Mvc.Infrastructure;
using CodingTask.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingTask.Mvc.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tasksEntities = await _context.Tasks.ToListAsync();
            var taskDtos = tasksEntities.Select(x => new SimpleTaskDto
            {
                Description = x.Description,
                Title = x.Title,
                Id = x.Id,
            });
            return View(taskDtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] SimpleTaskDto task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new SimpleTask
                {
                    Title = task.Title,
                    Description = task.Description
                });
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var taskEntity = await _context.Tasks.FindAsync(id);
            
            if (id == null || taskEntity == null )
            {
                return NotFound();
            }

            return View(new SimpleTaskDto
            {
                Description = taskEntity.Description,
                Title = taskEntity.Title,
                Id = taskEntity.Id,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] SimpleTaskDto task)
        {
            var taskEntity = await _context.Tasks.FindAsync(id);

            if (id != task.Id || taskEntity == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                taskEntity.Description = task.Description;
                taskEntity.Title = task.Title;

                _context.Update(taskEntity);

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
