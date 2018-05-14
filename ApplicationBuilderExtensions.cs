namespace dotnet_core_graphql_starter
{
	using System;
	using System.Linq;
	using Boxed.AspNetCore;
	using Microsoft.AspNetCore.Builder;
	using dotnet_core_graphql_starter.Constants;
	using dotnet_core_graphql_starter.Options;
	using Microsoft.Extensions.DependencyInjection;

	public static partial class ApplicationBuilderExtensions
	{
		/// <summary>
		/// Adds developer friendly error pages for the application which contain extra debug and exception information.
		/// Note: It is unsafe to use this in production.
		/// </summary>
		public static IApplicationBuilder UseDeveloperErrorPages(this IApplicationBuilder application) =>
				application
						// When a database error occurs, displays a detailed error page with full diagnostic information. It is
						// unsafe to use this in production. Uncomment this if using a database.
						// .UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
						// When an error occurs, displays a detailed error page with full diagnostic information.
						// See http://docs.asp.net/en/latest/fundamentals/diagnostics.html
						.UseDeveloperExceptionPage();

		/// <summary>
		/// Uses the static files middleware to serve static files. Also adds the Cache-Control and Pragma HTTP
		/// headers. The cache duration is controlled from configuration.
		/// See http://andrewlock.net/adding-cache-control-headers-to-static-files-in-asp-net-core/.
		/// </summary>
		public static IApplicationBuilder UseStaticFilesWithCacheControl(this IApplicationBuilder application)
		{
			var cacheProfile = application
					.ApplicationServices
					.GetRequiredService<CacheProfileOptions>()
					.First(x => string.Equals(x.Key, CacheProfileName.StaticFiles, StringComparison.Ordinal))
					.Value;
			return application
					.UseStaticFiles(
							new StaticFileOptions()
							{
								OnPrepareResponse = context =>
											{
										context.Context.ApplyCacheProfile(cacheProfile);
									}
							});
		}

		/// <summary>
		/// Adds the Strict-Transport-Security HTTP header to responses. This HTTP header is only relevant if you are
		/// using TLS. It ensures that content is loaded over HTTPS and refuses to connect in case of certificate
		/// errors and warnings.
		/// See https://developer.mozilla.org/en-US/docs/Web/Security/HTTP_strict_transport_security and
		/// http://www.troyhunt.com/2015/06/understanding-http-strict-transport.html
		/// Note: Including subdomains and a minimum maxage of 18 weeks is required for preloading.
		/// Note: You can refer to the following article to clear the HSTS cache in your browser:
		/// http://classically.me/blogs/how-clear-hsts-settings-major-browsers
		/// </summary>
		public static IApplicationBuilder UseStrictTransportSecurityHttpHeader(this IApplicationBuilder application) =>
				application.UseHsts(options => options.MaxAge(days: 18 * 7).IncludeSubdomains().Preload());
	}
}
