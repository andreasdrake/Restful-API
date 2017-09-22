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

            string[] orderByAfterSplit = orderBy.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string orderByClause in orderByAfterSplit.Reverse())
            {
                string trimmedOrderByClause = orderByClause.Trim();

                bool orderDescending = trimmedOrderByClause.EndsWith(" desc");

                int indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ");

                string propertyName = indexOfFirstSpace == -1 ? trimmedOrderByClause : trimmedOrderByClause.Remove(indexOfFirstSpace);

                if (!mappingDictionary.ContainsKey(propertyName))
                {
                    throw new Exception($"Key mapping for {propertyName} is missing.");
                }

                PropertyMappingValue propertyMappingValue = mappingDictionary[propertyName];

                if (propertyMappingValue == null)
                {
                    throw new ArgumentNullException(nameof(propertyMappingValue));
                }

                foreach (string destinationProperty in propertyMappingValue.DestinationProperties.Reverse())
                {
                    if (propertyMappingValue.Revert)
                    {
                        orderDescending = !orderDescending;
                    }

                    source = source.OrderBy(destinationProperty + (orderDescending ? " descending" : " ascending"));
                }
            }

            return source;
        }
    }
}
