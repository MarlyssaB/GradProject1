using System;
namespace GradProject.Core.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
