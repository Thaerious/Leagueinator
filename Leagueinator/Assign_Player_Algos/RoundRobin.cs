using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Model;
using Org.BouncyCastle.Asn1.Cms;

namespace Leagueinator.Algos {
    public class RoundRobin {
        readonly Graph graph = new Graph();

        public RoundRobin(LeagueEvent lEvent, Round targetRound){
            foreach(Round round in lEvent.Rounds) {
                if (round == targetRound) break;
                graph.AddRound(round);
            }
        }
    }

    public class Graph {
        private readonly Dictionary<PlayerInfo, Node> nodes = new Dictionary<PlayerInfo, Node>();

        /// <summary>
        /// Add weight to an edge;
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="weight"></param>
        public void AddWeight(PlayerInfo p1, PlayerInfo p2, int weight) {
            Node n1 = nodes[p1];
            Node n2 = nodes[p2];

            n1[n2] += weight;
            n2[n1] += weight;
        }

        public void AddRound(Round round) {
            foreach(PlayerInfo pi in round.AllPlayers) {
                nodes[pi] = new Node(pi);
            }

            foreach(Team team in round.Teams) {
                if (team[0] == null || team[1] == null) continue;
                this.AddWeight(team[0], team[1], 1);
            }
        }

        public int SumWeights(Round round) {
            int sum = 0;
            foreach(Team team in round.Teams) {
                if (team[0] == null || team[1] == null) continue;

                Node n1 = nodes[team[0]];
                Node n2 = nodes[team[1]];

                sum += n1[n2];
            }
            return sum;
        }
    }

    public class Node {
        public readonly PlayerInfo PlayerInfo;
        private Dictionary<Node, int> Edges = new Dictionary<Node, int>();

        public int this[Node n] {
            get {
                if (Edges.ContainsKey(n)) return Edges[n];
                return 0;
            }
            set {
                Edges[n] = value;
            }
        }

        public Node(PlayerInfo player) {
            this.PlayerInfo = player;
        }
    }
}
