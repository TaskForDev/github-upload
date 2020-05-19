using System;
using System.Collections.Generic;
using System.Text;

namespace V8Features
{
    public interface IOperation<T> where T : class //Regular Interface
    {
        List<T> GetAll();
        void Add(T obj);
        void remove(T obj);
        T GetByID(int obj);
        T SetProperty(int obj);
    }
}
