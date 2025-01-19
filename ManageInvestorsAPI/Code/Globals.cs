namespace ManageInvestors.Code
{
    public static class Globals
    {
        public const string HealthDataAPI = "HealthDataAPI";
        public const string TestEnvironment = "Test";
        public const string ApplicationName = "HealthSync";

        public const string SessionCookieName = ".HealthSync.HSE";

        public const string MyHealthID = "MyHealthID";
        public const string MyHealthSync = "MyHealthSync";
        public const string Cookies = "Cookies";
        public const bool EnableRedisCache = true;
        public const string AppAuthorization = "AppAuthorization";


        public static class ClaimsType
        {
            public const string ApplicationPolicy = "Application";
            public const string RolePolicy = "Role";
            public const string Application = "extension_Application";
            public const string Role = "extension_Role";
        }

        public static class ClaimsValue
        {
            public const string ApplicationName = "HealthSync";
            public static string[] Roles = new string[] { "HealthSync.Admin", "HealthSync.User" };
        }

        public static string DefaultSchema { get; set; } = "App";

    }
}
