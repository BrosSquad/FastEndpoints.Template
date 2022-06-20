using System.Net;
using System.Net.Http.Json;

using Microsoft.Net.Http.Headers;

namespace TemplateFastEndpoints.API.E2E.Tests.Extensions;

internal static class HttpResponseMessageExtensions
{
    public static string ExtractCookie(this HttpResponseMessage response, string cookieName)
    {
        var cookies = response.Headers.GetValues(HeaderNames.SetCookie);

        foreach (var cookie in cookies)
        {
            if (cookie.Contains(cookieName))
            {
                return cookie;
            }
        }

        return string.Empty;
    }

    public static async Task<(HttpStatusCode statusCode, T data)> Extract<T>(this HttpResponseMessage response)
    {
        var body = await response.Content.ReadFromJsonAsync<T>();

        return (response.StatusCode, body)!;
    }
}
