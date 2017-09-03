Custom Implementation

IPrincipal[Interface] and IIdentity [user's permission] specifications
=======================================================================
'IPrincipal' is a .Net framework's interface:

public interface IPrincipal {
    // Retrieve the identity object
    IIdentity Identity { get; }

    // Perform a check for a specific role
    bool IsInRole (string role);
}
This interface defines the basic functionality of logged in user. 
Object implementing this interface represents the security context under which your code is running. 
You can get different flavors of IPrincipal in .Net: ClaimsPrincipal, WindowsPrincipal and others - all depends on the framework you are using. 
If you are working with Asp.Net Identity framework, you'll be dealing with ClaimsPrincipal. Usually you don't need to implement this interface.

IIdentity represents user's permissions. For Asp.Net Identity framework you'll be dealing with ClaimsIdentity. Again, this is something you don't need to implement.

->At last the default ASP.NET Identity module Owin based authentication need to be removed/disabled 
->By removing Idnetity config,Startup.authconfig ,Startup.cs and in Web.config file
->Also disable Owin startup class in web.config  <add key="owin:AutomaticAppStartup" value="false" />    <!--added by me-->
