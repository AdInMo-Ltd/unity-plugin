# AdInMo Unity SDK

<div align="center">

![AdInMo Logo](https://www.adinmo.com/wp-content/uploads/2023/03/adinmo-logo-orange.png)

**Seamless In-Game Advertising for Unity**

[![Unity Version](https://img.shields.io/badge/Unity-2019.4+-blue.svg)](https://unity3d.com/get-unity/download)
[![Version](https://img.shields.io/badge/Version-3.2.314-orange.svg)](https://github.com/AdInMo-Ltd/unity-plugin/releases)
[![License](https://img.shields.io/badge/License-Commercial-green.svg)](https://www.adinmo.com)

[🚀 Quick Start](#quick-start) • [📖 Documentation](#documentation) • [💬 Support](#support) • [🔗 Developer Portal](https://www.adinmo.com)

</div>

---

## 🎮 What is AdInMo?

AdInMo transforms traditional advertising by seamlessly integrating **real brand campaigns** directly into your game environment. No pop-ups, no interruptions - just natural, contextual advertising that enhances rather than disrupts the gaming experience.

### ✨ Key Features

- 🎯 **Contextual In-Game Ads** - Billboards, posters, and branded content that fit naturally
- 💰 **Revenue Optimization** - Advanced AI-driven ad placement and targeting
- 🔄 **Real-Time Updates** - Dynamic content that refreshes without app updates
- 📱 **Cross Platform** - iOS, Android, WebGL, Desktop support
- 🎨 **Multiple Formats** - Static images, videos, interactive content
- 💳 **IAP Integration** - Boost in-app purchases with contextual product placement
- 📊 **Analytics Dashboard** - Comprehensive performance and revenue tracking
- 🛡️ **Brand Safety** - Premium advertisers and content verification

---

## 🚀 Quick Start

### Unity Package Manager (Recommended)

1. **Open Unity Editor**
2. Navigate to **Window → Package Manager**
3. Click **+ → Add package from git URL**
4. Paste the following URL:

```
https://github.com/AdInMo-Ltd/unity-plugin.git
```

5. Click **Add** and Unity will handle the rest!

### Alternative: Specific Version Installation

For production projects, specify a version:

```
https://github.com/AdInMo-Ltd/unity-plugin.git#v3.2.314
```

### Traditional .unitypackage (Legacy)

Download from [Releases](https://github.com/AdInMo-Ltd/unity-plugin/releases) and import manually.

---

## ⚙️ Requirements

| Requirement | Minimum | Recommended |
|-------------|---------|-------------|
| **Unity Version** | 2019.4 LTS | 2021.3 LTS+ |
| **Platforms** | iOS 11+, Android 7+ | iOS 12+, Android 8+ |
| **Rendering** | Built-in, URP, HDRP | URP/HDRP |
| **Scripting** | .NET Standard 2.1 | .NET Standard 2.1 |

---

## 🛠️ Basic Integration

### 1. Setup AdInMo Manager

Drag the **AdinmoManager** prefab into your scene:

```
Assets/Adinmo/Prefabs/AdinmoManager.prefab
```

### 2. Configure Your Game Key

```csharp
// In your game initialization
AdinmoManager.Initialize("your-game-key-here");
```

### 3. Add Placement Objects

Choose from pre-built prefabs:

```
Assets/Adinmo/Prefabs/Images/   - UI Image placements
Assets/Adinmo/Prefabs/Meshes/   - 3D Mesh placements  
Assets/Adinmo/Prefabs/Sprites/  - 2D Sprite placements
```

### 4. Test Integration

Use the **Simple Scene** example:

```
Assets/Adinmo/Examples/Simple Scene.unity
```

---

## 🎯 Advanced Features

### In-App Purchase Integration

Boost your IAP conversion with contextual product placement:

```csharp
// Enable IAP integration with Unity IAP v4/v5
UnityPurchasingAdInMoExtensions.InitializeWithAdInMo(this, builder);
```

[📘 Complete IAP Integration Guide](https://github.com/AdInMo-Ltd/unity-plugin/blob/main/Readme.txt)

### Audio Advertising

Add audio placements for immersive sound advertising:

```csharp
// Add audio placement
AudioSource audioSource = GetComponent<AudioSource>();
AdinmoAudioPlacement audioAd = gameObject.AddComponent<AdinmoAudioPlacement>();
```

### Custom Placement Shapes

Support for custom meshes and complex geometries:

- Billboard placements
- Curved surfaces  
- Interactive objects
- Dynamic content

---

## 📚 Documentation

| Resource | Description |
|----------|-------------|
| [🏁 Getting Started](https://www.adinmo.com/docs/unity-getting-started) | Complete setup walkthrough |
| [🔧 Integration Guide](https://github.com/AdInMo-Ltd/unity-plugin/blob/main/Readme.txt) | Detailed implementation |
| [💳 IAP Integration](https://www.adinmo.com/docs/unity-iap) | Unity IAP v4/v5 setup |
| [🎮 Example Scenes](https://github.com/AdInMo-Ltd/unity-plugin/tree/main/Examples) | Working implementation examples |
| [🔌 API Reference](https://www.adinmo.com/docs/unity-api) | Complete API documentation |
| [❓ FAQ](https://www.adinmo.com/docs/faq) | Common questions and solutions |

---

## 📦 Version History

| Version | Release Date | Key Features |
|---------|--------------|--------------|
| **v3.2.314** | August 2025 | Unity IAP v4/v5 support, SKProductViewController |
| **v3.1.313** | July 2025 | Vulkan renderer fixes, Android library updates |
| **v3.1.312** | July 2025 | CPU optimization for low-end devices |
| **v3.1.311** | June 2025 | Long dwell times, No Ads support, video sprites |
| **v3.1.310** | May 2025 | Sprite fixes, manual magnifier customization |

[📋 Complete Changelog](https://github.com/AdInMo-Ltd/unity-plugin/blob/main/CHANGELOG.md)

---

## 🔧 Troubleshooting

### Common Issues

<details>
<summary><strong>Package Manager Installation Failed</strong></summary>

**Solution:**
```bash
# Ensure Git is installed and accessible
git --version

# Try HTTPS URL instead
https://github.com/AdInMo-Ltd/unity-plugin.git
```
</details>

<details>
<summary><strong>Build Errors on iOS/Android</strong></summary>

**Solution:**
- Ensure minimum platform versions are met
- Check Dependencies.xml for required native libraries
- Verify signing certificates and provisioning profiles
</details>

<details>
<summary><strong>Ads Not Displaying</strong></summary>

**Solution:**
1. Verify your Game Key is correct
2. Check internet connection
3. Ensure AdInMo Manager is in scene
4. Check Unity Console for error messages
</details>

### Getting Help

1. **Check Console Logs** - Enable AdInMo debug logging
2. **Review Documentation** - Visit our comprehensive docs
3. **Contact Support** - Email support@adinmo.com
4. **Developer Community** - Join our Discord server

---

## 💬 Support

| Channel | Contact | Response Time |
|---------|---------|---------------|
| 📧 **Email** | support@adinmo.com | 24-48 hours |
| 🌐 **Developer Portal** | [adinmo.com](https://www.adinmo.com) | Self-service |
| 💬 **Discord** | [Join Community](https://discord.gg/adinmo) | Real-time |
| 📞 **Enterprise** | enterprise@adinmo.com | Priority |

---

## 🏢 About AdInMo

AdInMo is the leading in-game advertising platform, trusted by game developers worldwide to monetize their content without compromising user experience. Our patented technology ensures that advertising feels natural and enhances gameplay rather than interrupting it.

### 🤝 Partners & Clients

We work with top-tier brands and game studios to create meaningful advertising experiences that benefit players, developers, and advertisers alike.

---

## 📄 License

This SDK is provided under a commercial license. See [License Terms](https://www.adinmo.com/terms) for details.

**Copyright © 2025 AdInMo Ltd. All rights reserved.**

---

<div align="center">

**Ready to get started?** 

[🚀 Create Account](https://www.adinmo.com/signup) • [📖 View Docs](https://www.adinmo.com/docs) • [💬 Get Support](mailto:support@adinmo.com)

Made with ❤️ by the AdInMo team

</div>
