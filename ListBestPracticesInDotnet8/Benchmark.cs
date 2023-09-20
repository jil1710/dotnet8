using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBestPracticesInDotnet8
{
    [MemoryDiagnoser(false)]
    public class Benchmark
    {
        // Here is the good practice instead of returing null see the bellow output image 

        [Benchmark]
        public IReadOnlyList<User> ReadOnlyList_New()
        {
            return ReadOnlyCollection<User>.Empty;  
        }
        
        [Benchmark]
        public IReadOnlyList<User> ReadOnlyList_Old()
        {
            return new List<User>(0);  
        }
        
        [Benchmark]
        public IReadOnlyCollection<User> ReadOnlyCollection_New()
        {
            return ReadOnlyCollection<User>.Empty;  
        }
        
        [Benchmark]
        public IReadOnlyCollection<User> ReadOnlyCollection_Old()
        {
            return new Collection<User>();  
        }
        
        [Benchmark]
        public IReadOnlyDictionary<int,User> ReadOnlyDictionary_New()
        {
            return ReadOnlyDictionary<int,User>.Empty;  
        }
        
        [Benchmark]
        public IReadOnlyDictionary<int,User> ReadOnlyDictionary_Old()
        {
            return new Dictionary<int,User>();  
        }
    }
}
