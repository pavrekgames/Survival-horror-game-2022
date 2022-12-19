# Survival-horror-game-2022
Not full code from my commercial survival horror game Last Visit. The game is available on Steam: https://store.steampowered.com/app/1434910/Last_Visit/

The code has been refactored and complies with the clean code, OOP, and SOLID principles. The code uses some game design patterns.

Used game Design patterns:

* Singleton pattern
* Observer pattern
* Strategy Pattern
* Component Pattern
* Prototype Pattern

Main implementations:

1. Inventory system (Collecting items, Removing items, Updating UI, Using items in tasks).
2. Monsters AI (Following points, Following player depending on distance, light, crouch, visibility, Attacking, Finding possible path, Sounds)
    4 types of monsters : crawler, scarecrow, wolf, spider
3. Tasks system (Adding tasks, Removing tasks, Updating UI, Many various tasks)
4. Notifications system (Showing notifications after adding items, tasks, Interacing with objects, Tutorials)
5. Random jumpscares system (Playing random scary sounds in random time and places, Spawning random monster in random time and place).
6. Player (Movement, jump, Crouch, Taking items, Dragging objects, Pushing objects, Opening objects, Control animations)
7. Player HUD (Stamina bar, compass, using item)
8. Interactive objects system (Opening/Closing door, cupboards, drawers, Dragging and pushing objects)
9. Health system (Player health, Receiving damage, Damage screen effects, Player death)
10. Map
11. Compass
12. Music system (Playing music and turning up/down music in various situations)
13. Notes system (Collecting notes, reading notes, Updating UI, Adding tasks after reading notes)
14. Cursor (Setting correct cursor texture depending on the object)
15. Voice acting and subtitles (Playing voices after various situations and setting subtitles)
16. Screamers system (Playing scary sounds in various situations)

Not in the repository but in the game:

1. Changing language
2. Saving system (Binnary formatter)
3. Game manager
4. Pause menu
5. Options (Graphics settings, music and sounds settings, mouse sensitivity, language)
6. Fast travel system

