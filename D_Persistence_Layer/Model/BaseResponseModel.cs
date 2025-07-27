﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Model
{
    public class BaseResponseModel
    {
        public bool Success { get; set; }
        public dynamic Message { get; set; }
        public dynamic Exception { get; set; }
        public object Result { get; set; }
    }
}
