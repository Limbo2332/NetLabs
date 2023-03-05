﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_Linq_To_Objects
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<Runner>();
        }

        // Transient - при кожному зверненні до сервісу створюється новий об'єкт
        // Scoped - для кожного запросу створюється свій об'єкт
        // Singleton - об'єкт сервіса створюється тільки при першому зверненні
    }
}
