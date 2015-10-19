using System;
using System.Net;

namespace Glimpse.Server.Resources
{
    public class MissingParameterProblem : Problem
    {
        private readonly string _parameterName;
        public MissingParameterProblem(string parameterName)
        {
            _parameterName = parameterName;
        }

        public override Uri Type => new Uri("http://getglimpse.com/Docs/Troubleshooting/MissingParameter");

        public override string Title => "Missing Required Parameter";

        public override string Details => $"Required parameter '{_parameterName}' is missing.";

        public override int StatusCode => (int) HttpStatusCode.NotFound;
    }
}