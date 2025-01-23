# Mars Rover Navigation Program

## 🚀 Introduction
This project simulates a navigation system for rovers exploring the surface of Mars. The surface is represented as a rectangular grid, and rovers navigate this grid by following specific commands to move or turn. Each rover’s final position and orientation are calculated based on the input instructions.

---

##  How It Works

1. **Plateau Definition**  
   The first input defines the plateau's upper-right corner. The plateau grid always starts at (0, 0) and extends to the specified coordinates.  

   Example: `5 5` creates a grid from (0, 0) to (5, 5).

2. **Rover Initialization**  
   Each rover is initialized with:
   - A starting position: e.g., `1 2 N` (x=1, y=2, facing North).
   - A movement command string: e.g., `LMLMLMLMM`.

3. **Commands**  
   The rovers navigate using the following commands:
   - `L`: Rotate 90° left (without changing position).
   - `R`: Rotate 90° right (without changing position).
   - `M`: Move forward one grid space in the current direction.

4. **Sequential Movement**  
   Each rover navigates the grid one at a time. The first rover completes its movement before the next rover begins.
