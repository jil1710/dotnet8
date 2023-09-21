using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
        [AttributeUsage(AttributeTargets.Method,AllowMultiple =true)]
        internal sealed class InterceptsLocationAttribute : Attribute
        {
            public InterceptsLocationAttribute(string filePath,int line,int col)
            {
        
            }
        }
    
}
