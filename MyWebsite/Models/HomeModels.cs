using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
    public class LoginRedirectModel
    {
        public bool Redirected { get; set; }

        public LoginRedirectModel(bool redirected)
        {
            Redirected = redirected;
        }

        public LoginRedirectModel()
        {

        }
    }
}