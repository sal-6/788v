using Newtonsoft.Json;

namespace BFSDFS {
    
    public class Graph {
        
        public static Dictionary<string, Node> readJson() {
            string json = File.ReadAllText("G:\\My Drive\\UMD\\Spring 2023\\ENAE788V\\Code\\788v\\src\\788v\\BFSDFS\\graphDef.json");
            Dictionary<string, List<string>> graphDef = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            Dictionary<string, Node> graph = new Dictionary<string, Node>();
            if (graphDef != null) {
            
                foreach (KeyValuePair<string, List<string>> entry in graphDef) {
                    // if the key is not in the keys of the graph, add it
                    if (!graph.ContainsKey(entry.Key)) {
                        Node node = new Node(entry.Key);
                        graph.Add(entry.Key, node);
                    }
                    
                    // loop through the neighbors of the key
                    foreach (string neighbor in entry.Value) {
                        // if the neighbor is not in the keys of the graph, add it
                        if (!graph.ContainsKey(neighbor)) {
                            Node node = new Node(neighbor);
                            graph.Add(neighbor, node);
                        }
                        
                        // add the neighbor to the key's neighbors
                        graph[entry.Key].neighbors.Add(graph[neighbor]);
                    }
                }
            }
            return graph;
        }
    }
}