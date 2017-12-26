using System;
using System.Collections.Generic;
using System.Text;

namespace Prism700p5Try.Models
{
    public class TNaviParams
    {
        private Dictionary<string, object> _params;

        public TNaviParams()
        {
            _params = new Dictionary<string, object>();
        }


        public void Set<T>(T value) where T : class
        {
            _params[typeof(T).FullName] = value;
        }

        public T Get<T>() where T : class
        {
            var key = typeof(T).FullName;
            if (_params.ContainsKey(key))
            {
                var value = _params[key] as T;
                _params.Remove(key);
                return value;
            }
            else
                throw new NotImplementedException();
        }


        public void Set(string key, object value)
        {
            _params[key] = value;
        }

        public object Get(string key)
        {
            if (_params.ContainsKey(key))
            {
                var value = _params[key];
                _params.Remove(key);
                return value;
            }
            else
                throw new NotImplementedException();
        }
    }
}
