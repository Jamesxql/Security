// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    public static class JsonClaimResolverCollectionExtensions
    {
        public static void Add(this ClaimResolverCollection<JObject> collection, string claimName, string jsonKey)
        {
            collection.Add(claimName, jsonKey, ClaimValueTypes.String);
        }

        public static void Add(this ClaimResolverCollection<JObject> collection, string claimName, string jsonKey, string claimType)
        {
            collection.Add(new JsonClaimResolver(claimName, claimType, jsonKey));
        }

        public static void AddNested(this ClaimResolverCollection<JObject> collection, string claimName, string jsonKey, string subKey)
        {
            collection.AddNested(claimName, jsonKey, subKey, ClaimValueTypes.String);
        }

        public static void AddNested(this ClaimResolverCollection<JObject> collection, string claimName, string jsonKey, string subKey, string claimType)
        {
            collection.Add(new NestedJsonClaimResolver(claimName, claimType, jsonKey, subKey));
        }

        public static void AddCustom(this ClaimResolverCollection<JObject> collection, string claimName, Func<JObject, string> resolver)
        {
            collection.AddCustom(claimName, ClaimValueTypes.String, resolver);
        }

        public static void AddCustom(this ClaimResolverCollection<JObject> collection, string claimName, string claimType, Func<JObject, string> resolver)
        {
            collection.Add(new CustomJsonClaimResolver(claimName, claimType, resolver));
        }
    }
}
