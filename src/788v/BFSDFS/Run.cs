

namespace BFSDFS {
    public class App {
        public static void Run() {
            Console.Write("Running BFSDFS ... \n");
            
            Dictionary<string, Node> graph = Graph.readJson();
            List<string> path = Graph.BFS("A", "K", graph);

            foreach (string node in path) {
                Console.Write(node + " ");
            }
            Console.Write("\n");
            
            Console.Write("Done BFSDFS.\n");
        }
    }
}