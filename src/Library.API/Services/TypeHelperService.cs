using System;
using System.Reflection;

namespace Library.API.Services
{
    public class TypeHelperService : ITypeHelperService
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            string[] fieldsAfterSplit = fields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string field in fieldsAfterSplit)
            {
                string propertyName = field.Trim();

                PropertyInfo propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo == null)
                {
                    return false;
                }
            }


            return true;
        }
    }
}
