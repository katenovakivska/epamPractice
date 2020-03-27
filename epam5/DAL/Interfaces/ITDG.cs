using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITDG<T> where T : class
    {
        void Add(T Data);
        void Update(T Data);
        void Delete(T Data);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
