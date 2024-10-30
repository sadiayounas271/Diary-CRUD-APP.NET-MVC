using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
	public class DiaryEnteriesController : Controller
	{
		private readonly ApplicationDbContext _db;
		public DiaryEnteriesController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<DiaryModel> objDiaryEntryList = _db.DiaryEntries.ToList();
			return View(objDiaryEntryList);

		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(DiaryModel diaryModel)
		{
			if (diaryModel != null && diaryModel.Title.Length < 3)
			{
				ModelState.AddModelError("Title", "Title too short");
			}

			if (ModelState.IsValid)
			{
				_db.DiaryEntries.Add(diaryModel);
				_db.SaveChanges();
				return RedirectToAction("Index", "Home");
			}

			return View(diaryModel);
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}
			DiaryModel? db = _db.DiaryEntries.FirstOrDefault(x => x.Id == id);
			if (id == null)
			{
				return NotFound();
			}
			return View(db);
		}

		[HttpPost]
		public IActionResult Edit(DiaryModel diaryModel)
		{
			if (diaryModel != null && diaryModel.Title.Length < 3)
			{
				ModelState.AddModelError("Title", "Title too short");
			}

			if (ModelState.IsValid)
			{
				_db.DiaryEntries.Update(diaryModel);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(diaryModel);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}
			DiaryModel? db = _db.DiaryEntries.FirstOrDefault(x => x.Id == id);
			if (id == null)
			{
				return NotFound();
			}
			return View(db);
		}

		[HttpPost]
		public IActionResult Delete(DiaryModel diaryModel)
		{
	
				_db.DiaryEntries.Remove(diaryModel);
				_db.SaveChanges();
				return RedirectToAction("Index");
			
		}
	}
}
