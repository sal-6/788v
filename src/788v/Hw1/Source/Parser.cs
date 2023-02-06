using System;
using Microsoft.VisualBasic.FileIO;

namespace Hw1 {
    class Parser {
        public static List<Node> parse_nodes(string nodes_path) {
            List<string> node_ids = new List<string>();
            List<Node> nodes = new List<Node>();
            using (TextFieldParser parser = new TextFieldParser(nodes_path))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    bool first_line = true;
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (first_line) {
                            first_line = false;
                            continue;
                        }                        
                        nodes.Add(new Node(fields[0], float.Parse(fields[1]), float.Parse(fields[2])));
                    }
                }

            return nodes;
        }

        public static List<Edge> parse_edges(string edges_path, List<Node> nodes) {
            List<Edge> edges = new List<Edge>();
            using (TextFieldParser parser = new TextFieldParser(edges_path)) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool first_line = true;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (first_line) {
                        first_line = false;
                        continue;
                    }                        
                    string from_id = fields[0];
                    string to_id = fields[1];
                    float cost = float.Parse(fields[2]);
                    Node from = nodes.Find(node => node.id == from_id);
                    Node to = nodes.Find(node => node.id == to_id);
                    edges.Add(new Edge(from, to, cost));
                }
            } 
            return edges;
        }
    }
}