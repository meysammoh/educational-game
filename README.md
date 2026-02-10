> **⚠️ Archived Project (2014)** — This is a historical portfolio piece, not actively maintained. Not recommended for forking or production use.

# Educational Game - Math Learning with Physics (2014)

A 2D educational game built with Unity where mathematical equations drop from hooks, and players must match them to the correct "function machines" based on logical conditions.

<a href="https://www.youtube.com/watch?v=NKbL4xvNkYI" target="_blank">
  <img src="https://img.youtube.com/vi/NKbL4xvNkYI/0.jpg" alt="Demo Video">
</a>

*Click image to watch demo video*

## Overview

This educational game teaches mathematical reasoning and quick decision-making. Equations appear on bundles hanging from animated crane hooks. Players select bundles and drag them to function machines that evaluate whether the equation matches a specific condition (equals, greater than, or less than a target value).

**Development Period:** January 2014
**Platform:** Windows (with potential for cross-platform deployment)
**Target Audience:** Elementary/middle school students learning math operations

## Game Mechanics

### Core Gameplay
1. **Equation Spawning:** Math equations drop from animated hooks/cranes at timed intervals
2. **Physics-Based:** Bundles swing realistically using Unity's 2D physics (HingeJoint2D)
3. **Selection System:** Click an equation bundle to select it
4. **Matching:** Click a function machine to evaluate if the equation satisfies its condition
5. **Feedback:**
   - ✓ Correct match: Confirmation sound, equation disappears
   - ✗ Wrong match: Error sound, equation remains
6. **Time Pressure:** Equations have a 15-second lifetime before disappearing

### Function Machines
Each machine has a logical condition displayed in Farsi numerals:
- **Equality:** `=5` (equation result must equal 5)
- **Greater Than:** `>10` (equation result must be greater than 10)
- **Less Than:** `<20` (equation result must be less than 20)

### Equation Types
Supports basic arithmetic operations:
- Addition: `2+3`
- Subtraction: `7-4`
- Multiplication: `3*5`
- Division: `12/3`
- Combined: `2+3*4-1`

## Technical Stack

### Game Engine
- **Unity:** Version 4.3.0f4 (2013-2014 era)
- **Language:** C# (.NET Framework)
- **Physics:** Unity 2D Physics Engine
- **Audio:** Unity AudioSource system

### Key Features
- **2D Physics Simulation:** Realistic swinging motion with HingeJoint2D
- **Farsi Number Rendering:** Custom sprite-based number system for Persian/Arabic numerals
- **Equation Parser:** Evaluates mathematical expressions at runtime
- **Animation System:** Unity Mecanim animator for hook/crane movement
- **State Management:** Game manager pattern for level progression

### Build Configuration
- **Target Platform:** Windows Standalone
- **Resolution:** Configurable (windowed/fullscreen)
- **API Compatibility:** .NET 2.0
- **Scripting Backend:** Mono

## Project Structure

```
EducationalGame/
├── Assets/
│   ├── Animations/          # Unity animation clips
│   │   └── HookChain.anim   # Hook/crane movement
│   ├── Images/              # Background and UI images
│   ├── Resources/           # Prefabs and runtime resources
│   │   └── Prefabs/
│   │       ├── Hooker       # Hook/crane prefab
│   │       └── Bundle       # Equation bundle prefab
│   ├── Scenes/              # Unity scenes
│   │   └── MainScene.unity  # Main game scene
│   ├── Scripts/             # C# game logic
│   │   ├── GameLogic.cs             # Core game controller
│   │   ├── Equation.cs              # Equation bundle component
│   │   ├── FunctionMachine.cs       # Machine logic and evaluation
│   │   ├── FarsiEquationGenerator.cs # Farsi number renderer
│   │   ├── EquationCleaner.cs       # Cleans expired equations
│   │   ├── MainSceneManager.cs      # Scene initialization
│   │   └── Smoke.cs                 # Visual effects
│   ├── Sounds/              # Audio files
│   │   ├── confirm.wav      # Correct answer sound
│   │   └── error.wav        # Wrong answer sound
│   └── Sprites/             # Sprite assets
│       ├── Numbers/         # Farsi numeral sprites (0-9)
│       ├── Operators/       # Math operator sprites (+,-,*,/,=,<,>)
│       ├── Machines/        # Function machine graphics
│       └── Props/           # Hook, rope, bundle graphics
├── Builds/
│   └── windows/             # Windows standalone build
│       └── edugame.exe      # Compiled executable
├── Library/                 # Unity cache (excluded from Git)
├── ProjectSettings/         # Unity project configuration
│   └── ProjectSettings.asset
└── EducationalGame.sln      # Visual Studio solution
```

## Key Components

### GameLogic.cs
**Purpose:** Main game controller
**Responsibilities:**
- Spawns equations from hooks at timed intervals
- Manages equation lifecycle (15-second timeout)
- Handles equation/machine selection
- Controls hook movement speed
- Maintains equation queue

**Key Parameters:**
- `timeBetweenSpawn`: Delay between equation spawns (default: 4 seconds)
- `hookMovingSpeed`: Animation speed of hooks (default: 1x)
- `equationList`: Array of equations to present

### Equation.cs
**Purpose:** Individual equation bundle behavior
**Features:**
- Evaluates mathematical expressions
- Tracks selection state
- Manages lifetime timer
- Attached to physics-enabled GameObject with HingeJoint2D

### FunctionMachine.cs
**Purpose:** Target machines that evaluate equations
**Logic:**
- Compares equation result to machine's condition
- Plays audio feedback (correct/error)
- Destroys matched equations
- Displays condition in Farsi numerals

### FarsiEquationGenerator.cs
**Purpose:** Renders equations using Farsi number sprites
**Features:**
- Converts text equations to visual GameObjects
- Sprite-based rendering for Persian/Arabic numerals
- Supports all mathematical operators
- Configurable colors (digits vs operators)
- Dynamic sizing and scaling

## Building the Project

### Prerequisites
- **Unity 4.3.0f4** (or compatible version like Unity 4.x)
- **Operating System:** Windows 7/8/10 (for Unity 4.x compatibility)
- **.NET Framework 3.5** or higher

### Opening the Project
```bash
1. Download Unity 4.3.0f4 from Unity Archive
2. Open Unity
3. File → Open Project
4. Select EducationalGame folder
5. Wait for Unity to import assets
```

### Building Standalone Executable
```bash
1. In Unity: File → Build Settings
2. Select "PC, Mac & Linux Standalone"
3. Platform: Windows
4. Architecture: x86 or x86_64
5. Click "Build" and choose output folder
6. Run the generated .exe file
```

### Running Pre-built Version
A pre-compiled Windows build exists in `Builds/windows/`:
```bash
cd Builds/windows
edugame.exe
```

## Game Configuration

### Editing Equations
Open `GameLogic.cs` and modify the `equationList` array:
```csharp
public string[] equationList = {
    "5+3",    // Simple addition
    "12-7",   // Subtraction
    "4*6",    // Multiplication
    "20/5",   // Division
    "2+3*4"   // Order of operations
};
```

### Adjusting Difficulty
Modify timing parameters in `GameLogic.cs`:
```csharp
public float timeBetweenSpawn = 4;  // Decrease for harder
public float hookMovingSpeed = 1;   // Increase for faster
```

In `Equation.cs`:
```csharp
go.GetComponent<Equation>().lifeTime = 15;  // Equation timeout (seconds)
```

### Setting Up Function Machines
In Unity editor, add FunctionMachine components with equations:
- `=5` (equals 5)
- `>10` (greater than 10)
- `<20` (less than 20)

## Educational Design

### Learning Objectives
- **Mental Math:** Quick evaluation of arithmetic expressions
- **Logical Reasoning:** Understanding comparison operators (=, <, >)
- **Decision Making:** Choosing correct targets under time pressure
- **Order of Operations:** Evaluating complex expressions (PEMDAS)

### Progression System
- Start with simple single-operation equations
- Gradually introduce multi-operation expressions
- Increase spawn rate to add time pressure
- Mix different function machine types

### Farsi/Persian Language Support
The game uses custom sprite-based rendering for Farsi numerals, making it suitable for:
- Persian-speaking students (Iran, Afghanistan, Tajikistan)
- Arabic-speaking students (with similar numeral systems)
- Bilingual education programs

## Technical Highlights

### Physics Integration
- **Realistic Swinging:** HingeJoint2D connects bundles to hooks
- **Gravity Effects:** Bundles respond to 2D gravity
- **Collision Detection:** OnMouseUp events for selection

### Custom Number System
Instead of Unity's TextMesh, uses sprite-based rendering:
- Maintains visual consistency
- Supports right-to-left reading
- Customizable colors per digit/operator
- Scalable without quality loss

### Animation System
- Unity Mecanim animator controls hook movement
- Adjustable speed via scripting
- Synchronized with equation spawning

## Version History

**2014-01-15:** Final Visual Studio solution update
**2014-01-14:** Sprite system finalized
**2014-01-13:** Windows build created
**2014-01-04:** Resources and prefabs organized
**2014-01-03:** Initial project setup, core scripts implemented

## Known Limitations

### Unity 4.x Era Project
This project uses Unity 4.3.0f4 from 2014. Modern Unity versions may have compatibility issues:
- **Script API Changes:** Some Unity APIs deprecated in 5.x+
- **Physics Changes:** Unity 5+ changed 2D physics API slightly
- **Build System:** Asset serialization format differs

## Skills Demonstrated

| Category | Skills |
|----------|--------|
| **Game Development** | Unity 4.x, C#, 2D game design |
| **Physics Programming** | HingeJoint2D, Rigidbody2D, collision detection |
| **Localization** | Custom Farsi/Persian numeral rendering system |
| **Educational Design** | Gamification, adaptive difficulty, learning objectives |
| **Expression Parsing** | Runtime math evaluation, operator precedence |
| **Animation** | Unity Mecanim, scripted animation control |

## License

MIT License (see LICENSE file)

## Credits

**Development:** January 2014
**Engine:** Unity 4.3.0f4
**Language:** Farsi/Persian number system
**Target:** Elementary/middle school mathematics education

---

*Archived 2014 Unity project demonstrating educational game development, 2D physics, Farsi localization, and math expression parsing.*
