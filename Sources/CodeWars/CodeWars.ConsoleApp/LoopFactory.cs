namespace CodeWars.ConsoleApp
{
    public class LoopFactory
    {
        public static Node CreateChain(int tailSize, int loopSize)
        {
            int nodeIndex = 0;
            
            var firstNode = CreateNode(nodeIndex++);
            var currentNode = firstNode;

            for (int i = 0; i < tailSize; i++)
            {
                var newNode = CreateNode(nodeIndex++);
                currentNode.Next = newNode;
                currentNode = newNode;
            }

            var lastTailNode = currentNode;

            for (int i = 0; i < loopSize - 1; i++)
            {
                var newNode = CreateNode(nodeIndex++);
                currentNode.Next = newNode;
                currentNode = newNode;
            }

            currentNode.Next = lastTailNode;

            return firstNode;
        }

        public static Node CreateNode(int index)
        {
            return new Node(index);
        }
    }

    public class Node
    {
        public Node(int index)
        {
            Index = index;
        }

        public int Index { get; }
        public Node Next { get; set; }
    }
}