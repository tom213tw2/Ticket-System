using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Comman.Data
{
    public static class ObjectHelper
    {
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
            where T : class
            where TU : class
        {
            List<PropertyInfo> list1 = ((IEnumerable<PropertyInfo>)typeof(T).GetProperties()).Where<PropertyInfo>((Func<PropertyInfo, bool>)(x => x.CanRead)).ToList<PropertyInfo>();
            List<PropertyInfo> list2 = ((IEnumerable<PropertyInfo>)typeof(TU).GetProperties()).Where<PropertyInfo>((Func<PropertyInfo, bool>)(x => x.CanWrite)).ToList<PropertyInfo>();
            foreach (PropertyInfo propertyInfo1 in list1)
            {
                PropertyInfo sourceProp = propertyInfo1;
                if (list2.Any<PropertyInfo>((Func<PropertyInfo, bool>)(x => x.Name == sourceProp.Name)))
                {
                    PropertyInfo propertyInfo2 = list2.First<PropertyInfo>((Func<PropertyInfo, bool>)(x => x.Name == sourceProp.Name));
                    if (propertyInfo2.CanWrite)
                        propertyInfo2.SetValue((object)dest, sourceProp.GetValue((object)source, (object[])null), (object[])null);
                }
            }
        }

        public static IEnumerable<TU> CopyList<T, TU>(this IEnumerable<T> source)
            where T : class
            where TU : class, new()
        {
            foreach (T source1 in source)
            {
                TU u = new TU();
                TU dest = u;
                source1.CopyPropertiesTo<T, TU>(dest);
                yield return u;
            }
        }
    }
}