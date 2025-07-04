---
title: Game Actions
sidebar:
  label: " - Game Actions"
---

In this activity you want to demonstrate that you can use classes, inheritance, and polymorphism to create a more dynamic program. Supporting new higher level abstractions.

## Scenario

To play around with inheritance and polymorphism, let's build some game mechanics that would allow you to apply effects to a game entity. Using this we can add the ability to control the game entity

## Creating Game Entity

We need something to apply effects to. This will be our game entity. For now, it will just have a public location (x, y) and will be able to draw itself as a circle.

```txt
Class: Game Entity
Fields:
 - x: double representing horizontal location (public)
 - y: double representing vertical location (public)
Constructors:
  - Default: set x, y to be set values
  - Game Entity (x, y) -- initialise the player's x and y.
Methods: 
 - Draw: draws a circle at the game entity's location (you pick size)
```

```txt
Function: Main
Variables:
  - player: Game Entity
Steps:
  - Open a window
  - Create the player in the centre of the window
  - While not quit requested:
    - Process events
    - Clear screen
    - Draw the player
    - Refresh screen
```

Before continuing make sure that this runs and that you can see the player on the screen.

## Creating Entity Effects

An effect will be something that can change the entity. We will create this as an abstract class as we do not know what the effect will be... there will be several different effects that can be applied. The idea will be to maintain a list of effects, and apply these each time through the game loop. Individual effects can work out if and how they are applied to the entity.

```txt
Class: Entity Effect <<abstract>>
Methods: 
 - Perform(Game Entity): check and perform the effect on the entity. <<abstract>>
```

As a test, create two specific actions:

```txt
Class: Keyboard Move Effect
Inherits: Entity Effect
Fields:
  - left key: key code of the key that decreases the entity's x field. (public)
  - right key: key code of the key that increases the entity's x field. (public)
  - delta: a double representing the amount to move (public)
Methods:
  - Perform(Game Entity): if the left/right keys are down, adjust the entity's
                          x by +/- delta
```

Create a second effect that also updates the entity's location. For example, you could add a wind effect that adds a constant value (+/-) to the entity's x and y values each time it is performed. Alternatively, you could add a mouse position entity effect that moves the player to the mouse's location when the left button is clicked, or any other movement action.

## Performing the Actions

In main, create an array (ideally a dynamic array using your code dynamic array class) of entity effect object pointers. Populate it with an object from each of the classes you have created (2 objects).

Within your game loop, add a loop to perform each of the entity effects with the player's game entity. Check that you are able to get both effects to be applied to the player. Can you move it left/right, and does your effect get applied as it should?

## Extensions

At this point there are a couple of ways we can extend this.

1: We should move the effects into the game entity. It could have a list of effects that apply to it, and then we can add an `update` method that will perform all the effects when called.
2: Extend the game entity with a size or color, and then you can look at effects that apply to something other than the location of the entity.

Have a go at coding up at least one of these options. That will help you think about how objects works, and the ways we may interact with this kind of code.
