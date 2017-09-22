using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Helpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<ExpandoObject> ShapeData<TSource>(
            this IEnumerable<TSource> source, string fields)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            // list to hold our ExpandoObjects
            var expandoObjectList = new List<ExpandoObject>();

            // list of PropertyInfo objects on TSource. Reflection is
            // expansive, so rather than doing it for each object in the list,
            // we do it once and reuse the results. After all, part of the reflection 
            // is on the type of object (TSource), not on the instance
            var propertyInfoList = new List<PropertyInfo>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                // all public properties should be in the ExpandoObject
                var propertyInfos = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                // only the public properties that match the fields should be in the ExpandoObject

                // the field are separated by ",", so we split it.
                string[] fieldsAfterSplit = fields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string field in fieldsAfterSplit)
                {

                }
            }
        }
        
    }
}
