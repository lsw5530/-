﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephCircular
{
    class Node
    {
        public object data;
        public Node next;
        public Node(object value) {
            data = value;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
