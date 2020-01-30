using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeBlocks.Web.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToQueryString(this object obj, string baseUrl = null)
        {
            var queryString = (string.IsNullOrWhiteSpace(baseUrl)) ? "" : baseUrl;

            Type objType = obj.GetType();

            List<KeyValuePair<PropertyInfo, string>> props = objType.GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(QueryStringParameterAttribute)))
                .Select(p => new KeyValuePair<PropertyInfo, string>(p, GetQueryStringParameterName(p)))
                .ToList();

            foreach (var prop in props)
            {
                string name = (!string.IsNullOrWhiteSpace(prop.Value)) ? prop.Value : prop.Key.Name;
                var value = prop.Key.GetValue(obj);

                if (value != null)
                {
                    var valueText = value.ToString();

                    // TODO: Understand the impact of doing localization assumptions here...
                    //       How do we know the culture of the entity that's gonna deserialize this query string parameter...

                    //if (prop.Key.PropertyType == typeof(float) ||
                    //    prop.Key.PropertyType == typeof(float?))
                    //{
                    //    if (!string.IsNullOrEmpty(valueText) && valueText.Contains(","))
                    //    {
                    //        valueText = valueText.Replace(",", ".");
                    //    }
                    //}

                    queryString = QueryHelpers.AddQueryString(queryString, name, valueText);
                }
            }

            return queryString;
        }



        private static string GetQueryStringParameterName(PropertyInfo property)
        {
            var attrs = property.GetCustomAttributes();
            foreach (object attr in attrs)
            {
                if (attr is QueryStringParameterAttribute authAttr)
                {
                    return authAttr.Name;
                }
            }
            return null;
        }
    }
}
