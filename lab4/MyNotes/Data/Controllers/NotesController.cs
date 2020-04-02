using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
using MyNotes.Data.Repositories;

namespace MyNotes.Data.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepository _notesRepository;
        public IActionResult Index()
        {
            return View();
        }
        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
            NotesRepository.SetStoragePathAsync("storage/notes.json");
        }
        [HttpGet]
        [Route("notes/list")]
        public JsonResult List()
        {
            var notes = _notesRepository.GetAll();
            return new JsonResult(notes);
        }

        readonly static System.Text.Encoding WINDOWS1251 = Encoding.GetEncoding(1251);
        readonly static System.Text.Encoding UTF8 = Encoding.UTF8;

        static string ConvertWin1251ToUTF8(string inString)
        {
            return UTF8.GetString(WINDOWS1251.GetBytes(inString));
        }

        [HttpPost]
        [Route("note/add")]
        public async Task<OkResult> AddAsync()
        {
            string body = await new StreamReader(Request.Body, Encoding.UTF8).ReadToEndAsync();
            Note note = new Note() { content = body };
            _notesRepository.Add(note);
            return Ok();
        }
    }
}