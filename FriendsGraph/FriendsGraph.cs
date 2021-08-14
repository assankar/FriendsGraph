using System;
using System.Collections.Generic;

namespace FriendsGraph
{
    class FriendsGraph
    {
        public FriendsGraph()
        {

        }
        static void Main(string[] args)
        {
            FriendsGraph fg = new FriendsGraph();
            List<int> networkFromTest1 = new List<int>() { 1, 2, 3 };
            List<int> networkToTest1 = new List<int>() { 2, 3, 4 };
            Console.WriteLine("Test1: " + fg.GetTotalFriends(networkFromTest1, networkToTest1));

            List<int> networkFromTest2 = new List<int>() { 0, 1 };
            List<int> networkToTest2 = new List<int>() { 1, 2 };
            Console.WriteLine("Test2: " + fg.GetTotalFriends(networkFromTest2, networkToTest2));

            List<int> networkFromTest3 = new List<int>() { 0, 1, 2, 3, 5};
            List<int> networkToTest3 = new List<int>() { 1, 2, 3, 4, 1};
            Console.WriteLine("Test2: " + fg.GetTotalFriends(networkFromTest3, networkToTest3));

        }

        public int GetTotalFriends(List<int> networkFrom, List<int> networkTo)
        {
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            //SortedDictionary<Tuple<int, int>, HashSet<int>> graph2 = new SortedDictionary<Tuple<int, int>, HashSet<int>>();
            List<int> blah = new List<int>();
            blah.a

            for(int i = 0; i < networkFrom.Count; i++)
            {
                if (graph.ContainsKey(networkFrom[i]))
                {
                    HashSet<int> tempSet = graph[networkFrom[i]];
                    tempSet.Add(networkTo[i]);
                    graph[networkFrom[i]] = tempSet;
                    if (graph.ContainsKey(networkTo[i]))
                    {
                        HashSet<int> otherTempSet = graph[networkTo[i]];
                        otherTempSet.Add(networkFrom[i]);
                        graph[networkTo[i]] = otherTempSet;
                    }
                    else
                    {
                        graph[networkTo[i]] = new HashSet<int>() { networkFrom[i] };
                    }
                }
                else
                {
                    graph[networkFrom[i]] = new HashSet<int>() { networkTo[i] };
                    if (graph.ContainsKey(networkTo[i]))
                    {
                        HashSet<int> otherTempSet = graph[networkTo[i]];
                        otherTempSet.Add(networkFrom[i]);
                        graph[networkTo[i]] = otherTempSet;
                    }
                    else
                    {
                        graph[networkTo[i]] = new HashSet<int>() { networkFrom[i] };
                    }
                }
            }

            while (true)
            {
                int key = 0;
                int max = 0;
                foreach (var item in graph.Keys)
                {
                    if (graph[item].Count > max)
                    {
                        max = graph[item].Count;
                        key = item;
                    }
                }
                graph.Remove(key);
                foreach (var item in graph.Keys)
                {
                    if (graph[item].Contains(key))
                    {
                        graph[item].Remove(key);
                    }
                }
                bool isNotEmtpy = false;
                foreach(var item in graph.Keys)
                {
                    if(graph[item].Count != 0)
                    {
                        isNotEmtpy = true;
                    }
                }
                if (isNotEmtpy)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }


            return graph.Count;
        }
    }
}
