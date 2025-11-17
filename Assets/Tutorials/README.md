# VR Interaction Tutorials

Welcome to the VR Interaction Tutorials! These guides will help you create realistic, physics-based interactive objects in Unity using the XR Interaction Toolkit.

## Available Tutorials

### 🚪 [VR Interactive Door with Hinge Joint](VR-Door-Hinge-Tutorial.md)
Learn how to create doors that swing open realistically using Hinge Joints.

**What you'll learn:**
- Setting up physics-based door rotation
- Configuring hinge joints with rotation limits
- Making doors grabbable in VR
- Creating door frame anchors
- Troubleshooting common door physics issues

**Difficulty:** Beginner
**Time:** 15-20 minutes
**Best for:** Swinging doors, gates, hatches, chest lids

---

### 📦 [VR Interactive Drawer with Configurable Joint](VR-Drawer-Sliding-Tutorial.md)
Learn how to create drawers that slide smoothly using Configurable Joints.

**What you'll learn:**
- Setting up linear sliding constraints
- Configuring configurable joints for one-axis movement
- Limiting drawer slide distance
- Making drawers feel realistic
- Understanding joint axes and motion types

**Difficulty:** Intermediate
**Time:** 20-25 minutes
**Best for:** Drawers, sliding doors, sliders, file cabinets

---

## Prerequisites

Before starting these tutorials, make sure you have:

- ✅ Unity 2020.3 or newer
- ✅ XR Interaction Toolkit installed
- ✅ A VR scene with XR Rig configured
- ✅ Basic understanding of Unity GameObjects and Components

## Quick Start Guide

1. **Choose a tutorial** based on what you want to create
2. **Follow step-by-step** - each tutorial is self-contained
3. **Test in Play Mode** - use XR Device Simulator if you don't have a headset
4. **Experiment** - try the advanced tips and variations

## Common Concepts

Both tutorials use these key Unity components:

| Component | Purpose |
|-----------|---------|
| **Rigidbody** | Adds physics to the object |
| **Joint** (Hinge or Configurable) | Constrains how the object can move |
| **XR Grab Interactable** | Makes the object grabbable in VR |
| **Collider** | Defines the physical shape for interaction |

## Troubleshooting

If something doesn't work:

1. **Check the Rigidbody** - Make sure it's not kinematic on the moving object
2. **Verify Colliders** - Objects need colliders to be grabbed
3. **Test Axes** - Ensure you're limiting/allowing the correct movement axes
4. **Review Settings** - Compare your settings with the tutorial values

## Next Steps

After completing these tutorials, try:

- 🔄 Combining joints (drawer with a hinged lid)
- 🎮 Adding Unity Events to trigger actions
- 🔊 Adding audio feedback for interactions
- 🎨 Creating custom interaction feedbacks
- 🔐 Building lock/unlock mechanics

## Project Structure

```
Assets/
├── Tutorials/
│   ├── README.md (this file)
│   ├── VR-Door-Hinge-Tutorial.md
│   └── VR-Drawer-Sliding-Tutorial.md
├── Scenes/
│   └── Tutorial1-1.unity (contains example implementations)
└── ...
```

## Additional Resources

- [Unity XR Interaction Toolkit Documentation](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest)
- [Unity Physics Joints Manual](https://docs.unity3d.com/Manual/Joints.html)
- [XR Interaction Toolkit Samples](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest/manual/samples.html)

## Contributing

Found an issue or want to improve these tutorials? Feedback welcome!

---

**Happy VR Development!** 🥽✨
