﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.Domain
{
    public class CarExistingFilePath
    {
        public Guid? Id { get; set; }
        public string FilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}