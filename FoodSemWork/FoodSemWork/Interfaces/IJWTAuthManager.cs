using FoodSemWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Interfaces
{
    public interface IJWTAuthManager
    {
        string Authenticate(User user);
    }

}
