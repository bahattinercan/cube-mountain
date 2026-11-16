# Cube Mountain

Cube Mountain is a 3D hyper-casual cube stacking runner game prototype developed in Unity. The player maneuvers a character riding atop a tower of stacked cubes along a forward-scrolling obstacle course track. Players steer left and right using a virtual joystick to gather collectible cubes that elevate the player's position, avoid or sacrifice cubes against red obstacle barriers, leave a painted trail along the ground surface, and collect floating crystals. Upon crossing the primary finish line, the player enters a bonus speed section where traversing multiplier blocks scales accumulated gems before advancing to subsequent levels or prompting a retry. This project is a personal prototype and demo project, not a maintained product, with the last substantial work committed in 2022.

## Gameplay

- **Continuous Movement & Joystick Steering**: Automatically advances the player forward while applying horizontal steering via a virtual floating joystick and clamping position between lane boundaries (`Assets/Scripts/Movement.cs`).
- **Cube Pickup & Vertical Stacking**: Detects collectable cube pickups, parents them underneath the player's main cube, and increments the vertical stack height (`Assets/Scripts/Collector.cs`, `Assets/Scripts/CollectableCube.cs`).
- **Obstacle Collisions & Cube Loss**: Discards stacked cubes and lowers player height when impacting obstacle barriers, ending the run in defeat if an obstacle hits the player without supporting cubes (`Assets/Scripts/Collector.cs`, `Assets/Scripts/CollectableCube.cs`, `Assets/Scripts/CheckForObstacle.cs`).
- **Dynamic Trail Painting**: Generates continuous line renderer ribbon trails along the floor behind the player while riding cubes, pausing paint generation when traversing obstacle surfaces (`Assets/Scripts/LineDraw.cs`, `Assets/Scripts/LineGenerator.cs`, `Assets/Scripts/LineGeneratorForPlayer.cs`).
- **Gem Collection & Scoring**: Collects floating gems with randomized point yields, accumulating round gems as well as persistent total gem tallies (`Assets/Scripts/Gem.cs`, `Assets/Scripts/GameManager.cs`, `Assets/Scripts/CristalText.cs`).
- **Finish Line & Multiplier Zones**: Doubles player forward speed upon crossing the finish line and applies bonus multiplier values to round gems when passing multiplier obstacles (`Assets/Scripts/FinishLine.cs`, `Assets/Scripts/MultiplierFinishLine.cs`, `Assets/Scripts/GemMultiplierObstacle.cs`).
- **Level Progression & Persistence**: Progresses across five levels (`Level1` through `Level5`), cycling back upon reaching the maximum level count and persisting player level and gem totals (`Assets/Scripts/GameManager.cs`, `Assets/Scripts/EPlayerPrefs.cs`).
- **UI & Level Completion Tracking**: Displays level completion percentage via an image fill slider based on track distance, toggles score panels, and displays next-level or try-again overlays (`Assets/Scripts/LevelCompletePercentSlider.cs`, `Assets/Scripts/LevelCompletePanel.cs`, `Assets/Scripts/NextLevelPanel.cs`, `Assets/Scripts/TryAgainPanel.cs`, `Assets/Scripts/UIManager.cs`, `Assets/Scripts/MainMenuUI.cs`).
- **Audio Feedback**: Triggers sound effects and audio tracks for crystal collection, cube pickups, cube loss, landing impacts, and level completion/defeat states (`Assets/Scripts/SoundManager.cs`, `Assets/Scripts/GameEvents.cs`).
- **Obstacle Cleanup & Object Rotation**: Deactivates traversed obstacle game objects upon contact and rotates gem items continuously with randomized speed and direction (`Assets/Scripts/Cleaner.cs`, `Assets/Scripts/Rotate.cs`).
- **Smooth Camera Tracking**: Interpolates camera position following the target cube tower using lerped distance offsets (`Assets/Scripts/CameraFollow.cs`).

## Tech Stack

- **Game Engine**: Unity
- **Engine Version**: `2020.3.36f1` (declared in `ProjectSettings/ProjectVersion.txt`)
- **Scripting Language**: C# (.NET / Mono)
- **Key Dependencies & Packages** (declared in `Packages/manifest.json`):
  - `com.unity.textmeshpro` (`3.0.6`) — UI text rendering
  - `com.unity.device-simulator` (`3.0.3-preview`) — Device screen emulation in editor
  - `com.unity.ugui` (`1.0.0`) — Unity UI system
  - `com.unity.timeline` (`1.4.8`) — Timeline sequencing tools
  - `com.unity.test-framework` (`1.1.31`) — Unity Test Runner framework

## Project Structure

| Path | Contents | Classification |
| --- | --- | --- |
| `Assets/Scripts/` | C# scripts for player movement, cube collection, collision detection, line drawing, audio, and UI management | Own code |
| `Assets/Scenes/` | Unity scene files: `MainMenu.unity` and `Level1.unity` through `Level5.unity` | Data (Scenes) |
| `Assets/Prefabs/` | Prefab templates for player, collectible cubes, gems, line generators, obstacles, environment, and canvas UI | Data (Prefabs) |
| `Assets/Materials/` | Unity material and shader assets for sky, ground, clouds, crystals, cubes, and line renderers | Data (Materials) |
| `Assets/Models/` | 3D FBX mesh models (`gems.fbx`, `UpgradedCube.fbx`) | Data (3D Models) |
| `Assets/Animations/` | Animation controllers and clips (`Image.controller`, `playButtonIdle.anim`) | Data (Animations) |
| `Assets/Sounds/` | Sound effect audio files (`.wav`, `.mp3`) for pickups, collisions, win, and lose feedback | Data (Audio) |
| `Assets/Sprites/` | 2D UI texture assets and button icons | Data (Sprites) |
| `Assets/Packages/` | Vendored third-party assets (UI kits, skyboxes, joystick controller, and character samples) | Third-party |
| `Packages/` | Unity Package Manager manifest (`manifest.json`) and package lockfile | Configuration |
| `ProjectSettings/` | Unity editor project settings (build scenes, tag manager, graphics, input, quality) | Configuration |

## Running / Building

### Prerequisites
- Install **Unity Hub**.
- Install **Unity Editor version 2020.3.36f1** (configured with the Android Build Support or Standalone Build Support module depending on target platform).

### Opening the Project
1. Open **Unity Hub**.
2. Click **Open** or **Add** and select the repository root directory (`C:/Orca/gh-clones/cube-mountain`).
3. Select Unity Editor version **2020.3.36f1** if prompted.
4. Allow Unity to import project assets and compile scripts.

### Entry Scene & Running in Editor
- The entry scene configured at index 0 in `ProjectSettings/EditorBuildSettings.asset` is `Assets/Scenes/MainMenu.unity`.
- Open `Assets/Scenes/MainMenu.unity` from the Project browser (`Assets > Scenes > MainMenu.unity`).
- Click the **Play** button in the Unity Editor toolbar to enter Play Mode.
- Clicking the play button in the main menu loads `Assets/Scenes/Level1.unity` (or the level stored in player preferences) via `MainMenuUI.cs`.

### Building
1. In the Unity Editor, open **File > Build Settings...**.
2. Confirm the scenes included in the build match the configuration in `ProjectSettings/EditorBuildSettings.asset`:
   - `Assets/Scenes/MainMenu.unity` (index 0)
   - `Assets/Scenes/Level1.unity` (index 1)
   - `Assets/Scenes/Level2.unity` (index 2)
   - `Assets/Scenes/Level3.unity` (index 3)
   - `Assets/Scenes/Level4.unity` (index 4)
   - `Assets/Scenes/Level5.unity` (index 5)
3. Select your target platform (e.g. **PC, Mac & Linux Standalone** or **Android**).
4. Click **Build** and choose an output destination directory.

## Repository Notes

- **Testing**: No automated unit or integration tests are implemented in the repository, although the Unity Test Framework package is referenced in the manifest.
- **CI/CD**: No continuous integration or automated build pipelines (such as GitHub Actions) are configured.
- **Commit History**: The repository consists of a single initial commit snapshot representing the project at the conclusion of prototyping.
- **Prototype Scope**: This project is a hyper-casual game development prototype created for learning and experimentation rather than a production-ready application.
- **Verification Note**: Repository contents and project configurations were verified via static code analysis; the project has not been compiled or executed during this inspection.

## Third-Party Assets

| Asset Folder | Description | Licence File Present |
| --- | --- | --- |
| `Assets/Packages/2D Casual UI` | UI sprites, buttons, and graphics for mobile casual games | No licence file in repo |
| `Assets/Packages/FreeButtonSet` | UI button sprite assets | No licence file in repo |
| `Assets/Packages/GradientSky` | Skybox materials, shaders, and textures (includes `ReadMe - GradientSky.txt`) | No licence file in repo |
| `Assets/Packages/GUI Mobile Hyper-Casual` | Hyper-casual mobile GUI sprites, frames, and buttons | No licence file in repo |
| `Assets/Packages/JMO Assets` | Toony Colors shader pack and materials (includes `!ToonyColors Readme.txt`) | No licence file in repo |
| `Assets/Packages/Joystick Pack` | Mobile virtual on-screen joystick components | No licence file in repo |
| `Assets/Packages/SimpleSky` | Skybox shaders and textures (includes `ReadMe.txt`) | No licence file in repo |
| `Assets/Packages/Supercyan Character Pack Free Sample` | Low-poly humanoid character model, materials, and animations | No licence file in repo |
| `Assets/Packages/TextMesh Pro` | TextMesh Pro font assets and default resources (includes `LiberationSans - OFL.txt` SIL Open Font License and `EmojiOne Attribution.txt`) | Yes (`LiberationSans - OFL.txt`) |
| `Assets/Packages/Tree_Textures` | 2D foliage and tree textures | No licence file in repo |
