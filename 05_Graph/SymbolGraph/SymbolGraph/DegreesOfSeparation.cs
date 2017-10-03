using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolGraphExample
{
    class DegreesOfSeparation
    {
        String filepath { get; set; }
        char delimiter { get; set; }
        String source { get; set; }
        SymbolGraph sg;
        Graph G;


        public DegreesOfSeparation(string afilename, char adelimiter, string asource)
        {
            filepath = afilename;
            delimiter = adelimiter;
            source = asource;
            sg = new SymbolGraph(filepath, delimiter);
            G = sg.getGraph();

        }

        public void Execute()
        {
            if (!sg.contains(source))
            {
                Console.WriteLine(source + " not in database.");
                return;
            }
            int s = sg.indexOf(source);
            BreadthFirstPaths bfs = new BreadthFirstPaths(G, s);

            using (StreamReader sr = new StreamReader(filepath))
            {
                Queue<string> alreadyProcessed = new Queue<string>();
                while (sr.Peek() >= 0)
                {
                    String sink = sr.ReadLine();
                    String[] substrings = sink.Split(delimiter);
                   
                    foreach (string substring in substrings)
                    {
                        if (sg.contains(substring))
                        {
                            int t = sg.indexOf(substring);
                            if (bfs.hasPathTo(t)&&(substring!=source)&&(!alreadyProcessed.Contains(substring)))
                            {
                                Console.WriteLine("");
                                Console.Write("path to "+substring+" : ");
                                alreadyProcessed.Enqueue(substring);
                                foreach (int v in bfs.pathTo(t))
                                {
                                    Console.Write("   " + sg.nameOf(v));
                                }
                            }
                        }

                    }
                }
            }
        }

    }
}
