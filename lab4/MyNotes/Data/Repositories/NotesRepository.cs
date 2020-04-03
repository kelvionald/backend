using MyNotes.Data.Interfaces;
using MyNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyNotes.Data.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private static string storagePath;
        private static List<Note> notesArray;
        public static void SetStoragePath(string path)
        {
            NotesRepository.storagePath = path;
            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("[]");
                sw.Close();
            }
            notesArray = new List<Note>();
            notesArray = new NotesRepository().GetAll().ToList<Note>();
        }
        public IEnumerable<Note> GetAll()
        {
            List<Note> notes;
            using (StreamReader sr = new StreamReader(storagePath))
            {
                string data = sr.ReadToEnd();
                notes = JsonSerializer.Deserialize<List<Note>>(data);

            }
            return notes;
        }
        public void Add(Note note)
        {
            notesArray.Add(note);
            using (StreamWriter fs = new StreamWriter(storagePath))
            {
                string json = JsonSerializer.Serialize<List<Note>>(notesArray);
                fs.Write(json);
            }
        }
    }
}
