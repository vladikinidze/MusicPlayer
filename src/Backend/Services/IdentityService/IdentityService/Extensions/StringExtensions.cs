using System.Net.Mail;

namespace IdentityService.Extensions;

public static class StringExtensions
{
    public static bool IsEmail(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

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
}