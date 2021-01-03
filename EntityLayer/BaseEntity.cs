﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
