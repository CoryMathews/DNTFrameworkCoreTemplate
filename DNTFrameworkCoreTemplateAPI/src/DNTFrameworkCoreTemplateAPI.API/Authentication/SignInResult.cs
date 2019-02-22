using System;

namespace DNTFrameworkCoreTemplateAPI.API.Authentication
{
    public class SignInResult
    {
        private Token _token;
        public static SignInResult Success(Token token) => new SignInResult {Succeeded = true, _token = token};
        public static SignInResult Failed(string message) => new SignInResult {Succeeded = false, Message = message};

        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public Token Token => Succeeded ? _token : throw new InvalidOperationException();
    }
}