using GradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradProject.Services
{
    public interface IEntryRepository
    {
        Entry Add(Entry Entry);
        Entry Update(Entry Entry);
        Entry Get(int id);
        IEnumerable<Entry> GetAll();
        void Remove(int id);
        IEnumerable<Entry> GetProfileEntries(int ProfileId);
    }
}
