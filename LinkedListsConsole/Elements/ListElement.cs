using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LinkedListsConsole.Elements
{
   
    public class ListElement<T>
    {
        private ListElement<T> _next;
        private T _value;       
       
        public ListElement(T value )
        {
            _value = value;
        }
        public ListElement(T value, ListElement<T> next) : this(value)
        {
            _next = next;
        }
        public T Value => _value;

        public ListElement<T> Next => _next;

        public void SetNext(ListElement<T> listElement)
            => _next = listElement;
        
        public void SetValue(T t)
            =>  _value = t;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            
            builder.AppendLine($"ElementValue: {Value} {Environment.NewLine} NextElement: { (Next == null ? "empty" : Next.ToString()) }");           

            return builder.ToString();
        }
        
    }
}
