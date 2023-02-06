

namespace Hw1 {
    public class Node {
        public string id { get; set;}
        public float x { get; set; }
        public float y { get; set; }
        public Dictionary<string, float> neighbors { get; set; }
        public Node parent { get; set; }
        public bool explored { get; set; }
        public float cost_to_reach { get; set; }

        public Node(string id, float x, float y) {
            this.id = id;
            this.x = x;
            this.y = y;
            this.neighbors = new Dictionary<string, float>();
            this.parent = null;
            this.explored = false;
            this.cost_to_reach = 0;
        }
        
        public void add_edge(Edge edge) {
            this.neighbors[edge.to.id] = edge.cost;
        }

    }
}