using System;
using System.Collections;
using System.Collections.Generic;

namespace PrimeService;

public class MazePoint
{
    public int X { get; init; }
    public int Y { get; init; }

    public MazePoint(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class MazeRecursion
{
    private readonly int[][] Direction = new int[][]
    {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
    };

    private bool Walk(
        string[] maze,
        string wall,
        MazePoint current,
        MazePoint end,
        bool[][] seen,
        ref Stack<MazePoint> path
    )
    {
        // invalid positions
        if (current.X < 0 || current.X > maze[0].Length || current.Y < 0 || current.Y > maze.Length)
        {
            return false;
        }

        // hits a wall
        if (maze[current.Y][current.X].ToString() == wall)
        {
            return false;
        }

        // at end
        if (current.Y == end.Y && current.X == end.X)
        {
            path.Push(end);
            return true;
        }

        if (seen[current.Y][current.X])
        {
            return false;
        }

        // pre
        seen[current.Y][current.X] = true;
        path.Push(current);

        // recurse
        for (var i = 0; i < Direction.Length; ++i)
        {
            var directionToWalk = Direction[i];
            var reachedEnd = Walk(
                maze,
                wall,
                new MazePoint(current.X + directionToWalk[0], current.Y + directionToWalk[1]),
                end,
                seen,
                ref path
            );
            if (reachedEnd)
            {
                return true;
            }
        }

        // post
        _ = path.Pop();
        return false;
    }

    public MazePoint[] Solve(string[] maze, string wall, MazePoint start, MazePoint end)
    {
        var seen = Array.Empty<bool[]>();
        var path = new Stack<MazePoint>();

        for (var i = 0; i < maze.Length; ++i)
        {
            seen = seen.Append(Enumerable.Repeat(0, maze[0].Length).Select(x => false).ToArray())
                .ToArray();
        }

        _ = Walk(maze, wall, start, end, seen, ref path);
        return path.ToArray();
    }
}
