# Project PROJECT_NAME

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Nicholas DiGiovanni
-   Section: 03

## Game Design

-   Camera Orientation: topdown
-   Camera Movement: static
-   Player Health: _How are you handling player health? (healthbar, lives, ?)_
-   End Condition: _How does a game/round/level end?_
-   Scoring: _How does the player earn points in your game?_

### Game Description

_A brief explanation of your game. Inculde what is the objective for the player. Think about what would go on the back of a game box._

The goal of the game is to survive as long as possible with an increasing amount of enemies. The one catch is that everything wraps on the screen,
including your own bullets. You'll have to be smart and aware of every single thing on screen as it may come back to hurt you later.

### Controls

-   Movement
    -   Up: W
    -   Down: S
    -   Left: A
    -   Right: D
-   Aiming
    -   Up: Up Arrow
    -   Down: Down Arrow
    -   Left: Left Arrow
    -   Right: Right Arrow
-   Fire: 
    - Space

## You Additions
_List out what you added to your game to make it different for you_

Own additions:
- Recusively spawning enemies from destroyed enemies, enemies will spawn two enemies on death. This will happen twice before just regularly despawning.
- Damage that increases exponentially when you are colliding with an enemy.
- Added a main menu and highscore to the game.

## Sources
- I did the art assets for the player, bullets and enemies.

## Known Issues
Collision between PlayerBullets, Enemies and Player is working. There is an issue where if there is a bullet out of the screen, the player wont change color to indicate a collision from an enemy due to how the code is written, but the collision is still being detected if you look at the code

### Requirements not completed

_If you did not complete a project requirement, notate that here_
