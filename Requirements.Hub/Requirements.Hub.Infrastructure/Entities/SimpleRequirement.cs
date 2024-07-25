﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Infrastructure.Entities
{
    public class SimpleRequirement
    {
        public Guid Id { get; set; } = new Guid();
        public string Description { get; set; } = string.Empty;
        public string Funcionality { get; set; } = string.Empty;
        public string Project { get; set; }
    }
}