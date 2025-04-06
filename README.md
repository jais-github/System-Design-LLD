# Snake and Ladder - Low Level Design (LLD)

## Project Description
This is a Low-Level Design (LLD) implementation of the classic **Snake and Ladder** game using object-oriented principles in C#. The game is designed to be easily extendable and readable, 
making it a solid example for system design and object modeling practice.

---

## Requirements
- Console-based Snake and Ladder game
- Multiple players support
- Board with snakes and ladders
- Dice roll simulation
- Player moves according to dice
- Snake and ladder behavior based on jumps
- Winner is the first player to reach the last cell

---

## Classes & Relationships

### `Game`
- Manages the game lifecycle
- Has `Board`, `Dice`, `Players`
- Handles game loop and winner check

### `Board`
- 2D array of `Cell`
- Initializes with snakes and ladders using `Jump`

### `Cell`
- Represents a square on the board
- May have a `Jump` (snake or ladder)

### `Jump`
- Holds `start` and `end` positions
- Can represent a snake (start > end) or ladder (start < end)

### `Dice`
- Handles dice rolling logic
- Can be configured for number of dice

### `Player`
- Holds player ID and current position on board

---

## Functionality

- Initialize board of `n x n` size
- Add random `k` snakes and `l` ladders
- Players take turns to roll the dice
- Player moves are calculated with jump logic
- Snakes bring players down, ladders take them up
- Game continues until a player reaches or exceeds the final cell

---

## How to Run

1. Open solution in Visual Studio
2. Set `Main.cs` as the startup project
3. Build and run the project

---

## Future Improvements

- GUI Support using Windows Forms or WPF
- Save game progress
- Multiplayer networking support
- Enhanced game rules (e.g., need exact number to win)

---

