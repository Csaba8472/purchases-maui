echo "Define parameters"
IOS_SDK_VERSION="15.5" # xcodebuild -showsdks
SWIFT_PROJECT_NAME="NETPurchasesLibSwift"
SWIFT_PROJECT_PATH="$SWIFT_PROJECT_NAME/$SWIFT_PROJECT_NAME.xcodeproj"
SWIFT_BUILD_PATH="$SWIFT_PROJECT_NAME/build"
SWIFT_OUTPUT_PATH="$SWIFT_PROJECT_NAME/VendorFrameworks"
XAMARIN_BINDING_PATH="NETPurchasesBinding"


# build PurchasesHibrydCommon
PHC_SWIFT_PROJECT_NAME="PurchasesHybridCommon"
PHC_SWIFT_PROJECT_PATH="purchases-hybrid-common/ios/$PHC_SWIFT_PROJECT_NAME/$PHC_SWIFT_PROJECT_NAME.xcworkspace"
PHC_SWIFT_BUILD_PATH="purchases-hybrid-common/ios/$PHC_SWIFT_PROJECT_NAME/DerivedData/PurchasesHybridCommon/Build/Products"

REV_SWIFT_BUILD_PATH="purchases-hybrid-common/ios/$PHC_SWIFT_PROJECT_NAME/DerivedData/PurchasesHybridCommon/Build/Products"


echo "Build iOS framework for simulator and device"
rm -Rf "purchases-hybrid-common/ios/$PHC_SWIFT_PROJECT_NAME/DerivedData"
rm -Rf "$SWIFT_PROJECT_NAME.xcframework"
rm -Rf "$SWIFT_BUILD_PATH"
xcodebuild -sdk iphonesimulator$IOS_SDK_VERSION -project "$SWIFT_PROJECT_PATH" -target "$SWIFT_PROJECT_NAME" -configuration Release -arch x86_64
xcodebuild -sdk iphoneos$IOS_SDK_VERSION -project "$SWIFT_PROJECT_PATH" -target "$SWIFT_PROJECT_NAME" -configuration Release

cp -R "$SWIFT_BUILD_PATH/Release-iphoneos" "$SWIFT_BUILD_PATH/Release-fat"
cp -R "$SWIFT_BUILD_PATH/Release-iphonesimulator/$SWIFT_PROJECT_NAME.framework/Modules/$SWIFT_PROJECT_NAME.swiftmodule/" "$SWIFT_BUILD_PATH/Release-fat/$SWIFT_PROJECT_NAME.framework/Modules/$SWIFT_PROJECT_NAME.swiftmodule/"
cp -R "$SWIFT_BUILD_PATH/Release-iphonesimulator/RevenueCat/$SWIFT_PROJECT_NAME.framework/Modules/$SWIFT_PROJECT_NAME.swiftmodule/" "$SWIFT_BUILD_PATH/Release-fat/RevenueCat/$SWIFT_PROJECT_NAME.framework/Modules/$SWIFT_PROJECT_NAME.swiftmodule/"

echo "Combine iphoneos + iphonesimulator configuration as fat libraries"
lipo -create -output "$SWIFT_BUILD_PATH/Release-fat/$SWIFT_PROJECT_NAME.framework/$SWIFT_PROJECT_NAME" "$SWIFT_BUILD_PATH/Release-iphoneos/$SWIFT_PROJECT_NAME.framework/$SWIFT_PROJECT_NAME" "$SWIFT_BUILD_PATH/Release-iphonesimulator/$SWIFT_PROJECT_NAME.framework/$SWIFT_PROJECT_NAME"

echo "Verify results"
lipo -info "$SWIFT_BUILD_PATH/Release-fat/$SWIFT_PROJECT_NAME.framework/$SWIFT_PROJECT_NAME"

xcodebuild -create-xcframework -framework "$SWIFT_BUILD_PATH/Release-iphoneos/$SWIFT_PROJECT_NAME.framework/" -framework "$SWIFT_BUILD_PATH/Release-iphonesimulator/$SWIFT_PROJECT_NAME.framework/" -output "$SWIFT_PROJECT_NAME.xcframework"




REV_SWIFT_PROJECT_NAME="RevenueCat"
REV_SWIFT_PROJECT_PATH="purchases-ios/$REV_SWIFT_PROJECT_NAME.xcodeproj"
REV_SWIFT_BUILD_PATH="purchases-ios/build"
REV_SWIFT_OUTPUT_PATH="purchases-ios/VendorFrameworks"

echo "Build iOS framework for simulator and device"
rm -Rf "$REV_SWIFT_BUILD_PATH"
rm -Rf "$REV_SWIFT_PROJECT_NAME.xcframework"
xcodebuild -sdk iphonesimulator$IOS_SDK_VERSION -project "$REV_SWIFT_PROJECT_PATH" -target "$REV_SWIFT_PROJECT_NAME" -configuration Release -arch x86_64
xcodebuild -sdk iphoneos$IOS_SDK_VERSION -project "$REV_SWIFT_PROJECT_PATH" -target "$REV_SWIFT_PROJECT_NAME" -configuration Release

cp -R "$REV_SWIFT_BUILD_PATH/Release-iphoneos" "$REV_SWIFT_BUILD_PATH/Release-fat"
cp -R "$REV_SWIFT_BUILD_PATH/Release-iphonesimulator/$REV_SWIFT_PROJECT_NAME.framework/Modules/$REV_SWIFT_PROJECT_NAME.swiftmodule/" "$REV_SWIFT_BUILD_PATH/Release-fat/$REV_SWIFT_PROJECT_NAME.framework/Modules/$REV_SWIFT_PROJECT_NAME.swiftmodule/"
cp -R "$REV_SWIFT_BUILD_PATH/Release-iphonesimulator/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/Modules/$REV_SWIFT_PROJECT_NAME.swiftmodule/" "$REV_SWIFT_BUILD_PATH/Release-fat/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/Modules/$REV_SWIFT_PROJECT_NAME.swiftmodule/"

echo "Combine iphoneos + iphonesimulator configuration as fat libraries"
lipo -create -output "$REV_SWIFT_BUILD_PATH/Release-fat/$REV_SWIFT_PROJECT_NAME.framework/$REV_SWIFT_PROJECT_NAME" "$REV_SWIFT_BUILD_PATH/Release-iphoneos/$REV_SWIFT_PROJECT_NAME.framework/$REV_SWIFT_PROJECT_NAME" "$REV_SWIFT_BUILD_PATH/Release-iphonesimulator/$REV_SWIFT_PROJECT_NAME.framework/$REV_SWIFT_PROJECT_NAME"

echo "Verify results"
lipo -info "$REV_SWIFT_BUILD_PATH/Release-fat/$REV_SWIFT_PROJECT_NAME.framework/$REV_SWIFT_PROJECT_NAME"

xcodebuild -create-xcframework -framework "$REV_SWIFT_BUILD_PATH/Release-iphoneos/$REV_SWIFT_PROJECT_NAME.framework/" -framework "$REV_SWIFT_BUILD_PATH/Release-iphonesimulator/$REV_SWIFT_PROJECT_NAME.framework/" -output "$REV_SWIFT_PROJECT_NAME.xcframework"





echo "Build iOS framework for simulator and device"
rm -Rf "purchases-ios/DerivedData"
rm -Rf "$PHC_SWIFT_PROJECT_NAME.xcframework"
rm -Rf "$PHC_SWIFT_BUILD_PATH"
xcodebuild -sdk iphonesimulator$IOS_SDK_VERSION -workspace "$PHC_SWIFT_PROJECT_PATH" -scheme PurchasesHybridCommon -configuration Release -arch x86_64
xcodebuild -sdk iphoneos$IOS_SDK_VERSION -workspace "$PHC_SWIFT_PROJECT_PATH" -scheme PurchasesHybridCommon -configuration Release

echo "Create PurchasesHybridCommon fat binaries for Release-iphoneos and Release-iphonesimulator configuration"
cp -R "$PHC_SWIFT_BUILD_PATH/Release-iphoneos" "$PHC_SWIFT_BUILD_PATH/Release-fat"
cp -R "$PHC_SWIFT_BUILD_PATH/Release-iphonesimulator/$PHC_SWIFT_PROJECT_NAME.framework/Modules/$PHC_SWIFT_PROJECT_NAME.swiftmodule/" "$PHC_SWIFT_BUILD_PATH/Release-fat/$PHC_SWIFT_PROJECT_NAME.framework/Modules/$PHC_SWIFT_PROJECT_NAME.swiftmodule/"
cp -R "$PHC_SWIFT_BUILD_PATH/Release-iphonesimulator/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/Modules/$REV_SWIFT_PROJECT_NAME.swiftmodule/" "$PHC_SWIFT_BUILD_PATH/Release-fat/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/Modules/$REV_SWIFT_PROJECT_NAME.swiftmodule/"


echo "Combine iphoneos + iphonesimulator configuration as fat libraries"
lipo -create -output "$PHC_SWIFT_BUILD_PATH/Release-fat/$PHC_SWIFT_PROJECT_NAME.framework/$PHC_SWIFT_PROJECT_NAME" "$PHC_SWIFT_BUILD_PATH/Release-iphoneos/$PHC_SWIFT_PROJECT_NAME.framework/$PHC_SWIFT_PROJECT_NAME" "$PHC_SWIFT_BUILD_PATH/Release-iphonesimulator/$PHC_SWIFT_PROJECT_NAME.framework/$PHC_SWIFT_PROJECT_NAME"
lipo -create -output "$PHC_SWIFT_BUILD_PATH/Release-fat/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/$REV_SWIFT_PROJECT_NAME" "$PHC_SWIFT_BUILD_PATH/Release-iphoneos/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/$REV_SWIFT_PROJECT_NAME" "$PHC_SWIFT_BUILD_PATH/Release-iphonesimulator/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/$REV_SWIFT_PROJECT_NAME"

echo "Verify results"
lipo -info "$PHC_SWIFT_BUILD_PATH/Release-fat/$PHC_SWIFT_PROJECT_NAME.framework/$PHC_SWIFT_PROJECT_NAME"

lipo -info "$PHC_SWIFT_BUILD_PATH/Release-fat/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/$REV_SWIFT_PROJECT_NAME"


sharpie bind --sdk=iphoneos$IOS_SDK_VERSION --output="$XAMARIN_BINDING_PATH.Dirty" --namespace="NETPurchasesBinding" --scope="$SWIFT_PROJECT_NAME" $SWIFT_PROJECT_NAME/$SWIFT_PROJECT_NAME/*.h

xcodebuild -create-xcframework -framework "$PHC_SWIFT_BUILD_PATH/Release-iphoneos/$PHC_SWIFT_PROJECT_NAME.framework/" -framework "$PHC_SWIFT_BUILD_PATH/Release-iphonesimulator/$PHC_SWIFT_PROJECT_NAME.framework/" -output "$PHC_SWIFT_PROJECT_NAME.xcframework"


echo "$PHC_SWIFT_BUILD_PATH/Release-iphoneos/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/"
echo "$PHC_SWIFT_BUILD_PATH/Release-iphonesimulator/RevenueCat/$REV_SWIFT_PROJECT_NAME.framework/"

echo "Done!"