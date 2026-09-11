# Tilemania

<!-- Replace this line with your gameplay GIF or screenshot:
![Tilemania Gameplay](YOUR_IMAGE_URL)
-->

A 2D platforming game where the player runs, jumps, climbs, and shoots their way through multiple tile-based levels while collecting coins and avoiding enemies and hazards.

## About the Project

Tilemania is a small 2D platforming game built using Unity and C#. The player must make their way through a series of levels by navigating platforms, climbing ladders, collecting coins, and avoiding enemies and environmental hazards. The player is also able to shoot projectiles to defeat enemies standing in their way.

The player begins with a limited number of lives, losing one whenever they collide with an enemy or hazard. The game keeps track of the player's lives and score between levels, with the goal of reaching the end of every level before running out of lives.

This project focused on player movement, animation states, tilemap-based level design, enemy behavior, scene transitions, and maintaining data between multiple levels.

## Tutorial Context

This project was developed initially while following the "Complete C# Unity 2D Game Development (Updated To Unity 6)" course on Unity by GameDev.tv.

The course provided the foundation and guided implementation of the core aspects of the game itself. I used this project not only as an opportunity to further familiarize myself with Unity, C#, and game development as a whole, but also as a way to better understand how the different systems inside a larger game interact with one another.

Compared to the earlier projects in the course, Tilemania introduced several systems working together at the same time, including character movement, animation, tilemaps, enemies, projectiles, scoring, lives, and level transitions.

### My additions

After completing and following the tutorial portion of the project, I took the liberty to extend the game with several features of my own!

<!-- Replace the examples below with the features you personally added. -->

* Designed original level layouts with different platforming challenges.
* Adjusted the player's movement, jumping, and climbing speeds to create a smoother gameplay experience.
* Added unique enemy and hazard placements throughout the levels.
* Modified the environment, tilemaps, and visual design of the game.
* Added additional gameplay features and level-design elements beyond those demonstrated in the tutorial.

## Gameplay and Features

* Horizontal player movement and platforming
* Jumping and ground detection
* Ladder climbing
* Tilemap-based levels using Rule Tiles
* Character animations and animation-state transitions
* Enemies that patrol platforms and change direction when reaching obstacles
* Projectiles that allow the player to defeat enemies
* Coins that increase the player's score
* Environmental hazards and player-death states
* A limited-lives system
* Persistent score and lives between levels
* Multiple levels with scene transitions
* Cinemachine camera following and level confinement
* Sound effects and gameplay feedback

## What I Learned

Building Tilemania helped me develop a stronger understanding of how Unity's different systems, such as movement, animation, physics, tilemaps, cameras, and scene management, work together:

* Learned how to create tile-based levels using Unity's Tilemap system and Rule Tiles, allowing levels to be designed and modified more efficiently.
* Implemented horizontal movement, jumping, and ladder climbing, giving me experience translating player input into different forms of character movement.
* Used Unity's physics and collision systems to determine when the player was grounded, touching a ladder, colliding with an enemy, or interacting with a hazard.
* Created animation states and transitions for actions such as standing, running, climbing, and dying.
* Learned how to flip sprites based on their direction of movement so that characters and enemies would face the correct direction.
* Implemented basic enemy behavior, allowing enemies to move across platforms and turn around when they encountered an obstacle.
* Created a projectile system using prefabs and `Instantiate()`, giving the player the ability to shoot and defeat enemies.
* Used Cinemachine to create a camera that follows the player while remaining confined within the boundaries of each level.
* Implemented a score and lives system that remains persistent while moving between different scenes.
* Learned how coroutines can be used to delay events such as restarting a level after the player dies.
* Practiced using the Singleton pattern to manage a game session and prevent duplicate game-session objects from being created.
* Gained more experience separating game mechanics and responsibilities across multiple MonoBehaviour C# scripts instead of placing all of the game's logic inside a single script.
* Developed a better understanding of debugging interactions between player input, physics, animation, collision detection, and scene management.

## Controls

| **Input**                    | **Action**          |
| ---------------------------- | ------------------- |
| A/D or Left/Right Arrow Keys | Move left and right |
| Space                        | Jump                |
| W/S or Up/Down Arrow Keys    | Climb ladders       |
| Left Ctrl                    | Shoot               |

## Technologies

* Unity 6 — Developed using Unity 6000.5.4f1
* C#
* Git
* GitHub

## Running the Project

1. Clone the repository.
2. Open Unity Hub.
3. Select **Add → Add project from disk**.
4. Select the cloned project directory.
5. Open the project using the Unity Editor version stated above.
6. Open the first gameplay scene and press the Play button.

## Credits

The original project was created as part of the "Complete C# Unity 2D Game Development (Updated To Unity 6)" course by GameDev.tv.

Course: [Udemy Course](https://www.udemy.com/course/unitycourse/)
