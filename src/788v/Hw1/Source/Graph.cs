

namespace Hw1 {
    class Graph {
        
        public static Search A_star(string start_id, string end_id, List<Node> nodes) {
            Node start = nodes.Find(n => n.id == start_id);
            Node end = nodes.Find(n => n.id == end_id);
            
            PriorityQueue<Node, float> queue = new PriorityQueue<Node, float>();
            Search search = new Search();
            
            start.cost_to_reach = 0;
            queue.Enqueue(start, 0);
            
            while (queue.Count > 0) {
                Node current = queue.Dequeue();
                
                if (current.parent != null) {
                    search.tree.Add(new List<string> {current.parent.id, current.id});
                }
                
                if (current.id == end_id) {
                    Console.Write("Found path!\n");
                    search.found_path = true;
                    search.build_path(current);
                    return search;
                }
                
                foreach (KeyValuePair<string, float> neighbor in current.neighbors) {
                    Node n = nodes.Find(node => node.id == neighbor.Key);
                    float cost = current.cost_to_reach + neighbor.Value;
                    Console.WriteLine("cost: " + cost);
                    if ((cost < n.cost_to_reach || !n.explored) && n.id != start_id) {
                        n.cost_to_reach = cost;
                        n.explored = true;
                        n.parent = current;
                        float how_good = cost + (float) Math.Sqrt(Math.Pow(n.x - end.x, 2) + Math.Pow(n.y - end.y, 2));
                        queue.Enqueue(n, cost + how_good);
                    }
                }
            }
            
            return search;

        }

        public static Search BFS(string start_id, string end_id, List<Node> nodes) {
            Node start = nodes.Find(n => n.id == start_id);
            Queue<Node> queue = new Queue<Node>();
            Search search = new Search();

            queue.Enqueue(start);
            start.explored = true;
            while (queue.Count > 0) {
                Node current = queue.Dequeue();
                if (current.parent != null) {
                    search.tree.Add(new List<string> {current.parent.id, current.id});
                }
                
                if (current.id == end_id) {
                    Console.Write("Found path!\n");
                    search.found_path = true;
                    search.build_path(current);
                    return search;
                }

                foreach (KeyValuePair<string, float> neighbor in current.neighbors) {
                    Node n = nodes.Find(node => node.id == neighbor.Key);
                    if (!n.explored) {
                        n.parent = current;
                        n.explored = true;
                        queue.Enqueue(n);
                    }
                }
            }
            return search;
        }
        
        /* public static void A_star(string start_id, string end_id, List<Node> nodes) {
            Node start = nodes.Find(n => n.id == start_id);
            Node end = nodes.Find(n => n.id == end_id);

            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();

            open.Add(start);

            while (open.Count > 0) {
                Node current = open[0];
                open.RemoveAt(0);

                if (current.id == end.id) {
                    Console.Write("Found path!\n");
                    return;
                }

                closed.Add(current);

                foreach (KeyValuePair<string, float> neighbor in current.neighbors) {
                    Node n = nodes.Find(node => node.id == neighbor.Key);
                    if (closed.Contains(n)) {
                        continue;
                    }

                    float g = current.g + neighbor.Value;
                    float h = (float) Math.Sqrt(Math.Pow(n.x - end.x, 2) + Math.Pow(n.y - end.y, 2));
                    float f = g + h;

                    if (open.Contains(n)) {
                        if (g < n.g) {
                            n.g = g;
                            n.f = f;
                            n.parent = current;
                        }
                    } else {
                        n.g = g;
                        n.h = h;
                        n.f = f;
                        n.parent = current;
                        open.Add(n);
                    }
                }

                open.Sort((a, b) => a.f.CompareTo(b.f));
            }
        } */
    }
}