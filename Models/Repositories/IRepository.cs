using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_5_Upload.Models.Repositories
{
    internal interface IRepository<T>
    {
        bool Create(T item);
        bool Update(T item);
        bool Delete(T item);
        HashSet<T> GetAll();
        HashSet<T> FindAll(object keyword);
        T Find(object id);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    }
}
