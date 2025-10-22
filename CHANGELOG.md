# Changelog

All notable changes to the AdInMo Unity SDK will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [v314] - 2024-08-18

### Added
- Unity IAP v4 integration with enhanced compatibility
- Improved error handling and logging system
- Enhanced placement validation and impression tracking
- Support for Unity 2023.x versions

### Changed
- Optimized SDK initialization process
- Improved memory management for large ad campaigns
- Enhanced cross-platform compatibility

### Fixed
- Critical Unity IAP v4 initialization issue in proxy wrapper
- Memory leaks in placement object lifecycle
- iOS build compatibility issues with Xcode 15+
- Android build optimizations for API level 34+

### Security
- Enhanced data privacy compliance
- Improved secure communication protocols

## [v313] - 2024-07-30

### Added
- Advanced placement occlusion detection
- Enhanced analytics and reporting capabilities
- Support for custom placement shapes

### Changed
- Improved placement rendering performance
- Optimized network request handling
- Enhanced UI/UX for developer tools

### Fixed
- Placement visibility calculation improvements
- iOS metal rendering compatibility
- Android WebView integration stability

### Removed
- Deprecated legacy store handler implementations
- Unused legacy IAP integration files

## [v312] - 2024-07-11

### Added
- Real-time campaign performance metrics
- Enhanced brand safety controls
- Support for interactive ad formats

### Changed
- Improved placement loading times
- Enhanced error recovery mechanisms
- Updated documentation and examples

### Fixed
- Placement rotation and scaling issues
- Memory optimization for video content
- Cross-platform audio synchronization

## [v311] - 2024-06-24

### Added
- Advanced targeting and personalization features
- Enhanced placement analytics
- Support for dynamic content updates

### Changed
- Improved SDK stability and performance
- Enhanced developer debugging tools
- Optimized build size and loading times

### Fixed
- Minor stability improvements
- Documentation updates
- Build process optimizations

## [v310] - 2024-05-30

### Added
- Enhanced audio advertising capabilities
- Advanced impression validation system
- Support for new Unity rendering pipelines

### Changed
- Improved placement management system
- Enhanced network connectivity handling
- Optimized resource loading

### Fixed
- Audio placement synchronization issues
- iOS App Store submission compatibility
- Android build warnings and optimizations

### Security
- Enhanced encryption for ad content delivery
- Improved user privacy protection

---

## Version Support

| Version | Support Status | Unity Compatibility | End of Support |
|---------|---------------|-------------------|----------------|
| v314 | ✅ Active | 2019.4 - 2023.x | TBD |
| v313 | ✅ Maintenance | 2019.4 - 2023.x | 2025-01-30 |
| v312 | ⚠️ Limited | 2019.4 - 2022.x | 2024-10-11 |
| v311 | ❌ End of Life | 2019.4 - 2022.x | 2024-09-24 |
| v310 | ❌ End of Life | 2019.4 - 2022.x | 2024-08-30 |

## Migration Guide

### Upgrading from v313 to v314
- Update Unity IAP to v4.12.0 or later
- Replace deprecated IAP proxy methods
- Update placement validation code

### Upgrading from v312 to v313
- Review placement occlusion settings
- Update analytics integration
- Test custom placement shapes

For detailed migration instructions, visit our [Migration Guide](https://www.adinmo.com/docs/migration).

## Getting Help

- 📖 [Documentation](https://www.adinmo.com/docs)
- 💬 [Support](mailto:support@adinmo.com)
- 🐛 [Report Issues](https://github.com/AdInMo-Ltd/unity-plugin/issues)
- 🚀 [Feature Requests](https://github.com/AdInMo-Ltd/unity-plugin/discussions)
