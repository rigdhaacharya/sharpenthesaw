using System;

namespace WordSearchProblem
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// https://leetcode.com/problems/word-search-ii/
    /// This version simply uses lists, it'd be better to use trie for the words at least
    /// </summary>
    public class WordSearchBFS
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            var results = new List<string>();

            //iterate through all i
            var len = board.Length;
            for (int i = 0; i < len; i++)
            {
                var jLen = board[i].Length;
                for (int j = 0; j < jLen; j++)
                {
                    var result = FindWordsBFS(new Coordinate(i, j, new List<Coordinate>()), board, words);
                    foreach (var res in result)
                    {
                        if (!results.Contains(res))
                        {
                            results.Add(res);
                        }
                    }
                }
            }

            return results;
        }

        private List<string> FindWordsBFS(Coordinate coordinate, char[][] board, string[] words)
        {
            var result = new List<string>();
            Queue<Coordinate> coordinateQueue = new Queue<Coordinate>();
            var currentStem = new List<Coordinate>();
            currentStem.Add(coordinate);
            var currentWord = coordinate.GetWord(board);
            var candidateMatches = words.Where(s => s.StartsWith(currentWord)).ToList();
            if (!candidateMatches.Any()) { return new List<string>(); }

            foreach (var candidateMatch in candidateMatches)
            {
                if (candidateMatch == currentWord)
                {
                    result.Add(currentWord);
                }
            }
            AddNeighbors(coordinateQueue, coordinate, board, currentStem);
            //while queue is not empty
            while (coordinateQueue.Count > 0)
            {
                bool alreadyVisisted = false;
                var currentCoordinate = coordinateQueue.Dequeue();
                foreach (var stemCoordinate in currentCoordinate.Stem)
                {
                    if (stemCoordinate.X == currentCoordinate.X && stemCoordinate.Y == currentCoordinate.Y)
                    {
                        alreadyVisisted = true;
                    }
                }

                if (!alreadyVisisted)
                {
                    currentWord = currentCoordinate.GetWord(board);
                    candidateMatches = words.Where(s => s.StartsWith(currentWord)).ToList();
                    if (!candidateMatches.Any()) { continue; } // no need to go through it's neighbors
                    if (candidateMatches.Any())
                    {
                        foreach (var candidateMatch in candidateMatches)
                        {
                            if (candidateMatch == currentWord)
                            {
                                result.Add(currentWord);

                            }
                        }


                        var newStem = new List<Coordinate>();
                        newStem.AddRange(currentCoordinate.Stem);
                        newStem.Add(currentCoordinate);
                        AddNeighbors(coordinateQueue, currentCoordinate, board, newStem);


                    }
                }
                
            }

            return result;
        }

        private void ZeroOutCurrentStem(Coordinate currentCoordinate, char[][] board)
        {
            foreach (var coordinate in currentCoordinate.Stem)
            {
                board[coordinate.X][coordinate.Y] = '0';
            }

            board[currentCoordinate.X][currentCoordinate.Y] = '0';
        }

        private void AddNeighbors(Queue<Coordinate> coordinateQueue, Coordinate coordinate, char[][] board, List<Coordinate> currentStem)
        {
            var neighborAdded = false;
            if (coordinate.X - 1 >= 0)
            {
                coordinateQueue.Enqueue(new Coordinate(coordinate.X - 1, coordinate.Y, currentStem));
            }
            //add right
            if (coordinate.X + 1 < board.Length)
            {
                coordinateQueue.Enqueue(new Coordinate(coordinate.X + 1, coordinate.Y, currentStem));
            }
            //add up
            if (coordinate.Y - 1 >= 0)
            {
                coordinateQueue.Enqueue(new Coordinate(coordinate.X, coordinate.Y - 1, currentStem));
            }
            //add down
            if (coordinate.Y + 1 < board[0].Length)
            {
                coordinateQueue.Enqueue(new Coordinate(coordinate.X, coordinate.Y + 1, currentStem));
            }


        }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Coordinate> Stem { get; set; }
        public Coordinate(int x, int y, List<Coordinate> stem)
        {
            X = x;
            Y = y;
            Stem = stem;
        }

        public string GetWord(char[][] board)
        {
            string currentWord = string.Empty;
            foreach (var coordinate in Stem)
            {
                currentWord = currentWord + board[coordinate.X][coordinate.Y];
            }

            currentWord = currentWord + board[X][Y];
            return currentWord;
        }
    }
}
