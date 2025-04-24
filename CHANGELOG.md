# Changelog

All notable changes to this project will be documented in this file. See [commit-and-tag-version](https://github.com/absolute-version/commit-and-tag-version) for commit guidelines.

## [3.2.0](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v3.2.0-prerelease.0...v3.2.0) (2025-04-24)

### Features

* added another option for event inference ([e3c4678](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/e3c467875293879fb5514f23f328dcf3561dfbc8))

## [3.1.0](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v3.0.0...v3.1.0) (2025-04-20)


### Features

* adding changelog/ release generation ([19765aa](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/19765aa908f3c34cdc6c6d978eac8cb54d0cb1d7))


### Bug Fixes

* fixing ci action - missing solution ([ea08f70](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/ea08f707e23d49a4fd8ddecc48e0db2161460bd6))

## [3.0.0](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v2.0.1...v3.0.0) (2025-02-19)

### Features

- added lots of fixes and scoped logger (v2) now output formatted message ([40b7104](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/40b7104af93907ed0996b6af23d93408f7ecf15e))
- added support for enumerating arrays or ienumerables ([b7e627d](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/b7e627d82e0d407c06955e0d9e76837a9686e84c))
- added test (and tests) for creating diagnotics when generic interface or methods used ([61f438e](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/61f438e0dbbea65e44eeb46e32f2655a2abcb217))
- **messagetemplate:** [partial] regex parsing integrated ([e235a0d](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/e235a0d737d63d80719613408be8e6c0471560f3))
- **messagetemplate:** [partial] working on log gen v2 ([60a7f1b](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/60a7f1b2f3d4abc6de592cec7e5afe2dcc5a1c38))
- **messagetemplate:** [partial] working on log gen v2 ([f42c371](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/f42c3713db8e08966ca8b3c8ec5aa820c64c9495))
- updated all emitters to use global:: ([44b56f6](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/44b56f61d8655929794d66e0c5aac54871d92f1f))

### Bug Fixes

- added missing {CodeGen} to template attributes ([b14d630](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/b14d630e930600e7212c376284bbe098006b666c))
- off-by-one error when exception parameter provided ([8e0c02f](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/8e0c02f01869eabba27272bb15cbb87957739c38))

## [2.0.1](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v2.0.0...v2.0.1) (2025-02-02)

### Features

- updated sample app to use Minimal API ([58bc4e5](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/58bc4e552cbda2c18c175fcf2156d71b5e140d0a))

## [2.0.0](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.12...v2.0.0) (2025-02-01)

### Features

- added abilitty to set Activity Status Code when defining an Event ([8c3c11b](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/8c3c11b16164d13cd46095ff70906e03b5b288d2))
- added ability to disable MS Logging related classes. Dropped support for .NET 7 ([3e943e4](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/3e943e435feb5dbff7c4f8bead6c31061f70093a))

## [1.0.12](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.11...v1.0.12) (2024-06-09)

## [1.0.11](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.10...v1.0.11) (2024-06-03)

## [1.0.10](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.9...v1.0.10) (2024-06-03)

## [1.0.9](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.8...v1.0.9) (2024-05-30)

### Features

- added diagnostic for duplicate method names ([6989c83](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/6989c83b1e37b2d83fb786804fef419ace9e7a6a))
- added explicit attributes for log levels ([e4b6b28](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/e4b6b28b57b34ba4f2dae874699c6d21dc5170ae))

## [1.0.8](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.6...v1.0.8) (2024-05-27)

## [1.0.6](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.5...v1.0.6) (2024-05-20)

### Features

- added new diagnostic (info) for when no Activity method is defined, but an Event and/ or Context is ([2cca495](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/2cca49542db3f46ce524d34376714977aaf9b601))

## [1.0.5](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.4...v1.0.5) (2024-05-06)

### Bug Fixes

- fixed diagnostic id duplication ([4e02398](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/4e0239850937fa46698820724d00291ec7ce0b5b))

## [1.0.4](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.3...v1.0.4) (2024-05-01)

### Bug Fixes

- fixed invalid prefix modes for instruments ([b1867ec](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/b1867ec8a33e7baf6348c3a03269b48630cbc7e6))

## [1.0.3](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.2...v1.0.3) (2024-04-30)

### Features

- added AutoCounterAttribute which is the same as CounterAttribute(AutoIncrement = true) ([ff5a80a](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/ff5a80aa37cba97aa418d4e58b0e8a95bcc74150))

### Bug Fixes

- fixed issue causing generic (List<string> etc) parameters from correctly generating ([098532b](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/098532b43405a5e81a34ee0ab4855350ff5e1524))

## [1.0.2](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.1...v1.0.2) (2024-04-25)

### Features

- used the assembly name as the default activity source name ([74e0b45](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/74e0b45c063810e280d79d9c878706662b6e5c14))

## [1.0.1](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v1.0.0...v1.0.1) (2024-04-25)

## [1.0.0](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/v0.0.1...v1.0.0) (2024-04-15)

### Features

- added basic support for otel exception format ([228562f](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/228562fd81e1a491afc718854422aa0d682872a4))
- supporting hash-defines for mutli-framework targetting ([7b17254](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/7b172543f6bccbf19598276694b731ecf5097aea))
- telemetry (multi-target generation) working ([6b93faf](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/6b93faf7fd3599e32fddbde390d0a2eccba16b15))

### Bug Fixes

- fixed event exception generation null check and added agressive inlining to all generated methods ([5071dd2](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/5071dd2e87fa1c131c32773abf9464be982a9fc4))
- made the activity/ event/ exception situation more liberal ([6075786](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/6075786353ed9ddc2fe4fbb46782f2a0d5365c84))

## [0.0.1](https://github.com/purview-dev/purview-telemetry-sourcegenerator/compare/6707d6d29c95fa658663d0da439fae307a1cd9a5...v0.0.1) (2024-03-18)

### Features

- added activities and events, moving on to metrics ([fd1cdf2](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/fd1cdf2a9e7a8259c12883aa1715cfb5021eae95))
- adding activities ([653b7f0](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/653b7f05c7014cc248a8bcea923e5ef71e8584ef))
- basis for working metrics ([203a966](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/203a9666ff10e3fa2de2aaf004b1174f3de849b0))
- logging: basic tests working ([6707d6d](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/6707d6d29c95fa658663d0da439fae307a1cd9a5))
- observable metrics can return bool to indicate if they're already initialized or not ([d56d8de](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/d56d8de5c198fb7eb065f60e0a4574237a57fbda))
- tests pass for MELT emitters -> more tests required ([871c643](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/871c6433e2183a4b43a2900a50a4e8b078819298))

### Bug Fixes

- fixed di generation ([9ae6711](https://github.com/purview-dev/purview-telemetry-sourcegenerator/commit/9ae67115967bd5e89fb8d5cd5a1451b906c6a911))
