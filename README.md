# Brickwork

[![](https://devcamp.mentormate.com/wp-content/uploads/2020/11/DevCamp-1.svg)](https://devcamp.mentormate.com/ "MentorMate DevCamp")

Console Application that build brick layer by given input.

## IDE
```
Visual Studio v. 16.8.3 or any other software that allows you to start .Net Core App 3.1 applications
```
## How to run
Find and load Brickwork.sln file from the directory where you downloaded it.</br>
When the project is loaded press F5 button (if you use Visual Studio v. 16.8.3) from the keyboard or check how to start Console App .Net Core 3.1 with program that you use.</br>
Brickwork solves the problem where we need to lay down a second layer of bricks on top of a given layer.The first layer must be of size NxM where N and M even bigger than 0 and lesser than 100. In case of invalid input the program throws an exception.The second layer must be created in a way that no bricks in it lies on a brick from the first layer.

## Input
On the first line N and M separated by a space must be inputted.

On the next N lines M numbers separated by a space must be inputted representing the bricks.

If there is no solution program throws an exception message:

`
"-1  No solution exist!"
`

## Output
The new layer will be described in N lines with M numbers in each.

There will be one more visualisation with brick surrounded by "*".

## Sample 1
                   
Input           | Output
------------- | -------------
2 4               |
1 1 2 2         | 1 2 2 3
3 3 4 4         | 1 4 4 3

## Sample 2
                    
Input                       | Output
--------------------- | -------------
2 8                           |
1 1 2 2 6 5 5 8         | 1 2 2 3 3 4 5 5
3 3 4 4 6 7 7 8         | 1 6 6 7 7 4 8 8

## Sample 3
                    
Input                            | Output
---------------------      | -------------
4 8                                |
1 2 2 12 5 7 7 16          | 1 1 2 2 3 3 4 4
1 10 10 12 5 15 15 16  | 1 6 6 7 7 4 8 8
9 9 3 4 4 8 8 14            | 5 5 6 6 7 7 8 8
11 11 3 13 13 6 6 14    | 9 14 14 11 15 15 16 16
