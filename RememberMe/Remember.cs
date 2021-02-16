using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace RememberMe
{
    public static class Remember
    {
        // all remember clear
        public static void ClearEverything()
        {
            AppSettings.Clear();
        }

        private static ISettings AppSettings => CrossSettings.Current;


        private const string UsernameKey = "Username";
        private static readonly string UsernameDefault = string.Empty;
        public static string Username
        {
            get => AppSettings.GetValueOrDefault(UsernameKey, UsernameDefault);
            set => AppSettings.AddOrUpdateValue(UsernameKey, value);
        }

        private const string PasswordKey = "Password";
        private static readonly string PasswordDefault = string.Empty;

        public static string Password
        {
            get => AppSettings.GetValueOrDefault(PasswordKey, PasswordDefault);
            set => AppSettings.AddOrUpdateValue(PasswordKey, value);
        }

        private const string RememberMe = "RememberMe";
        private static readonly string RememberMeDefault = "false";

        public static string GetRememberMe
        {
            get => AppSettings.GetValueOrDefault(RememberMe, RememberMeDefault);
            set => AppSettings.AddOrUpdateValue(RememberMe, value);
        }
    }
}

