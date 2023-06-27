using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leagueinator.Model {

    [AttributeUsage(AttributeTargets.Property)]
    public class Model : Attribute {}

    public static class ModelExtensions {
        public static List<T> SeekAll<T>(this object isModel) where T : class {
            List<T> list = new List<T>();
            Type type = isModel.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (PropertyInfo prop in propertyInfos) {
                if (!prop.CanRead) continue;
                if (prop.GetIndexParameters().Length > 0) continue;

                if (typeof(IEnumerable<T>).IsAssignableFrom(prop.PropertyType)) {
                    IEnumerable<T> values = (IEnumerable<T>)prop.GetValue(isModel, null);
                    list.AddRange(values);
                }
                else if (prop.PropertyType == typeof(T)) {
                    T value = (T)prop.GetValue(isModel, null);
                    if (value != null) list.Add(value);
                }
            }

            return list;
        }

        public static List<T> SeekDeep<T>(this object isModel) where T : class {            
            List<T> list = new List<T>();
            Type type = isModel.GetType();

            if (isModel.GetType() == typeof(T)) {
                if (list.Contains(isModel)) return list;
                list.Add((T)isModel);
            }

            foreach (PropertyInfo prop in type.GetProperties()) {
                if (!prop.CanRead) continue;
                if (prop.GetIndexParameters().Length > 0) continue;
                if (prop.GetCustomAttribute<Model>() == null) continue;

                var l = SeekDeepHelper<T>(isModel, prop);
                list.AddRange(l);
            }

            return list;
        }

        static List<T> SeekDeepHelper<T>(this object isModel, PropertyInfo prop) where T : class {
            List<T> list = new List<T>();

            if (typeof(IEnumerable<T>).IsAssignableFrom(prop.PropertyType)) {
                // Enumberable of type - ie List or Array
                IEnumerable<T> values = (IEnumerable<T>)prop.GetValue(isModel, null);
                list.AddRange(values);
            }
            else if (prop.PropertyType == typeof(T)) {
                // Is of exact type
                T value = (T)prop.GetValue(isModel, null);
                if (value != null) list.Add(value);
            }
            else if (prop.PropertyType.GetInterfaces().Contains(typeof(IEnumerable))) {
                // Enumerable of not-type
                var value = (IEnumerable)prop.GetValue(isModel, null);
                if (value != null) foreach (var item in value) {
                    list.AddRange(item.SeekDeep<T>());
                }
            }
            else if (!prop.PropertyType.IsPrimitive) {
                // Some other (non-enumerable) type
                var value = prop.GetValue(isModel, null);
                list.AddRange(value.SeekDeep<T>());
            }

            return list;
        }
    }
}
