using System;
using System.Collections.Generic;
using BCrypt.Net;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using project.Entities;

namespace project.Services
{
    class EmployeeServicesImpl : IEmployeeServices
    {
        private readonly EmployeeResposity employeeResposity;
        public EmployeeServicesImpl()
        {
            employeeResposity = new EmployeeResposity();
        }
        private readonly string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        public bool comparePassword(string password, string hash)
        {
            bool validPassword = BCrypt.Net.BCrypt.Verify(password, hash);
            return validPassword;
        }

        public string createToken(Employee emp)
        {
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();

            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
            var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds) + 172800;// hardcode 2 day token living


            var payload = new Dictionary<string, object>
                {
                    { "userName", emp.username },
                    { "userId", emp.id },
                    {"exp", secondsSinceEpoch}
                };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);
            return token;
        }

        public string hashPassword(string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, SaltRevision.Revision2A);
            return hashedPassword;
        }

        public Token parseToken(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var json = decoder.Decode(token, secret, verify: true);
                var userInfo = JsonConvert.DeserializeObject<Token>(json);
                return userInfo;
            }
            catch (TokenExpiredException)
            {
                throw new Exception("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                throw new Exception("Token has invalid signature");
            }

        }
        public string login(Login userInfo)
        {
            // get user by email 
            var userInfoByEmail = employeeResposity.GetByUserName(userInfo.username);
            if (userInfoByEmail != null)
            {
                // if username exist check password
                bool isSame = comparePassword(userInfo.password, userInfoByEmail.password);
                if (isSame)
                {
                    return createToken(userInfoByEmail);
                }
                else
                {
                    throw new System.Exception("password not valid");

                }
            }
            throw new System.Exception("User not found");
        }
        public Employee getUserInfoByToken(string token)
        {
            // get user info from token
            var Token = parseToken(token);
            // get user info from database by userId
            var fullUserInfo = employeeResposity.GetByID(Token.userId);
            if (fullUserInfo != null)
            {
                // delete password for security reason
                fullUserInfo.password = "";
                return fullUserInfo;
            }
            else
            {
                throw new Exception("User is not exist!");
            }
        }

        public void changePassword(NewPassword pass)
        {
            // get current user with old password and username
            var userInfoByEmail = employeeResposity.GetByUserName(pass.username);
            if (userInfoByEmail != null)
            {
                // if username exist check password
                bool isSame = comparePassword(pass.password, userInfoByEmail.password);
                if (isSame)
                {
                    // replace password with new password
                    userInfoByEmail.password = hashPassword(pass.newPassword);
                    //update with new password
                    employeeResposity.Update(userInfoByEmail);
                }
                else
                {
                    throw new System.Exception("password not valid");

                }
            }
            else
            {
                throw new System.Exception("User not found");

            }
        }
    }
}
