# VR Interactive Drawer with Configurable Joint Tutorial

Learn how to create realistic, physics-based drawers that players can pull open and push closed in VR using Unity's XR Interaction Toolkit.

## Overview

This tutorial will teach you how to:
- Set up a drawer with a sliding constraint
- Configure physics for smooth drawer movement
- Make drawers grabbable with VR controllers
- Limit drawer slide distance to prevent it from coming completely out

## Prerequisites

- Unity with XR Interaction Toolkit installed
- A VR scene with XR Rig set up
- A furniture piece with drawers (dresser, desk, cabinet, etc.)

## Understanding the Challenge

Unlike doors that rotate on hinges, drawers need to:
- Slide in ONE direction only (forward/backward)
- Stay aligned (no tilting or rotation)
- Have limited travel distance (can't pull out infinitely)
- Feel smooth and realistic

We'll use a **Configurable Joint** which gives us precise control over which axes can move.

## Step 1: Prepare Your Drawer Model

You'll need a furniture piece with separate drawer GameObjects:

```
DrawerUnit (parent)
├── Cabinet_Body
├── Drawer_1 (this is what we'll make interactive)
│   └── Drawer_Handle
├── Drawer_2
├── Drawer_3
└── Drawer_4
```

**Important:** Each drawer should be a separate GameObject, not part of the cabinet mesh.

## Step 2: Add Required Components

Select your drawer GameObject and add these three components:

### A. Rigidbody Component
Click **Add Component** → **Physics** → **Rigidbody**

### B. Configurable Joint Component
Click **Add Component** → **Physics** → **Configurable Joint**

### C. XR Grab Interactable Component
Click **Add Component** → **XR** → **XR Grab Interactable**

## Step 3: Configure the Rigidbody

Configure the Rigidbody component with these settings:

```
Mass: 2
Drag: 2
Angular Drag: 10
Use Gravity: FALSE (unchecked)
Is Kinematic: FALSE (unchecked)
```

**Why these settings?**
- **Mass (2)**: Drawers are lighter than doors
- **Drag (2)**: Higher drag for controlled sliding (prevents sliding too fast)
- **Angular Drag (10)**: High value prevents any rotation
- **No Gravity**: Keeps drawer horizontal

## Step 4: Configure the Configurable Joint

This is the most important part! The Configurable Joint has many options - we need to lock all movement EXCEPT the sliding direction.

### Motion Settings

```
X Motion: Locked
Y Motion: Locked
Z Motion: Limited
```

**Understanding the Axes:**
- **X Motion**: Left/Right sliding (we lock this)
- **Y Motion**: Up/Down sliding (we lock this)
- **Z Motion**: Forward/Backward sliding (we allow this with limits)

**Important:** Determine which axis your drawer slides along in your model!
- If your drawer slides along X instead of Z, set `X Motion: Limited` and `Z Motion: Locked`
- Use the Scene view to determine the correct axis

### Rotation Settings

Lock all rotations to prevent the drawer from tilting:

```
Angular X Motion: Locked
Angular Y Motion: Locked
Angular Z Motion: Locked
```

### Linear Limit (Controls How Far Drawer Opens)

Click on **Linear Limit** to expand:

```
Limit: 0.4 (adjust based on your drawer depth)
Bounciness: 0
Contact Distance: 0
```

**Setting the Right Limit Value:**
- This value is in Unity units (meters)
- `0.4` allows the drawer to slide 40cm (about 16 inches)
- Measure your drawer's depth and set accordingly:
  - Shallow drawer: `0.2 - 0.3`
  - Standard drawer: `0.4 - 0.5`
  - Deep drawer: `0.6 - 0.8`

### Other Joint Settings

You can leave these at defaults, but here are recommended values:

```
Connected Body: None (leave empty for "connected to world")
Auto Configure Connected Anchor: TRUE (checked)
Break Force: Infinity
Break Torque: Infinity
Enable Collision: FALSE
Enable Preprocessing: TRUE
```

## Step 5: Configure XR Grab Interactable

Select your drawer and configure the XR Grab Interactable component:

```
Movement Type: Kinematic
Track Position: FALSE (unchecked)
Track Rotation: FALSE (unchecked)
Throw On Detach: FALSE (unchecked)
```

**Why these settings?**
- **Kinematic Movement**: Works smoothly with joints
- **No Tracking**: The joint controls movement, not direct hand tracking
- **No Throwing**: Prevents unrealistic drawer yanking

### Optional: Set Grab Points

For better interaction, you can configure specific grab points:

1. Expand **Interactor Settings**
2. Add a child GameObject at the drawer handle
3. Reference it in **Attach Transform**

## Step 6: Test Your Drawer

1. Enter Play Mode
2. Use your VR controllers (or XR Device Simulator)
3. Grab the drawer handle with the grip button
4. Pull toward you to open
5. Push away to close
6. Release to let go

### Troubleshooting

**Drawer falls down or moves in wrong direction:**
- Check that "Use Gravity" is OFF
- Verify you locked the correct axes
- Make sure the correct axis is set to "Limited" (not "Free")

**Drawer pulls completely out:**
- Check the Linear Limit value
- Ensure Z Motion (or whichever axis) is set to "Limited" not "Free"
- Try reducing the Limit value

**Drawer feels too loose or wobbly:**
- Increase Drag to 3-5
- Increase Angular Drag to 15-20
- Check that all angular motions are "Locked"

**Drawer moves too stiffly:**
- Reduce Drag to 1
- Reduce Mass to 1
- Check Linear Limit settings

**Can't grab the drawer:**
- Ensure XR Grab Interactable is added
- Check that the drawer has a Collider component
- Verify your XR controllers are set up correctly
- Try adding a larger collider to the drawer handle

**Drawer goes through the furniture:**
- Ensure the cabinet body has colliders
- Check that "Enable Collision" is FALSE on the joint (to avoid joint conflicts)
- Adjust the Collision Detection on Rigidbody to "Continuous Dynamic"

## Step 7: Add Multiple Drawers

To make all drawers in your furniture piece interactive:

1. Repeat steps 2-5 for each drawer
2. Each drawer is independent and can be configured separately
3. Consider different slide distances for different drawer sizes

### Quick Tip: Copy Components
1. Set up one drawer completely
2. Right-click the component → **Copy Component**
3. Select other drawers
4. Right-click → **Paste Component Values**
5. Adjust individual settings as needed

## Advanced Tips

### Add Soft Close Feature

To make drawers slowly close the last bit:

1. In Configurable Joint, expand **Linear Limit Spring**
2. Enable spring behavior:
   ```
   Spring: 50
   Damper: 5
   ```
3. Set a target position to pull toward closed

### Add Drawer Stops/Notches

To create drawers that "snap" to open or closed:

1. Add position markers (invisible triggers)
2. Use Unity Events to detect when drawer reaches certain positions
3. Adjust Spring and Damper values dynamically

### Add Sound Effects

1. Add an **Audio Source** component to the drawer
2. Assign sliding/open/close sounds
3. Play sounds based on drawer velocity or position
4. Example sounds: slide rumble, latch click, bump

### Lock Drawers

To create locked drawers:

1. Disable the XR Grab Interactable component
2. Add a visual indicator (lock icon, red light)
3. Enable the component when player uses a key

## Understanding Configurable Joint Axes

Visual guide to understanding which axis to use:

```
Front View of Drawer:
    Y (up)
    |
    |_____ X (right)
   /
  Z (forward - toward player)
```

**Common Configurations:**
- **Drawers pulling toward you:** Z Motion = Limited
- **Side-sliding drawers:** X Motion = Limited
- **Vertical drawers (weird but possible):** Y Motion = Limited

## Common Drawer Types

### Standard Front-Opening Drawer
```
X Motion: Locked
Y Motion: Locked
Z Motion: Limited (0.4)
All Rotations: Locked
```

### File Cabinet Drawer (deeper)
```
X Motion: Locked
Y Motion: Locked
Z Motion: Limited (0.7)
All Rotations: Locked
Drag: 3 (heavier feel)
Mass: 4 (file folders are heavy!)
```

### Jewelry Drawer (shallow, smooth)
```
X Motion: Locked
Y Motion: Locked
Z Motion: Limited (0.15)
All Rotations: Locked
Drag: 1 (very smooth)
Mass: 0.5 (light)
```

## Summary

You've successfully created VR interactive drawers! Key takeaways:

✅ Drawers need Rigidbody (non-kinematic) for physics
✅ Configurable Joint restricts movement to one sliding axis
✅ Lock 5 axes, limit 1 axis for perfect drawer behavior
✅ Linear Limit prevents drawer from coming completely out
✅ XR Grab Interactable makes it grabbable in VR

## Comparison: Configurable Joint vs Hinge Joint

| Feature | Configurable Joint | Hinge Joint |
|---------|-------------------|-------------|
| Best For | Linear sliding (drawers, sliding doors) | Rotation (doors, levers) |
| Axes Control | Full control over all 6 degrees of freedom | Only rotation around one axis |
| Complexity | More settings to configure | Simpler setup |
| Use Case | Drawers, sliders, sliding doors | Swinging doors, levers, valves |

## Next Steps

- Create sliding cabinet doors using the same technique
- Make a secret drawer that requires two drawers to be opened first
- Add a drawer organization system with dividers
- Create a drawer that locks when another drawer is open

Happy VR development!
