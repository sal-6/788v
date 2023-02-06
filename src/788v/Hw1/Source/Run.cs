
namespace Hw1 {
    public class App {
        public static void Run() {
            Console.Write("Running Hw1 ... \n");
            
            const string problem = "5";

            // create a string with a format
            string node_path = ".\\data\\Hw1\\nodes_" + problem + ".txt";
            string edge_path = ".\\data\\Hw1\\edges_with_costs_" + problem + ".txt";
            
            List<Node> nodes = Parser.parse_nodes(node_path);
            List<Edge> edges = Parser.parse_edges(edge_path, nodes);

            foreach (Edge e in edges) {
                e.from.add_edge(e);
            }

            Search s = Graph.A_star("1", "160", nodes);
            s.dump_path(@".\src\788v\Hw1\output\path_" + problem + ".json");
            s.dump_tree(@".\src\788v\Hw1\output\tree_" + problem + ".json");

            Console.Write("Done Hw1.\n");
        }
    }
}