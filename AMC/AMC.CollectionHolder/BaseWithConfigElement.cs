using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC.CollectionHolder
{
    public class BaseWithConfigElement<T> : ConfigurationElementCollection,ICollection<T>
        where T : ConfigurationElement, IKeyedElement, new()
    {
        public string FullName { get; set; }
        public bool Enabled { get; set; }

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                return this.IsReadOnly();
            }
        }
        
        public void Add(T item)
        {
            ////var key = this.GetElementKey(item);
            ////this[key] = item;
        }

        public void Clear()
        {
            this.Clear();
        }

        public bool Contains(T item)
        {
            return this.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.CopyTo(array, arrayIndex);
        }

        public virtual bool Remove(T item)
        {
            return this.Remove(item.Key);
        }

        private bool Remove(object key)
        {
            bool isRemoved = false;

            if (this.BaseGet(key) != null)
            {
                this.BaseRemove(key);
                isRemoved = true;
            }

            return isRemoved;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new List<T>(this).GetEnumerator();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            T keyedElement = element as T;
            return keyedElement.Key;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new List<T>(this).GetEnumerator();
        }
    }
}
