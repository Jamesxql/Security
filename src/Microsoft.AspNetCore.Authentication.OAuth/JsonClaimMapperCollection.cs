// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    /// <summary>
    /// A collection of JsonClaimMapper used when mapping user data to Claims.
    /// </summary>
    public class JsonClaimMapperCollection : IEnumerable<JsonClaimMapper>
    {
        private IList<JsonClaimMapper> Mappers { get; } = new List<JsonClaimMapper>();

        /// <summary>
        /// Remove all claim mappers.
        /// </summary>
        public void Clear() => Mappers.Clear();

        /// <summary>
        /// Remove all claim mappers for the given ClaimType.
        /// </summary>
        /// <param name="claimType">The ClaimType of maps to remove.</param>
        public void Remove(string claimType)
        {
            var itemsToRemove = Mappers.Where(map => string.Equals(claimType, map.ClaimType, StringComparison.OrdinalIgnoreCase)).ToList();
            itemsToRemove.ForEach(map => Mappers.Remove(map));
        }

        /// <summary>
        /// Add a claim mapper to the collection.
        /// </summary>
        /// <param name="mapper">The claim mapper to add.</param>
        public void Add(JsonClaimMapper mapper)
        {
            Mappers.Add(mapper);
        }

        public IEnumerator<JsonClaimMapper> GetEnumerator()
        {
            return Mappers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Mappers.GetEnumerator();
        }
    }
}