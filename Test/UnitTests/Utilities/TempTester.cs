using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Utilities
{
    public class TempTester
    {
        [Fact]
        public void Test()
        {
            var testString = "12ed;314ddf；fads33";
            var ret = testString.Split(';').ToList();
            Console.WriteLine("This count is " + ret.Count);
            ret.AddRange(ret);
            Console.WriteLine("This count is " + ret.Count);
            foreach (var item in ret)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Team
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Team(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public static IList<Team> GetTeamList()
        {
            return null;
        }

    }

}
