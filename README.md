# Starfighter: Space Flight-Simulation Game

**Starfighter** is a space flight-simulation game where you pilot your aircraft to defend against waves of enemies. Experience intense aerial combat, precise controls, and an engaging scoring system as you test your skills.

<div style="position: relative; padding-bottom: 56.25%; height: 0; overflow: hidden; max-width: 100%; height: auto;">
  <iframe style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;" src="https://www.youtube.com/embed/m6AmVoCkLd4" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
</div>

---

## Features

### Graphics and Environment
- **Enhanced Visuals**: Leveraging the HDRP render pipeline for realistic textures, lighting, and VFX.
- **Space-Themed Setting**:
  - Fight above a detailed planet in a dynamic space environment.
  - A nearby black hole adds a stunning visual element.
  - The planet and black hole rotate over time, creating a sense of immersion.

### Player Aircraft
- **Agile Controls**: The spacecraft is designed for smooth manoeuvrability and precise handling.
- **Enhanced Durability**: The player’s spacecraft is equipped with advanced armour to sustain intense combat.
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


### HUD (Heads-Up Display)

The HUD provides information to help you navigate and engage in combat effectively.

<div align="center">

![Regular UI](https://github.com/user-attachments/assets/b1921473-fe3f-4a71-88d9-da7de056445c)  
*Figure 1: Regular HUD displaying speed, angle of attack, G-force, altitude, and enemy indicators.*

</div>

#### Regular HUD
- **Left Side**:
  - **Speed**: The first number from the top, displays the current speed of the plane.
  - **Angle of Attack**: Shown below the speed.
  - **G-Force**: Indicates the G-forces experienced in the cockpit.  
- **Right Side**:
  - **Altitude**: Represents the distance to the nearest planet.
- **Top**:
  - **Compass**: Helps with navigation.
- **Enemy Indicators**:
  - Three arrows show the relative positions of nearby enemies:
    - **Green**: Closest enemy.
    - **Blue**: Furthest enemy.
    - **Yellow**: Enemy in the middle.

---

<div align="center">

![Missile Locked](https://github.com/user-attachments/assets/ceec4755-f4b8-4fa2-a0c9-f8e0926d4b36)  
*Figure 2: HUD alert showing a missile lock and an incoming missile indicated by a red arrow.*

</div>

#### Missile Lock Warning and Enemy Targeting
- When an enemy locks onto you:
  - The HUD background turns **red** as an alert.
- When a missile is fired at you:
  - A **red arrow** indicates the direction of the incoming missile.
    
- **Enemy Targeting**:
  - A **box** is drawn around the targeted enemy when locked on.
  - The box turns **red** when a locked missile is fired.

---



### Controls
#### Keyboard Controls
- **Arrow Keys**: Adjust roll and pitch.
- **A/D Keys**: Control yaw (rudder).
- **W/S Keys**: Adjust throttle.
- **Space**: Fire missiles.
- **Left Ctrl**: Fire cannon.

### Adafruit Circuit Playground Controls
For precise control, you can use the Adafruit Circuit Playground:

#### Pitch and Roll Controls

<div align="center">

| Control       | Description                                                                                 | Image                                                                                              |
|---------------|---------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------|
| **Pitch**     | Tilting the Adafruit Circuit Playground forward or backward to control pitch.               | <img src="https://github.com/user-attachments/assets/3e2acf3e-7ec1-42dd-ac47-97b876746d3e" width="300"> |
| **Roll**      | Tilting the Adafruit Circuit Playground left or right to control roll.                      | <img src="https://github.com/user-attachments/assets/10ce97eb-27b1-4923-b2a4-57c792c0a2e9" width="300"> |

*Table 1: Pitch and Roll controls with the Adafruit Circuit Playground.*

</div>

---

#### Throttle and Yaw/Rudder Controls

<div align="center">

| Slider Position | Control            | Description                                                 | Image                                                                                              |
|------------------|--------------------|-------------------------------------------------------------|----------------------------------------------------------------------------------------------------|
| **(-)**          | **Button B**       | Increases the throttle.                                     | <img src="https://github.com/user-attachments/assets/5c9daca9-ec98-4256-aec8-2641afcab9ed" width="300" valign="middle"> |
|                  | **Button A**       | Decreases the throttle.                                     |                                                                                                   |
| **(+)**          | **Button B**       | Yaws the craft to the left.                                 | <img src="https://github.com/user-attachments/assets/e6f64769-b98e-4dd4-8606-295f8ca32e76" width="300" valign="middle"> |
|                  | **Button A**       | Yaws the craft to the right.                                |                                                                                                   |

*Table 2: Throttle and Yaw/Rudder controls using the Adafruit Circuit Playground.*

</div>




## Audio
- **3D Sound Effects**: Dynamic audio for missiles and the jet engine, with pitch and volume adjusting based on throttle.
- **Additional SFX**:
  - Enemy Missile lock SFX
  - Explosions
  - Cannon fire
  - Ambiance
  - Music

---

Play **Starfighter** to test your piloting skills, destroy waves of enemies, and achieve the highest score. Choose between traditional keyboard controls or the precision of the Adafruit Circuit Playground for a tailored experience. Engage in immersive gameplay with immersive visuals and 3D audio.

---
Download: https://github.com/Tokey/Starfighter/releases/tag/v12.12.24
