using AutoMapper;
using System.Collections.Generic;

namespace TodoApp.Service.Helpers
{
    internal static class AutoMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            return Mapper.Map<T>(value);
        }

        public static IEnumerable<T> EnumerableTo<T>(this object value)
        {
            return Mapper.Map<IEnumerable<T>>(value);
        }
    }
}
