# Starfighter: Space Flight-Simulation Game

**Starfighter** is a space flight-simulation game where you pilot your aircraft to defend against waves of enemies. Experience intense aerial combat, precise controls, and an engaging scoring system as you test your skills.

---

## Features

### Graphics and Environment
- **Enhanced Visuals**: Leveraging the HDRP render pipeline for realistic textures, lighting, and VFX.
- **Space-Themed Setting**:
  - Fight above a detailed planet in a dynamic space environment.
  - A nearby black hole adds a stunning visual element.
  - The planet and black hole rotate over time, creating a sense of immersion.

### Player Aircraft
- **Agile Controls**: The spacecraft is designed for smooth maneuverability and precise handling.
- **Enhanced Durability**: The player’s spacecraft is equipped with advanced armor to sustain intense combat.
- **Dynamic Lighting**: Real-time lighting effects enhance the visuals of the player’s aircraft.

### Enemy Aircraft and Gameplay
- **Adaptive Enemy Spawning**: Enemies respawn within 3000 to 6000 meters of the player, ensuring continuous action.
- **Lock-On System**: The player can lock on to the closest enemy for better targeting.
- **Missile Tracking**: Missiles are equipped with improved guidance systems to track and destroy targets effectively.
- **Particle Effects**: New particle effects for missiles and explosions enhance the overall gameplay experience.

### Scoring System
- **Points System**:
  - Missile hit: 50 points
  - Cannon damage: Points based on damage dealt
  - Enemy kill: 100 points
- **Leaderboard Potential**: Compete for the highest score by taking down waves of enemies.

### Controls
#### Keyboard Controls
- **Arrow Keys**: Adjust roll and pitch.
- **A/D Keys**: Control yaw (rudder).
- **W/S Keys**: Adjust throttle.
- **Space**: Fire missiles.
- **Left Ctrl**: Fire cannon.

### Adafruit Circuit Playground Controls
For precise control, you can use the Adafruit Circuit Playground:

<div align="center">

| Control       | Description                                                                                 | Image                                                                                              |
|---------------|---------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------|
| **Pitch**     | Tilting the Adafruit Circuit Playground forward or backward to control pitch.               | <img src="https://github.com/user-attachments/assets/3e2acf3e-7ec1-42dd-ac47-97b876746d3e" width="300"> |
| **Roll**      | Tilting the Adafruit Circuit Playground left or right to control roll.                      | <img src="https://github.com/user-attachments/assets/10ce97eb-27b1-4923-b2a4-57c792c0a2e9" width="300"> |

*Table 1: Pitch and Roll controls with the Adafruit Circuit Playground.*

</div>

---

#### Throttle and Yaw/Rudder Controls
The slider and buttons on the Adafruit Circuit Playground are used to control throttle and yaw:

<div align="center">

| Slider Position | Control            | Description                                                 | Image                                                                                              |
|------------------|--------------------|-------------------------------------------------------------|----------------------------------------------------------------------------------------------------|
| **(-)**          | **Button B**       | Increases the throttle.                                     | <img src="https://github.com/user-attachments/assets/5c9daca9-ec98-4256-aec8-2641afcab9ed" width="300" rowspan="2"> |
| **(-)**          | **Button A**       | Decreases the throttle.                                     |                                                                                                   |
| **(+)**          | **Button B**       | Yaws the craft to the left.                                 | <img src="https://github.com/user-attachments/assets/e6f64769-b98e-4dd4-8606-295f8ca32e76" width="300" rowspan="2"> |
| **(+)**          | **Button A**       | Yaws the craft to the right.                                |                                                                                                   |

*Table 2: Throttle and Yaw/Rudder controls using the Adafruit Circuit Playground.*

</div>



## Audio
- **3D Sound Effects**: Dynamic audio for missiles and the jet engine, with pitch and volume adjusting based on throttle.
- **Additional SFX**:
  - Explosions
  - Cannon fire
  - Ambiance
  - Music

---

## Additional Features
- **Main Menu**: A functional main menu for navigating the game.
- **Game Over State**: Defined states for when the player is defeated.
- **Enhanced Gameplay**:
  - Detection of all enemies in the scene for better tracking.
  - Differentiated enemy types with unique stats.

---

Play **Starfighter** to test your piloting skills, destroy waves of enemies, and achieve the highest score. Choose between traditional keyboard controls or the precision of the Adafruit Circuit Playground for a tailored experience. Engage in immersive gameplay with immersive visuals and 3D audio.
