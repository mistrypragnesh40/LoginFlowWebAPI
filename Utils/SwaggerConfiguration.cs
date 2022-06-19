using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Models
{
    public class SwaggerConfiguration
    {
        /// <summary>
        /// <para>Stemmons Mobile API v1</para>
        /// </summary>
        public const string EndpointDescription = "Stemmons Mobile API v1";

        /// <summary>
        /// <para>/swagger/v1/swagger.json</para>
        /// </summary>

#if DEBUG
        // For Debug in IIS Express
        //public const string EndpointUrl = "/swagger/v1/swagger.json";
        public const string EndpointUrl = "/swagger/v1/swagger.json";
#else
        // To deploy on Server IIS
        public const string EndpointUrl = "/MobileAPI/swagger/v1/swagger.json";
#endif

        /// <summary>
        /// <para>v1</para>
        /// </summary>
        public const string DocNameV1 = "v1";

        /// <summary>
        /// <para>Foo API</para>
        /// </summary>
        public const string DocInfoTitle = "Test Web API";

        /// <summary>
        /// <para>v1</para>
        /// </summary>
        public const string DocInfoVersion = "v1";

        /// <summary>
        /// <para>REST API for the Stemmons Central To Go mobile client</para>
        /// </summary>
        public const string DocInfoDescription = "REST API for the Stemmons Central To Go mobile client";

        /// <summary>
        /// <para>JWT Authorization header using the Bearer scheme. Example: "Authorization: Bearer {token}"</para>
        /// </summary>
        public const string SecuritySchemeDescription = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"";

        /// <summary>
        /// <para>Authorization</para>
        /// </summary>
        public const string SecuritySchemeName = "Authorization";

        /// <summary>
        /// <para>Bearer</para>
        /// </summary>
        public const string SecurityScheme = "Bearer";
    }
}
