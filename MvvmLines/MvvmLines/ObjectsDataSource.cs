using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLines
{
    public static class ObjectsDataSource
    {
        private static Random r = new Random();

        public static IEnumerable<Node> GetRandomNodes(int numberOfNodes)
        {
            return Enumerable.Range(0, numberOfNodes).Select(x => GetRandomNode());
        }

        private static Node GetRandomNode()
        {
            return new Node()
            {
                Name = "Node" + r.Next(0, 100),
                X = r.Next(0, 500),
                Y = r.Next(0, 500)
            };
        }

        public static IEnumerable<Line> GetRandomLines(IEnumerable<Node> nodes)
        {
            var lines = new List<Line>();

            for (int i = 0; i < nodes.Count() - 1; i++)
            {
                lines.Add(new Line()
                {
                    Start = nodes.ElementAt(i),
                    End = nodes.ElementAt(i+1),
                    Name = "Line" + r.Next(0, 100)
                });
            }

            return lines;
        }
    }
}
