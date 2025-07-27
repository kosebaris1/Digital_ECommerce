﻿using D_Domain_Layer.Entities;
using D_Infrastructure_Layer.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace D_Infrastructure_Layer.Extensions
{
   
    public static class HandleTokenValidator
    {
        public static async Task<TokenModel> HandleToken(IList<string> roles, User user, string secretKey)
        {
            TokenModel tokenInstance = new();
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Email),

            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            tokenInstance.Token = tokenHandler.WriteToken(token);
            tokenInstance.Expiration = tokenDescriptor.Expires.Value.ToString("yyyy-MM-dd HH:mm:ss");

            return tokenInstance;
        }
    }
}
