using GradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradProject.Services
{
    public interface IEntryService
    {
        Entry Add(Entry newEntry);
        Entry Update(Entry updatedEntry);
        Entry Get(int id);
        IEnumerable<Entry> GetAll();
        IEnumerable<Entry> GetProfileEntries(int profileId);
        void Remove(int id);

    }
}
