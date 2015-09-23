using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.View;
using Contracts;
using DomainModel.Entities;

namespace Client.Presentor
{
    public class AuthenticationPresenter
    {
        IAuthenticationView authenticationView;
        IContract authenticationContract;
        public AuthenticationPresenter(IAuthenticationView authView, IContract authenticationContract)
        {
            authenticationView = authView;
            this.authenticationContract = authenticationContract;
        }
        public User Authenticate(string login, string password)
        {
            return authenticationContract.GetUser(login, password);
        }
    }
}
