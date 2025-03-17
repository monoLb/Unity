# Unity Survivor-like Game

[![Unity Version](https://img.shields.io/badge/Unity-2021.3%2B-blue.svg)](https://unity3d.com)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A roguelite survival shooter inspired by Brotato, featuring a dynamic pentagram attribute visualization system built with Unity's LineRenderer.

## ✨ Core Features

### 🎮 Gameplay Essentials
- **Auto-Aim Combat**: Character automatically attacks nearest enemies
- **Procedural Waves**: 20+ enemy types with evolving spawn patterns
- **Roguelite Progression**: 50+ upgradable abilities with synergistic combinations
- **Endless Mode**: Survive increasingly difficult waves for high scores

### ⭐ Pentagram Attribute System
![Pentagram Visualization](Docs/PentagramDemo.gif)

| Feature                | Technical Implementation                          |
|------------------------|---------------------------------------------------|
| Dynamic Geometry       | Real-time vertex position calculation based on 5 stats |
| Color-Coded Attributes | Vertex color mapping using HSV gradient interpolation |
| Interactive Tooltips   | UI raycast detection with attribute value popups  |
| Performance Optimized  | Mesh-based LineRenderer with UV animation         |
