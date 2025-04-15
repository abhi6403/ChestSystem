Chest System – Unity Project

This project is a modular and scalable Chest System developed in Unity, designed with a strong focus on clean architecture and design patterns.

🔧 Architecture & Design Patterns:

MVC Pattern: Implemented for both the Chest and Player systems to ensure a clear separation of concerns and maintainability.

Dependency Injection: Utilized for managing dependencies in the UI layer and Chest logic, promoting testability and decoupling.

Observer Pattern: Applied to efficiently handle event-driven systems, making it easy to react to chest interactions and state changes.

Command Pattern: Used to implement an Undo functionality, allowing an unlocked chest to be reverted back to a locked state.

Singleton Pattern: Integrated for global systems like Audio Management, ensuring centralized and persistent sound control.

🧰 Chest Types & Customization:
The system supports four chest types:

Common Chest
Rare Chest
Epic Chest
Legendary Chest

Each chest contains randomly generated coins and gems, enhancing gameplay variability.

ScriptableObjects are used for chest configuration, allowing flexible customization of chest attributes (e.g., unlock duration, rewards).

🔄 Chest State Management:
A robust State Machine manages the chest lifecycle, with well-defined states including:

LockedState
UnlockingState
UnlockedState
CollectedState

This structure not only facilitates easy state transitions but also allows for future scalability (e.g., adding new chest behaviors).
