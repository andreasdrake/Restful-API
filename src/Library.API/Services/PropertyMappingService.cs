using Library.API.Entities;
using Library.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Services
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private Dictionary<string, PropertyMappingValue> _authorPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new PropertyMappingValue(new List<string>() { "Id" }) },
                { "Genre", new PropertyMappingValue(new List<string>() { "Genre" }) },
                { "Age", new PropertyMappingValue(new List<string>() { "DateOfBirth"}, true) },
                { "Name", new PropertyMappingValue(new List<string>() { "FirstName", "LastName" }) },
            };

        private IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<AuthorDto, Author>(_authorPropertyMapping));
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var mathingMapping = _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();
            if (mathingMapping.Any())
            {
                return mathingMapping.First()._mappingDictionary;
            }

            throw new Exception($"Cannot find exact property mapping for <{typeof(TSource)}, {typeof(TDestination)}>.");
        }
    }
}
