using System;
using System.Collections;
using System.Collections.Generic;

namespace BandAPI.Services
{
    public class PropertyMapingValue
    {
        public IEnumerable<string> DestinationProperties { get; set; }
        public bool Revert { get; set; }
        public PropertyMapingValue(IEnumerable<string> destinationProperties, bool revert = false)
        {
            DestinationProperties= destinationProperties ?? throw new ArgumentException(nameof(destinationProperties));
            Revert = revert;
        }
    }
}
