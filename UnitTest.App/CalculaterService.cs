﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.App
{
    public class CalculaterService : ICalculaterService
    {
        public int add(int a, int b)
        {
            return 0;

        }
        public int Mul(int a, int b) 
        { 
            if(a == 0)
            {
                throw new Exception("a=0 olamaz");
            }
            return a*b; 
        }
        //{
        //     if (a == 0 || b == 0)
        //        {
        //            return 0;
        //        }
        //        return a + b;

        //}


    }
}
