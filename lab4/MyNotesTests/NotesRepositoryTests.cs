using System;
using Xunit;
using MyNotes.Data.Models;
using MyNotes.Data.Repositories;
using System.Collections.Generic;
using System.IO;

namespace MyNotesTests
{
    public class NotesRepositoryTests
    {
        NotesRepository notesRepository;
        string storagePath;
        public NotesRepositoryTests()
        {
            storagePath = System.IO.Path.GetTempPath() + "\\notes.json";
        }
        private void resetStorage()
        {
            if (File.Exists(storagePath))
            {
                File.Delete(storagePath);
            }
            NotesRepository.SetStoragePath(storagePath);
            notesRepository = new NotesRepository();
        }
        [Fact]
        public void TestGetAllFromEmptyStorage()
        {
            resetStorage();
            List<Note> notes = (List<Note>)notesRepository.GetAll();
            Assert.Empty(notes);
        }
        [Fact]
        public void TestAddToEmptyStorage()
        {
            resetStorage();
            string text = "Note #1, погода хороша";
            notesRepository.Add(new Note() { content = text });
            List<Note> notes = (List<Note>)notesRepository.GetAll();
            Assert.Single(notes);
            Assert.Equal(text, notes[0].content);

        }
    }
}
