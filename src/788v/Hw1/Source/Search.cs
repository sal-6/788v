using Newtonsoft.Json;

namespace Hw1 {
    class Search {
        public bool found_path { get; set; }
        public List<string> path;
        public List<List<string>> tree;

        public Search() {
            this.path = new List<string>();
            this.tree = new List<List<string>>();
            this.found_path = false;
        }

        public void build_path(Node end_node) {
            Node node = end_node;
            while (node.parent != null) {
                this.path.Add(node.id);
                node = node.parent;
            }
            this.path.Add(node.id);
        }

        public void dump_path(string output_path) {
            this.path.Reverse();
            Dictionary<string, List<string>> path_dict = new Dictionary<string, List<string>>();
            path_dict["path"] = this.path;
            string json = JsonConvert.SerializeObject(path_dict);
            File.WriteAllText(output_path, json);
            this.path.Reverse();
        }
        
        public void dump_tree(string output_path) {
            Dictionary<string, List<List<string>>> tree_dict = new Dictionary<string, List<List<string>>>();
            tree_dict["tree"] = this.tree;
            string json = JsonConvert.SerializeObject(tree_dict);
            File.WriteAllText(output_path, json);
        }
    }
}