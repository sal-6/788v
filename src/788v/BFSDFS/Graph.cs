using Newtonsoft.Json;
using System;

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

        public static List<string> DFS(string start_id, string end_id, Dictionary<string, Node> graph) {
            
            Stack<Node> node_queue = new Stack<Node>();
            List<string> path = new List<string>();

            // add the start node to the queue
            node_queue.Push(graph[start_id]);

            while (node_queue.Count > 0) {
                // get the next node in the queue
                Node node = node_queue.Pop();
                path.Add(node.id);
                node.explored = true;

                if (node.id == end_id) {
                    // if the end node has been found, return the path
                    return path;
                }

                foreach (Node n in node.neighbors) {
                    if (!n.explored && !node_queue.Contains(n)) {
                        n.parent = node;
                        node_queue.Push(n);
                    }
                }
            }

            // if the queue is empty and the end node has not been found, return null
            return path;
        }

        public static List<string> BFS(string start_id, string end_id, Dictionary<string, Node> graph) {
            
            Queue<Node> node_queue = new Queue<Node>();
            List<string> path = new List<string>();

            // add the start node to the queue
            node_queue.Enqueue(graph[start_id]);

            while (node_queue.Count > 0) {
                // get the next node in the queue
                Node node = node_queue.Dequeue();
                path.Add(node.id);
                node.explored = true;

                if (node.id == end_id) {
                    // if the end node has been found, return the path
                    return path;
                }

                foreach (Node n in node.neighbors) {
                    if (!n.explored && !node_queue.Contains(n)) {
                        n.parent = node;
                        node_queue.Enqueue(n);
                    }
                }
            }

            // if the queue is empty and the end node has not been found, return null
            return path;
        }
    }
}