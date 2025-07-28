using System;
using System.Text;

public static class BasicAuthValidator
{
    private const string AdminUser = "admin";
    private const string AdminPass = "password";

    public static bool IsAuthorized(string authHeader)
    {
        if (string.IsNullOrWhiteSpace(authHeader))
            return false;

        if (!authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            return false;

        var encoded = authHeader["Basic ".Length..].Trim();
        string decoded;
        try
        {
            var bytes = Convert.FromBase64String(encoded);
            decoded = Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            return false;
        }

        var parts = decoded.Split(':');
        if (parts.Length != 2)
            return false;

        return parts[0] == AdminUser && parts[1] == AdminPass;
    }
}
