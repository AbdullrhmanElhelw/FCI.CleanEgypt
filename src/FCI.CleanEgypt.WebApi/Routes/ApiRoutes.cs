namespace FCI.CleanEgypt.WebApi.Routes;

public static class ApiRoutes
{
    public static class Users
    {
        public const string Base = "api/users";
        public const string Register = "register";
        public const string Login = "login";
    }

    public static class Admin
    {
        public const string Base = "api/admins";
        public const string Create = "create";
        public const string Login = "login";
    }

    public static class Events
    {
        public const string Base = "api/events";
        public const string Create = "create";
        public const string Update = "update/{eventId:guid}";
        public const string GetAll = "get-all/{pageNumber:int}/{pageSize:int}";
        public const string GetById = "get-event/{eventId:guid}";
    }
}