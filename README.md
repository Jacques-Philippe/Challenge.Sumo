# Project Summary

The player is a black textured sphere in the center of an arena platform. Around and below the platform there are clouds. The background beyond the platform is a uniform dark grey. It is possible to fall off the arena on all sides. The player's objective is to push off the enemy spheres, which are actively trying to push the player off the platform. The view of the player is off of the arena, at a downward angle. The camera rotates about the vertical axis looking at the scene for horizontal input, and the player moves forwards and backwards with respect to the camera for vertical input.
The player can pick up powerups to more easily bounce enemies away. Powerups are active for a few seconds before being inactive. When the player picks up a powerup, there is a visual indicator to show the powerup is still active. There is a new powerup with each wave.
Enemies spawn in waves. Enemies are white spheres. For each wave one more enemy than there was in the previous wave spawns, and on the first wave there is one enemy. When the player knocks all enemies off the arena, a UI informs the player that the next wave will begin soon, with a countdown to the next wave. On the start of the next wave, enemies spawn in a random position on the arena.

Before the game begins there is a main menu which prompts the player to press space to begin a new game. In the background we see the arena and a few enemies are rolling in a circle.
When the player presses space, the game scene begins

## Project design principles

State information should be as visible and consistent as possible. For instance, I'd like to have something like the following

```
class GameManager {

    public bool isGameOver {get; private set;} = false

    private void EndGame(){
        this.isGameOver = true;
    }

    void Start(){
        Player.OnDeath += EndGame()

    }
}
```

# Mechanics

## Game Manager

The game is over for the player knocked off the platform. Otherwise, waves should spawn continuously, where the next wave spawns if all enemies have been knocked off.

```
    public bool IsGameOver;

    void EndGame(){
        this.IsGameOver = true
    }

    Player.OnDeath += EndGame;

```

## Spawn Manager

At the start of each wave, a series of enemies and a powerup should spawn

```
EnemySpawnManager enemySpawnManager;
PowerupSpawnManager powerupSpawnManager;

public void SpawnWaveContents(int enemyNum){
    enemySpawnManager.SpawnEnemies(enemyNum)
    powerupSpawnManager.SpawnPowerup()
}


```

### Enemy Spawn Manager

Some number of enemies should be spawned at a random position on the arena's surface at the start of a new wave.

```
    event OnAllEnemiesKilled;
    private int numEnemies;

    void NotifyOfEnemyDeath(){
        numEnemies--;
        if (numEnemies == 0){
            OnAllEnemiesKilled.Invoke()
        }
    }

    void SpawnEnemy(){
        Enemy.OnDeath += NotifyOfEnemyDeath()
    }

    public void SpawnEnemies(num){
        numEnemies = num
        for n in num
            SpawnEnemy()
    }

```

## Enemy death

If an enemy falls below a certain threshold, they should be considered dead. From here, they should notify the `Game Manager` of this event.

```
    event OnDeath;

    private void Die(){
        if height < threshold
            OnDeath.Invoke()
    }
```

## Powerup Spawn Manager

A powerup should be spawned at a random position on the arena's surface at the start of a new wave.

```
    void SpawnPowerup()
```

## Wave Manager

For each wave, all enemies and a single powerup are spawned. When all enemies are killed, the next wave starts. If the player dies, the game is over.

```
    GameManager gameManager
    SpawnManager spawnManager
    int enemyNum;
    int secondsBetweenWaves = 5;

    void Start(){
        EnemySpawnManager.OnAllEnemiesKilled += StartNextWave
    }

    void StartNextWave(){
        if (!gameManager.IsGameOver){
            Show next wave starting UI
            for s in [0, secondsBetweenWaves]
                wait a second
                update the value to the UI to secondsBetweenWaves - s

            spawnManager.SpawnWaveContents(enemyNum)
        }
    }
```

## Enemy movement

A spawned enemy should try to hit the player off of the arena. In a simplified iteration of this project, this can be limited to just moving towards the player.

```
Move toward the player, if the player is dead, spin in a circle around the arena.
```

## Player Input

Rotate the camera about the scene's vertical axis for player horizontal input.

## Audio Manager

Play a catchy background music in the background constantly
Play a sound for:

- player kills an enemy
- player dies
- player kills all enemies

## UI

- Main menu
- Game scene
  - When the game begins, show a short instructions UI; `Instructions UI`
  - A new wave is starting; `NewWaveStartingUI`
  - Game over UI

### Instructions UI

Display controls
"Press space to continue"

### NewWaveStartingUI

Display the time until the enemies start spawning `Next wave starting in {timer}`

```
event OnValueUpdated;

int secondsUntilEnemiesSpawn
```

### GameOverUI

Press space to restart

# References

## Figma project

[Here](https://www.figma.com/file/pvXXOwcG5uoVaGlIcU87Ds/Challenge.Sumo?node-id=1%3A5)

## Hosted project

[Here](https://play.unity.com/mg/other/webgl-builds-261767)
