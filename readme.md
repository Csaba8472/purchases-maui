## [unofficial] [WIP] purchases-maui

purchases-maui is the dotnet implementation of Revenuecat's [Hybrid SDK architecture](https://www.revenuecat.com/blog/how-our-hybrids-work/). Essentially the same as [purchases-flutter](https://github.com/RevenueCat/purchases-flutter) just for MAUI. It was built upon [purchases-hybrid-common](https://github.com/RevenueCat/purchases-hybrid-common) library.

## Issues

### iOS
Manifest file always get deleted from bin/Debug/net6.0-ios/NETPurchasesBindingIOS.resources if you try to build from windows. You see clang++ error when this happens. This is related to iOS binding projects.

For some reason only xcframework can be built on windows fat iOS frameworks or static lib doesn't.

### Android
AndroidLibrary doesn't work, LibraryProjectZip works only:
- https://github.com/xamarin/xamarin-android/issues/7040

AndroidLibrary Bind=false workaround: 
- https://github.com/microsoft/onnxruntime/commit/6e71bd543bdb642cd9fe39141f6f709ce822a7ce
- https://github.com/microsoft/onnxruntime/pull/12075

aar pack:
- https://github.com/xamarin/xamarin-android/wiki/Known-issues-in-.NET

https://github.com/xamarin/java.interop/wiki/Troubleshooting-Android-Bindings-Issues

## Other useful links
- https://docs.microsoft.com/en-us/xamarin/android/deploy-test/building-apps/build-items#androidlibrary
- https://docs.microsoft.com/en-us/xamarin/android/platform/binding-java-library/#build-actions
- https://gist.github.com/JonDouglas/dda6d8ace7d071b0e8cb#approaching-a-xamarinandroid-bindings-case
- https://docs.microsoft.com/en-us/xamarin/android/platform/binding-java-library/customizing-bindings/java-bindings-metadata
- https://docs.microsoft.com/en-us/xamarin/android/deploy-test/building-apps/build-items