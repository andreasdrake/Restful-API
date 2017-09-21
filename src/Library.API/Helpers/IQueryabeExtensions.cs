using Library.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Library.API.Helpers
{
    public static class IQueryabeExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy, Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mappingDictionary == null)
            {
                throw new ArgumentNullException(nameof(mappingDictionary));
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            string[] orderByAfterSplt = orderBy.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string orderByClause in orderByAfterSplt)
            {
                string trimmedOrderByClause = orderByClause.Trim();

                bool orderDescending = trimmedOrderByClause.EndsWith(" desc");

                

            }
        }
    }
}
