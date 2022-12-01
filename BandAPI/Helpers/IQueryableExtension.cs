using BandAPI.Services;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace BandAPI.Helpers
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy,
            Dictionary<string, PropertyMapingValue> mappingDitionary)
        {
            var orderByString = "";

            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (mappingDitionary == null)
                throw new ArgumentException(nameof(mappingDitionary));
            if (string.IsNullOrWhiteSpace(orderBy))
                return source;
            var orderBySplit = orderBy.Split(",");

            foreach(var orderByClause in orderBySplit)
            {
                var trimmedOrderBy = orderByClause.Trim();
                var orderDesc = trimmedOrderBy.EndsWith(" desc");
                var indexOfSpace = trimmedOrderBy.IndexOf(" ");
                var propertyName = indexOfSpace == -1 ? trimmedOrderBy : 
                    trimmedOrderBy.Remove(indexOfSpace);
                if (!mappingDitionary.ContainsKey(propertyName))
                    throw new ArgumentException("Mapping doesn't exists for " + propertyName);

                var propertyMappingValue = mappingDitionary[propertyName];
                if (propertyMappingValue == null)
                    throw new ArgumentNullException(nameof(propertyMappingValue));
                foreach(var destination in propertyMappingValue.DestinationProperties.Reverse())
                {
                    if (propertyMappingValue.Revert)
                        orderDesc = !orderDesc;
                    
                    orderByString = orderByString + (!string.IsNullOrWhiteSpace(orderByString) ? "," : "") + destination + 
                        (orderDesc ? " descending" : " ascending");
                }
            }
            return source.OrderBy(orderByString);
        }
    }
}
