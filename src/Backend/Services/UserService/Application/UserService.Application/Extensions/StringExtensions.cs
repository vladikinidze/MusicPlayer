using System.Net.Mail;
using System.Text.Json;

namespace UserService.Application.Extensions;

public static class StringExtensions
{
    public static bool IsEmail(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        try
        {
            var mailAddress = new MailAddress(text);
            return mailAddress.Address == text;
        }
        catch
        {
            return false;
        }
    }

    public static string ToCamelCase(this string text)
    {
        return string.IsNullOrEmpty(text) ? text : JsonNamingPolicy.CamelCase.ConvertName(text);
    }
}