
# FrequencyDefector

Music based First Person Shooter.


## Performance update

Optimization changes:
- Changed musicPillar prefab from "5 quad prefab objects" to one meshed object modeled in blender. (reduced amount of batches)
- Turned cast-shadows off for music pillars (I'm focused more on light reflection rather than shadow casting which is not even noticable in such dynamic game).
- Added audioMixer to manage and separate music audio for audioListener from the audio clip for pillar generation to let the player lower the volume of the actual music while not reducing pillar movement at all.
Small changes:
- Added settings menu with volume sliders, graphics drop-down menu and "back to main menu" button.
- Added "Are you sure" text in main menu before starting a new game.
- Switched from "PerlinNoise based" musicPillar randomness generation to "Random.Range(x,x) based" generation.

Link to the actual preview of mentioned before changes:
https://youtu.be/NDHf1yaLD7o


## MapGenerator v3.1

Big changes in version 3.1:
- Optimized generation of blocks and musicPillars.
- Possibility to turn on/off roof and floor.
- musicPillars jump to music.

Link to the presentation of the generator:
https://www.youtube.com/watch?v=MlNXsXFx_po


## Authors

- [@0nullptr0](https://github.com/0nullptr0)

