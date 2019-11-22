using GradProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradProject.Services
{
    public interface IShowRepository
    {
        Show Add(Show newShow);
        Show Update(Show Show);
        Show Get(int Id);
        IEnumerable<Show> GetAll();
        void Remove(int id);
        IEnumerable<Show> GetShows(int ShowId);
    }
}
