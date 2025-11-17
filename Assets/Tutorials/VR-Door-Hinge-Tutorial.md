# VR Interactive Door with Hinge Joint Tutorial

Learn how to create a realistic, physics-based door that players can grab and swing open in VR using Unity's XR Interaction Toolkit.

## Overview

This tutorial will teach you how to:
- Set up a door with a proper hinge joint
- Configure physics for realistic door movement
- Make the door grabbable with VR controllers
- Set rotation limits for the door swing

## Prerequisites

- Unity with XR Interaction Toolkit installed
- A VR scene with XR Rig set up
- A door model/prefab (or any object you want to turn into a door)

## Step 1: Create or Place Your Door

1. Add a door object to your scene (or use an existing door prefab)
2. Position it where you want the door to be
   - Example position: `(-2.5, 0, 2.5)`
   - Make sure it's properly sized and oriented

## Step 2: Add Required Components

Select your door GameObject and add these three components:

### A. Rigidbody Component
Click **Add Component** → **Physics** → **Rigidbody**

### B. Hinge Joint Component
Click **Add Component** → **Physics** → **Hinge Joint**

### C. XR Grab Interactable Component
Click **Add Component** → **XR** → **XR Grab Interactable**

## Step 3: Configure the Rigidbody

Configure the Rigidbody component with these settings:

```
Mass: 5
Drag: 0.5
Angular Drag: 5
Use Gravity: FALSE (unchecked)
Is Kinematic: FALSE (unchecked)
```

**Why these settings?**
- **Mass (5)**: Makes the door feel substantial but not too heavy
- **Drag (0.5)**: Adds slight air resistance for smoother movement
- **Angular Drag (5)**: Prevents the door from spinning too freely
- **No Gravity**: Keeps the door in place horizontally

## Step 4: Create a Door Frame Anchor

The hinge joint needs something solid to attach to (the door frame).

1. Create an empty GameObject: **Right-click in Hierarchy** → **Create Empty**
2. Name it: `DoorFrameAnchor`
3. Position it at the hinge point of your door
   - Example: `(-2.9, 1, 2.5)` - this should be at the edge where the door hinges
4. Add a **Rigidbody** component to the anchor
5. Set the anchor's Rigidbody to **Is Kinematic: TRUE**

**Important:** The anchor must be kinematic so it doesn't move!

## Step 5: Configure the Hinge Joint

Select your door and configure the Hinge Joint component:

### Basic Hinge Settings
```
Axis: (0, 1, 0)  [Y-axis for vertical rotation]
Anchor: (-0.4, 0, 0)  [Adjust based on your door's pivot point]
Connected Body: [Drag your DoorFrameAnchor here]
```

**Understanding the Axis:**
- `(0, 1, 0)` = Y-axis rotation (door swings left/right)
- `(1, 0, 0)` = X-axis rotation (door swings up/down - like a drawbridge)
- `(0, 0, 1)` = Z-axis rotation (door spins like a revolving door)

**Understanding the Anchor:**
- The anchor point should be at the edge of the door where the hinges are
- For a door 0.8 units wide, use `(-0.4, 0, 0)` for left hinge
- Adjust the X value based on your door's width

### Enable Rotation Limits
```
Use Limits: TRUE (checked)
Limits:
  - Min: 0
  - Max: 90
  - Bounciness: 0
  - Bounce Min Velocity: 0.2
  - Contact Distance: 0
```

**Why 0 to 90 degrees?**
- This creates a realistic door that swings from closed (0°) to fully open (90°)
- Adjust these values for different door behaviors:
  - Swing door: `Min: -90, Max: 90`
  - Security door: `Min: 0, Max: 45`
  - Rotating door: `Min: -180, Max: 180`

## Step 6: Configure XR Grab Interactable

Select your door and configure the XR Grab Interactable component:

```
Movement Type: Kinematic
Track Position: FALSE (unchecked)
Track Rotation: FALSE (unchecked)
Throw On Detach: FALSE (unchecked)
```

**Why these settings?**
- **Kinematic Movement**: Works well with physics joints
- **No Position/Rotation Tracking**: The hinge joint controls movement, not the hand
- **No Throwing**: Prevents unrealistic door flinging

## Step 7: Test Your Door

1. Enter Play Mode
2. Use your VR controllers (or XR Device Simulator)
3. Grab the door with the grip button
4. Push or pull to swing the door open
5. Release to let go

### Troubleshooting

**Door falls down:**
- Check that "Use Gravity" is OFF on the door's Rigidbody

**Door doesn't move:**
- Ensure the door's Rigidbody is NOT kinematic
- Check that the DoorFrameAnchor's Rigidbody IS kinematic
- Verify the Connected Body is set to your anchor

**Door spins wildly:**
- Increase Angular Drag (try 10-15)
- Check that rotation limits are enabled
- Verify the axis is correct

**Can't grab the door:**
- Ensure XR Grab Interactable is added
- Check that the door has a Collider component
- Verify your XR controllers have XR Ray Interactor or XR Direct Interactor

**Door swings the wrong direction:**
- Flip the Axis values (e.g., change Y from 1 to -1)
- Adjust the Anchor position

## Advanced Tips

### Add Auto-Close Spring
To make the door automatically close:
1. Enable **Use Spring** on the Hinge Joint
2. Set **Spring** value to 50-100
3. Set **Damper** value to 5-10
4. Set **Target Position** to 0

### Add Sound Effects
1. Add an **Audio Source** component to the door
2. Assign door creak/slam sounds
3. Use Unity Events or scripts to play sounds when door opens/closes

### Multiple Doors
- You can reuse the same DoorFrameAnchor for nearby doors
- Or create individual anchors for each door for precise control

## Summary

You've successfully created a VR interactive door! Key takeaways:

✅ Doors need a Rigidbody (non-kinematic) for physics
✅ Hinge Joint connects the door to a fixed anchor point
✅ Limits prevent unrealistic rotation
✅ XR Grab Interactable makes it grabbable in VR
✅ The anchor must be kinematic to stay in place

## Next Steps

- Try creating double doors
- Add a door handle that rotates separately
- Create sliding doors using Configurable Joints
- Add locks or key card systems

Happy VR development!
