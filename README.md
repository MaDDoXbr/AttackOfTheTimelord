# "Attack of the Timelord" for Unity3D

![Aottl_Unity](https://user-images.githubusercontent.com/265085/139162999-0f5ea6ae-32e4-4427-9da0-5f2cb1bd8ca8.png)

This is a remake of the "Attack of the Timelord" game for the Magnavox Odyssey2 classic console, made in Unity3D. It uses submodules for multiple external libraries, like NaughtyAttributes and EzMsg, and applies a number of advanced coding architecture techniques, like Dependency Injection, UI scene separation, Visual Scripted FSMs, ScriptableObject Singletons and events.

*Instructions:*

1. Open Scenes/Game
2. Drag Scenes/UI to the Hierarchy
3. Add a new Aspect Ratio to the game view, 2:1
4. Hit Play

The project applies: 
* UVS (Unity Visual Scripting) State Machines, taking and sending messages to C# scripts and firing up Animator events
* Animator for the spaceship's charge animations
* ScriptableObject-Architecture to setup the Game Manager and also for static game events (touching only pre-instantiated gameObjects)
* EzMsg for dynamic gameObjects messaging
* Syrinj for Dependency Injection
* Multi-scene game/UI scene setup & communication

Disclaimer: This is a fan-made game developed for educational purposes. That said, feel free to reuse the more-than-simplistic included art in your own projects. Developed and Tested on Unity *2021.1.16f1*

You're welcome to contribute to the project by creating a pull request. Enjoy.

- Breno Azevedo (@brenoazevedo)
@FluidPlay
