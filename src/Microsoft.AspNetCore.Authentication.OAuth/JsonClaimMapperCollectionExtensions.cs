// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    public static class JsonClaimMapperCollectionExtensions
    {
        public static void AddJsonKeyMap(this ClaimMapperCollection<JObject> collection, string claimName, string jsonKey)
        {
            collection.AddJsonKeyMap(claimName, jsonKey, ClaimValueTypes.String);
        }

        public static void AddJsonKeyMap(this ClaimMapperCollection<JObject> collection, string claimName, string jsonKey, string claimType)
        {
            collection.Add(new JsonClaimMapper(claimName, claimType, jsonKey));
        }

        public static void AddNestedJsonKeyMap(this ClaimMapperCollection<JObject> collection, string claimName, string jsonKey, string subKey)
        {
            collection.AddNestedJsonKeyMap(claimName, jsonKey, subKey, ClaimValueTypes.String);
        }

        public static void AddNestedJsonKeyMap(this ClaimMapperCollection<JObject> collection, string claimName, string jsonKey, string subKey, string claimType)
        {
            collection.Add(new NestedJsonClaimMapper(claimName, claimType, jsonKey, subKey));
        }

        public static void AddCustomJsonMap(this ClaimMapperCollection<JObject> collection, string claimName, Func<JObject, string> resolver)
        {
            collection.AddCustomJsonMap(claimName, ClaimValueTypes.String, resolver);
        }

        public static void AddCustomJsonMap(this ClaimMapperCollection<JObject> collection, string claimName, string claimType, Func<JObject, string> resolver)
        {
            collection.Add(new CustomJsonClaimMapper(claimName, claimType, resolver));
        }
    }
}
