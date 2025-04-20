# 🎮 Counter-Strike Style FPS Game (Unity 6)

A single-player first-person shooter inspired by **Counter-Strike**, developed in **Unity 6**. Features custom player movement, AI-powered bots using Unity's NavMesh system, and core combat mechanics.

---

## 🔧 Features

- ✅ Custom First-Person Controller (WASD + Mouse)
- ✅ Player jump, shooting, and footstep audio
- ✅ AI Bots with NavMesh pathfinding
- ✅ Map imported from `.glb` model (e.g., de_dust2 clone)
- ✅ Simple weapon system
- 🚫 No multiplayer (single-player only for now)

---

## 🎮 Controls

| Action       | Key/Mouse        |
|--------------|------------------|
| Move         | `W A S D`        |
| Look Around  | `Mouse Movement` |
| Jump         | `Space`          |
| Fire         | `Left Click`     |

---

## 📁 Project Structure

Assets/ ├── Scripts/ │ ├── PlayerMovement.cs │ ├── BotAI.cs │ ├── AudioManager.cs │ └── GunController.cs ├── Models/ │ └── de_dust2.glb ├── Prefabs/ ├── Scenes/ └── Audio/
