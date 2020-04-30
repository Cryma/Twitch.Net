﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twitch.Net.Interfaces
{
    interface IAccessTokenStrategy
    {

        Task<string> GetAccessToken();

    }
}
