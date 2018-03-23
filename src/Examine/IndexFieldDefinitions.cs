﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Examine
{
    /// <summary>
    /// Defines the mappings between a field name and it's index type
    /// </summary>
    public class IndexFieldDefinitions : ConcurrentDictionary<string, IReadOnlyList<IIndexField>>
    {
        public IndexFieldDefinitions(IEnumerable<IIndexField> allFields)
        {
            foreach (var f in allFields.GroupBy(x => x.Name))
            {
                TryAdd(f.Key, f.ToList());
            }
        }
        
    }
}