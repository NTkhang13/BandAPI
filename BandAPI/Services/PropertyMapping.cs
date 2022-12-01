using System;
using System.Collections.Generic;

namespace BandAPI.Services
{
    public class PropertyMapping<Tsource, TDestination> : IPropertyMappingMarker
    {
        public Dictionary<string, PropertyMapingValue> MappingDictionary { get; set; }
        public PropertyMapping(Dictionary<string, PropertyMapingValue> mappingDictionary)
        {
            MappingDictionary = mappingDictionary ?? throw new ArgumentNullException(nameof(mappingDictionary));
        }
        
    }
}
