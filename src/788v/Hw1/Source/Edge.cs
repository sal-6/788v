

namespace Hw1 {
    public class Edge {
        public Node from { get; set; }
        public Node to { get; set; }
        public float cost { get; set; }

        public Edge(Node from, Node to, float cost) {
            this.from = from;
            this.to = to;
            this.cost = cost;
        }
    }
}