namespace dotnet_core_graphql_starter.Options
{
    using System.Collections.Generic;

    public class KestrelOptions
    {
        public Dictionary<string, EndpointOptions> Endpoints { get; set; }
    }
}
