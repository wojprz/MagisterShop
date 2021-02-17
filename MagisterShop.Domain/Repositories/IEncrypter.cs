﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Domain.Repositories
{
    public interface IEncrypter
    {
        string GetSalt(string values);
        string GetHash(string value, string salt);
    }
}
