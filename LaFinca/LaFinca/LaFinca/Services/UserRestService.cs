using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LaFinca.Services
{
    class UserRestService
    {
        protected HttpClient client;

        public UserRestService()
        {
            client = new HttpClient(GetInsercureHandler());
        }

        public HttpClientHandler GetInsercureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

    }
}
