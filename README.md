# Into the Mainframe

Unity project created for «Начни Игру» 2024 

## Tech Stack

- Async: UniTask 
- DI: VContainer
- Messaging: MessagePipe 
- Tweening: DOTween
- UI: TextMeshPro
- Assets: QuickOutline, Mini First Person Controller

## Architecture 

- Dependency Injection for service wiring and lifetime management
- Pub/sub message bus for decoupled systems
- Data-driven design using ScriptableObjects
- Object pooling for audio emitters
- Async gameplay flow with UniTask
- Modular systems: 
    - UI / Screens
    - Player / Movement
    - Platform systems
    - Node / Remote controller systems
    - Audio

## Project Structure

This repository contains gameplay and architecture code only.
Art assets, scenes, and third-party content were excluded

## Links
- [Play WebGL](https://bakilin.github.io/JunkStyle/)
