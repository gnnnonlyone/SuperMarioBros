THIS IS A README FILE FOR SPRINT 5 initial implementation.

# Author: Tree New Bee

# Overview
This project is the initial implementation of the Sprint 5. The project implemented
Heads Up Display, sounds, points and score system and game state transaction. Additionally,
magic numbers are removed from the code.

# Keyboard Commands
Up / W: Mario Jump State
Down / S: Mario Crouch State
Left / A: Mario Running Left State
Right / D: Mario Running Right State

Y - Turn Mario into Small State
U - Turn Mario into Big State
I - Turn Mario into Fire State
O - Turn Mario into Dead State

X - Mario Fire 
Q - Quit Program
R - Reset Program
P - Pasue the Program 
E - Resume the Program(Only works when the game is paused)

Note:
1. When mario is dead, please wait a few seconds and you will be back to the start point.
2. The mario can go into the hidden world from top of the pipe and go back to the main world from bottom of the pipe

Code Analyst Error:
The program has one code analyst error. The team decided to use two-dimentional array to store the block objects. Compared
to Collection or List, 2-D array is easier to understand and easier to debug. 

For sprint 6, we implemented the additional features:
1. Level 2-2, which includes swimming mario, new enemies (jellyfish and fish), new block types
2. random goomba event