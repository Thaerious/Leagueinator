﻿using System.Collections.Generic;
using Leagueinator.Model;

namespace Leagueinator.Search_Algorithms {
    public class CountPartners {
        public static int Count(LeagueEvent lEvent, Round targetRound) {
            var graph = new Graph();
            foreach (Round round in lEvent) {
                if (round == targetRound) break;
                graph.AddRound(round);
            }

            return graph.SumWeights(targetRound);
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
        private void AddWeight(PlayerInfo p1, PlayerInfo p2, int weight) {
            Node n1 = nodes[p1];
            Node n2 = nodes[p2];

            n1[n2] += weight;
            n2[n1] += weight;
        }

        public void AddRound(Round round) {
            foreach (PlayerInfo pi in round.AllPlayers) {
                if (!nodes.ContainsKey(pi)) nodes[pi] = new Node(pi);
            }

            foreach (Team team in round.Teams) {
                if (team[0] == null || team[1] == null) continue;
                AddWeight(team[0], team[1], 1);
            }
        }

        public int SumWeights(Round round) {
            int sum = 0;
            foreach (Team team in round.Teams) {
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
            PlayerInfo = player;
        }
    }
}
