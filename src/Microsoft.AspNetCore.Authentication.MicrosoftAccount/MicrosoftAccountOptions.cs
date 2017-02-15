// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Configuration options for <see cref="MicrosoftAccountMiddleware"/>.
    /// </summary>
    public class MicrosoftAccountOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="MicrosoftAccountOptions"/>.
        /// </summary>
        public MicrosoftAccountOptions()
        {
            AuthenticationScheme = MicrosoftAccountDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-microsoft");
            AuthorizationEndpoint = MicrosoftAccountDefaults.AuthorizationEndpoint;
            TokenEndpoint = MicrosoftAccountDefaults.TokenEndpoint;
            UserInformationEndpoint = MicrosoftAccountDefaults.UserInformationEndpoint;
            Scope.Add("https://graph.microsoft.com/user.read");

            ClaimMaps.AddJsonKeyMap(ClaimTypes.NameIdentifier, "id");
            ClaimMaps.AddJsonKeyMap(ClaimTypes.Name, "displayName");
            ClaimMaps.AddJsonKeyMap(ClaimTypes.GivenName, "givenName");
            ClaimMaps.AddJsonKeyMap(ClaimTypes.Surname, "surname");
            ClaimMaps.AddCustomJsonMap(ClaimTypes.Email, user => user.Value<string>("mail") ?? user.Value<string>("userPrincipalName"));
        }
    }
}
