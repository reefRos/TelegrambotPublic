﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBot.Common.Interfaces
{
    public interface IJsonFileReader
    {
        string ReadAllText(string filePath);
    }
}
