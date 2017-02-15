// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    public class ClaimResolverCollection<T> : IEnumerable<ClaimResolver<T>>
    {
        private IList<ClaimResolver<T>> Maps { get; } = new List<ClaimResolver<T>>();

        public void Clear() => Maps.Clear();

        public void Remove(string claimName)
        {
            var itemsToRemove = Maps.Where(map => string.Equals(claimName, map.ClaimName, StringComparison.OrdinalIgnoreCase)).ToList();
            itemsToRemove.ForEach(map => Maps.Remove(map));
        }

        public void Add(ClaimResolver<T> resolver)
        {
            Maps.Add(resolver);
        }

        public IEnumerator<ClaimResolver<T>> GetEnumerator()
        {
            return Maps.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Maps.GetEnumerator();
        }
    }
}