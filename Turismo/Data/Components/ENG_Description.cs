﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Objects;

namespace Turismo.Components
{
    public class ENG_Description : MutipleLanguageString
    {
        public List<string> AudioList { get; set; }
        public string _Description { get; set; }
    }
}
