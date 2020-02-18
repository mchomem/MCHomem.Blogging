using System;
using System.Collections.Generic;
using System.Text;

namespace MCHomem.Blogging.Controllers
{
    interface IController<E>
    {
        void Add(E entity);
        void Refresh(E entity);
        void Remove(E entity);
        E Get(E entity);
        List<E> GetAll(E entity);
    }
}
