namespace PrimeService;
public static class GraphMatrixBFS
{
    public static int[] Search(int[][] graph, int source, int needle)
    {
        bool[] seen = [];
        int[] prev = [];
        Array.Fill(seen, false, 0, graph.Length);
        Array.Fill(prev, -1, 0, graph.Length);

        seen[source] = true;
        System.Collections.Generic.Queue<int> q = new();
        q.Enqueue(source);
        do {
            var curr = q.Dequeue();
            if(curr == needle) {
                break;
            }

            var adjs = graph[curr];
            for(var i = 0; i < graph.Length; i++)
            {
                if(adjs[i] == 0) continue;

                if(seen[i]) continue;

                seen[i] = true;
                prev[i] = curr;
                q.Enqueue(i);
            }
            seen[curr] = true;


        } while(q.Count > 0);

        var curr1 = needle;
        int[] outR = [];

        while(prev[curr1] != -1)
        {
            outR = [..outR, curr1];
            curr1 = prev[curr1];
        }
        if(outR.Length > 0)
        {
            return [source, ..outR.Reverse().ToArray()];
        }
        return outR;
    }
}