


namespace BFSDFS {
    public class Node {
        public string id { get; set;}
        public bool explored { get; set; }
        public List<Node> neighbors { get; set; }
        
        
        public Node(string i) {
            id = i;
            neighbors = new List<Node>();
            explored = false;
        }

        public Node(string i, List<Node> n) {
            id = i;
            neighbors = n;
            explored = false;
        }
        
        
    }
}