# Eight-Queens Problem

The only symmetrical solution to the eight queens puzzle (except for rotations and reflections of itself).
The eight queens puzzle is the problem of placing eight chess queens on an 8×8 chessboard so that no two queens threaten each other. Thus, a solution requires that no two queens share the same row, column, or diagonal.

## Solution construction
The problem can be quite computationally expensive, as there are 4,426,165,368 (i.e., 64C8) possible arrangements of eight queens on an 8×8 board, but only 92 solutions. It is possible to use shortcuts that reduce computational requirements or rules of thumb that avoids brute-force computational techniques. For example, by applying a simple rule that constrains each queen to a single column (or row), though still considered brute force, it is possible to reduce the number of possibilities to 16,777,216 (that is, 88) possible combinations. Generating permutations further reduces the possibilities to just 40,320 (that is, 8!), which are then checked for diagonal attacks.

## Solutions
Finding all solutions to this strategy game (the 8 queens puzzle) is a good example of a simple but nontrivial problem. For this reason, it is often used as an example problem for various programming techniques, including nontraditional approaches such as constraint programming, logic programming or genetic algorithms. Most often, it is used as an example of a problem which can be solved with a recursive algorithm, by phrasing the n queens problem inductively in terms of adding a single queen to any solution to the n?1 queens problem. The induction bottoms out with the solution to the 0 queens problem, which is an empty chessboard.

![eightqueens01](https://user-images.githubusercontent.com/24358394/40299747-ef2f154a-5cef-11e8-8797-e885ee97f966.png)
