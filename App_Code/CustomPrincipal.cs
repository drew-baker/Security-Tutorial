﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

/// <summary>
/// Summary description for CustomPrincipal
/// </summary>
public class CustomPrincipal : System.Security.Principal.IPrincipal
{
    private CustomIdentity _identity;

    public CustomPrincipal(CustomIdentity identity)
    {
        _identity = identity;
    }

    public System.Security.Principal.IIdentity Identity
    {
        get { return _identity; }
    }

    public bool IsInRole(string role)
    {
        return false;
    }
}