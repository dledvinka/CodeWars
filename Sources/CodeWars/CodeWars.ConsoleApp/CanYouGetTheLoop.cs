using System.Collections;
using System.Collections.Generic;

namespace CodeWars.ConsoleApp
{
    public class CanYouGetTheLoop
    {
        public static int GetLoopSize(Node startNode)
        {
            var visited = new HashSet<int>();
            var currentNode = startNode;

            while (!visited.Contains(currentNode.Next.Index))
            {
                visited.Add(currentNode.Index);
                currentNode = currentNode.Next;
            }

            int loopSize = currentNode.Index - currentNode.Next.Index + 1;

            return loopSize;
        }
    }
}