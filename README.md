# Interview-Puzzle
Mapping Robot
You are tasked with generating a list of directions to each of our clients’ offices. You have a robot capable of roaming the streets in search of a destination, but it only has the ability to turn left or right and move forward any number of blocks; it does not necessarily take the most direct route.
The robot stores data on each route including the date of the trip, the name of the destination, and a comma-separated list of actions taken. Each action is comprised of a rotation (L – left, R – right) and a number of blocks.


Assumptions:

  -The robot always starts facing West.
  
  -The city spans an infinite number of blocks in every direction.
  
  -The robot always reaches its destination.


Write a program in C# or Javascript to determine the most direct route based on the data retrieved from the robot.



Sample Input:

2017-01-01; Coffee Shop; L2, L5, L5, R5, L2
2017-01-02; Advertising Agency; R3, R3, R3, L2

Sample Output:

2017-01-01; Coffee Shop; R5 R10
2017-01-02; Advertising Agency; R0, R5
