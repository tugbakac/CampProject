using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        //key imiz mevcut her şeyin base i object olduğu için value object, cache de ne kadar kalacağı kısmı için duration
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }

}
