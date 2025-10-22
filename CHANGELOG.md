# Changelog

All notable changes to the AdInMo Unity SDK will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.2.314] - 2025-08-25

### Added
- Unity IAP v4/v5 support with enhanced integration and backward compatibility
- SKProductViewController for improved iOS purchasing experience

### Changed
- Refactored IAP system to be simpler and more robust
- Replaced SKOverlay with SKProductViewController for better iOS compatibility

### Commits
- Commit 6e0473fb: Refactored IAP to be simpler and support IAP v4/v5
- Commit f06a7e2d: Replaced SKOverlay with SKProductViewController

## [3.1.313] - 2025-07-30

### Added
- Enhanced Vulkan renderer compatibility
- Improved bidding logic for banner placements
- Better placement key and GUID tracking
- Duplicate purchase logging functionality

### Changed
- Updated NDK and Android libraries for better compatibility
- Default behavior now pauses game when magnifier shows
- Better handling of no banner scenarios

### Fixed
- Vulkan renderer stalls and performance issues
- WebView threading issues resolved
- Store handler example updated to use hasReceipt

### Commits
- Commit cc2e140d: Fix to vulkan renderer to prevent sdk stalls
- Commit a17f4793: Stop bidding on no banners
- Commit 662287d1: Passing placement_key and guid to backend
- Commit 662287d1: Log duplicate purchases
- Commit c972d08d: Updated ndk and android libraries
- Commit c972d08d: Default pause game when magnifier shows
- Commit 8a61c918: Fix webview threading issue
- Commit 8a3d28bc: Fix example for store handler to use hasReceipt

## [3.1.312] - 2025-07-10

### Added
- Advanced CPU usage optimization for low-end devices
- Intelligent feature auto-degradation system

### Changed
- Significantly reduced CPU usage on low-end devices
- Better automatic feature management based on device capabilities

### Commits
- Commit f18b9abb: Reduced CPU usage on low end devices
- Commit 131017fb: Better feature auto degradation on low end devices

## [3.1.311] - 2025-06-18

### Added
- Support for long dwell times in ad placements
- No Ads support for ad-free experiences
- Enhanced IAP pricing information from AlreadyPurchased callback
- Video playback support on sprite objects

### Changed
- Improved dwell time calculations and tracking
- Enhanced IAP callback system with pricing data

### Commits
- Commit 957ec99e: Allow long dwell times
- Commit 59ce5189: No Ads support
- Commit fd903d77: Can return pricing info from AlreadyPurchased callback
- Commit 5713d636: Videos can now play on sprites

## [3.1.310] - 2025-05-29

### Added
- Support for None Theme allowing manual magnifier customization
- Enhanced pacing improvements for better ad delivery
- Support for 2 visualizations per campaign
- Developer callback for IAP purchase status checking
- Improved IAP data recording and analytics

### Fixed
- Repeating sprites and images rendering issues
- WebGL minor compatibility fixes

### Changed
- Better pacing algorithms for optimal ad frequency
- Enhanced IAP integration with better data tracking

### Commits
- Commit c70ee92c: Fix to repeating sprites and images
- Commit 3ee0b1c7: Support None Theme to allow manual customisation of the magnifier
- Commit 4fb33ef1: Pacing improvements
- Commit 2cae4bea: Support 2 visualisations for campaigns
- Commit 13292f34: Added a callback so that developers can tell us if an IAP is already purchased
- Commit 832de444: Better recording of IAP data
- Commit b2874dae: WebGL minor fixes

---

## Version Support

| Version | Support Status | Unity Compatibility | End of Support |
|---------|---------------|-------------------|----------------|
| 3.2.314 | ✅ Active | 2019.4 - 2023.x | TBD |
| 3.1.313 | ✅ Maintenance | 2019.4 - 2023.x | 2026-01-30 |
| 3.1.312 | ⚠️ Limited | 2019.4 - 2022.x | 2025-10-10 |
| 3.1.311 | ❌ End of Life | 2019.4 - 2022.x | 2025-09-18 |
| 3.1.310 | ❌ End of Life | 2019.4 - 2022.x | 2025-08-29 |

## Migration Guide

### Upgrading to 3.2.314
- Update to Unity IAP v4/v5 for enhanced functionality
- Review IAP integration for simplified API changes
- Test iOS purchasing with new SKProductViewController

### Upgrading from 3.1.312 to 3.1.313
- Update NDK and Android libraries
- Review Vulkan renderer settings if applicable
- Test WebView integration for threading improvements

### Upgrading from 3.1.311 to 3.1.312
- Test performance on low-end devices
- Review auto-degradation settings
- Monitor CPU usage improvements

For detailed migration instructions, visit our [Migration Guide](https://www.adinmo.com/docs/migration).

## Getting Help

- 📖 [Documentation](https://www.adinmo.com/docs)
- 💬 [Support](mailto:support@adinmo.com)
- 🐛 [Report Issues](https://github.com/AdInMo-Ltd/unity-plugin/issues)
- 🚀 [Feature Requests](https://github.com/AdInMo-Ltd/unity-plugin/discussions)