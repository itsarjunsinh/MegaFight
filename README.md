# MegaFight

### University Project | Submitted: April **2019**

MegaFight is a short demo that showcases systemic game design. 

The following characters are in the game:
- Hero (controlled by Player)
- Red Monster (handled by basic state machine)
- Multiple Villagers (uses custom NPC AI)

The player can initiate combat with the Monster anytime by going near it. Player fights the enemy using a turn based combat system.

![Fight Scene](img/Fight.png)

### Systemic Game Design

The villagers travel between different places in the game world. One of the places is the woods where the Monster resides. If a villager ventures alone into it, they will get trapped there. However, when another villager spots someone trapped with the monster then they will run and ask the hero character to save the trapped villager. The NPCs (non-playable characters) are aware of the game world, they interact with each other and the player to make the game dynamic.

![NPC comes to player with quest](img/Quest.png)

The dynamic quest mechanism of this game can be improvised into other games to make them more engaging and increase game replay value.

## Links
[Download](https://github.com/itsarjunsinh/MegaFight/releases/) | [Gameplay on YouTube](https://youtube.com/watch?v=4X1j2HhcJiY).

The project report is available to students upon request.

## Credits
The game is made using Unity 2018.3 and utilises Unity's NavMesh system for NPC character movement. 

The models, textures, skybox are sourced from Adobe, Unity and the Unity Asset Store.
