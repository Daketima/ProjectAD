﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1
{
    public static class ApiRoute
    {
        private const string Root = "api";
        private const string Version1 = "v1";
        private const string Base = Root + "/" + Version1;

        public static class Artisan
        {
            public const string GetAll = Base + "/artisan";
            public const string Get = Base + "/artisan/{id}";
            public const string Create = Base + "/artisan";
            public const string Update = Base + "/artisan/{id}";
            public const string Delete = Base + "/artisan/{id}";
        }

        public static class Order
        {
            public const string GetAll = Base + "/Order";
            public const string Get = Base + "/Order/{id}";
            public const string Create = Base + "/Order";
            public const string Update = Base + "/Order/{id}";
            public const string Delete = Base + "/Order/{id}";
        }

        public static class Rating
        {
            public const string GetAll = Base + "/Rating";
            public const string Get = Base + "/Rating/{id}";
            public const string Create = Base + "/Rating";
            public const string Update = Base + "/Rating/{id}";
            public const string Delete = Base + "/Rating/{id}";
        }

        public static class Client
        {
            public const string GetAll = Base + "/Client";
            public const string Get = Base + "/Client/{id}";
            public const string Create = Base + "/Client";
            public const string Update = Base + "/Client/{id}";
            public const string Delete = Base + "/Client/{id}";
        }

    }
}