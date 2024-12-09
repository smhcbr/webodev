using Microsoft.AspNetCore.Mvc;

namespace kuaforsln.Controllers;

public class UserController:Controller
{
    public string Index()
    {
        return "home/index";
    }

    public string About()
    {
        return "home/about";
            
    }
}