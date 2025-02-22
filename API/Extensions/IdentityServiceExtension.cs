﻿
using API.Helper;
using API.Helper.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services , IConfiguration config)
        {
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters //TokenValidationParameters tell wt do want to validate here
                    {
                        ValidateIssuerSigningKey = true, // if we forget this user send up any old token they want bcz we would never validate that the signing key is correct
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization(config =>
            {
                config.AddPolicy(roles.Pharmacy.ToString(), Policies.PharmacyPolicy());
                config.AddPolicy(roles.Customer.ToString(), Policies.CustomerPolicy());
                config.AddPolicy(roles.DeliveryBoy.ToString(), Policies.DeliveryBoyPolicy());
            });
            return services;
        }

        
}

}