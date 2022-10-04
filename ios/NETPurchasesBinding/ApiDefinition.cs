using System;
using Foundation;
using ObjCRuntime;

namespace NETPurchasesBinding;

// @interface NETError : NSObject
[BaseType(typeof(NSObject))]
interface NETError : INativeObject
{
	// +(instancetype)errorWithCode:(NSString *)code message:(NSString * _Nullable)message details:(id _Nullable)details;
	[Static]
	[Export("errorWithCode:message:details:")]
	NETError ErrorWithCode(string code, [NullAllowed] string message, [NullAllowed] NSObject details);

	// @property (readonly, nonatomic) NSString * code;
	[Export("code")]
	string Code { get; }

	// @property (readonly, nonatomic) NSString * _Nullable message;
	[NullAllowed, Export("message")]
	string Message { get; }

	// @property (readonly, nonatomic) id _Nullable details;
	[NullAllowed, Export("details")]
	NSObject Details { get; }
}

// @protocol NETPurchasesDelegate <NSObject>
[BaseType(typeof(NSObject))]
[Model]
interface NETPurchasesDelegate
{
	// @required -(void)customerInfoUpdated:(id)data;
	[Export("customerInfoUpdated:")]
	[Abstract]
	void CustomerInfoUpdated(NSObject data);

	// @required -(void)readyForPromotedProductPurchase:(id)data;
	[Export("readyForPromotedProductPurchase:")]
	[Abstract]
	void ReadyForPromotedProductPurchase(NSObject data);
}

// typedef void (^NETResult)(id _Nullable);
delegate void NETResult([NullAllowed] NSObject arg0);

// @interface NETPurchases : NSObject
[BaseType(typeof(NSObject))]
interface NETPurchases
{
	[Wrap("WeakDelegate")]
	NETPurchasesDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<NETPurchasesDelegate> delegate;
	[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(void)setupPurchases:(NSString *)apiKey appUserID:(NSString *)appUserID observerMode:(BOOL)observerMode userDefaultsSuiteName:(NSString * _Nullable)userDefaultsSuiteName result:(NETResult)result;
	[Export("setupPurchases:appUserID:observerMode:userDefaultsSuiteName:result:")]
	void SetupPurchases(string apiKey, string appUserID, bool observerMode, [NullAllowed] string userDefaultsSuiteName, NETResult result);

	// -(void)setAllowSharingStoreAccount:(BOOL)allowSharingStoreAccount result:(NETResult)resul;
	[Export("setAllowSharingStoreAccount:result:")]
	void SetAllowSharingStoreAccount(bool allowSharingStoreAccount, NETResult resul);

	// -(void)setFinishTransactions:(BOOL)finishTransactions result:(NETResult)result;
	[Export("setFinishTransactions:result:")]
	void SetFinishTransactions(bool finishTransactions, NETResult result);

	// -(void)getOfferingsWithResult:(NETResult)result;
	[Export("getOfferingsWithResult:")]
	void GetOfferingsWithResult(NETResult result);

	// -(void)getProductInfo:(NSArray *)products result:(NETResult)result;
	[Export("getProductInfo:result:")]
	void GetProductInfo(NSArray products, NETResult result);

	// -(void)purchaseProduct:(NSString *)productIdentifier signedDiscountTimestamp:(NSString * _Nullable)discountTimestamp result:(NETResult)result;
	[Export("purchaseProduct:signedDiscountTimestamp:result:")]
	void PurchaseProduct(string productIdentifier, [NullAllowed] string discountTimestamp, NETResult result);

	// -(void)purchasePackage:(NSString *)packageIdentifier offering:(NSString *)offeringIdentifier signedDiscountTimestamp:(NSString * _Nullable)discountTimestamp result:(NETResult)result;
	[Export("purchasePackage:offering:signedDiscountTimestamp:result:")]
	void PurchasePackage(string packageIdentifier, string offeringIdentifier, [NullAllowed] string discountTimestamp, NETResult result);

	// -(void)restorePurchasesWithResult:(NETResult)result;
	[Export("restorePurchasesWithResult:")]
	void RestorePurchasesWithResult(NETResult result);

	// -(void)syncPurchasesWithResult:(NETResult)result;
	[Export("syncPurchasesWithResult:")]
	void SyncPurchasesWithResult(NETResult result);

	// -(void)getAppUserIDWithResult:(NETResult)result;
	[Export("getAppUserIDWithResult:")]
	void GetAppUserIDWithResult(NETResult result);

	// -(void)logInAppUserID:(NSString * _Nullable)appUserID result:(NETResult)result;
	[Export("logInAppUserID:result:")]
	void LogInAppUserID([NullAllowed] string appUserID, NETResult result);

	// -(void)logOutWithResult:(NETResult)result;
	[Export("logOutWithResult:")]
	void LogOutWithResult(NETResult result);

	// -(void)setDebugLogsEnabled:(BOOL)enabled result:(NETResult)result;
	[Export("setDebugLogsEnabled:result:")]
	void SetDebugLogsEnabled(bool enabled, NETResult result);

	// -(void)setProxyURLString:(NSString * _Nullable)proxyURLString result:(NETResult)result;
	[Export("setProxyURLString:result:")]
	void SetProxyURLString([NullAllowed] string proxyURLString, NETResult result);

	// -(void)setSimulatesAskToBuyInSandbox:(BOOL)enabled result:(NETResult)result;
	[Export("setSimulatesAskToBuyInSandbox:result:")]
	void SetSimulatesAskToBuyInSandbox(bool enabled, NETResult result);

	// -(void)getCustomerInfoWithResult:(NETResult)result;
	[Export("getCustomerInfoWithResult:")]
	void GetCustomerInfoWithResult(NETResult result);

	// -(void)setAutomaticAppleSearchAdsAttributionCollection:(BOOL)enabled result:(NETResult)result;
	[Export("setAutomaticAppleSearchAdsAttributionCollection:result:")]
	void SetAutomaticAppleSearchAdsAttributionCollection(bool enabled, NETResult result);

	// -(void)isAnonymousWithResult:(NETResult)result;
	[Export("isAnonymousWithResult:")]
	void IsAnonymousWithResult(NETResult result);

	// -(void)isConfiguredWithResult:(NETResult)result;
	[Export("isConfiguredWithResult:")]
	void IsConfiguredWithResult(NETResult result);

	// -(void)checkTrialOrIntroductoryPriceEligibility:(NSArray *)products result:(NETResult)result;
	[Export("checkTrialOrIntroductoryPriceEligibility:result:")]
	void CheckTrialOrIntroductoryPriceEligibility(NSArray products, NETResult result);

	// -(void)invalidateCustomerInfoCacheWithResult:(NETResult)result;
	[Export("invalidateCustomerInfoCacheWithResult:")]
	void InvalidateCustomerInfoCacheWithResult(NETResult result);

	// -(void)presentCodeRedemptionSheetWithResult:(NETResult)result;
	[Export("presentCodeRedemptionSheetWithResult:")]
	void PresentCodeRedemptionSheetWithResult(NETResult result);

	// -(void)setAttributes:(NSDictionary *)attributes result:(NETResult)result;
	[Export("setAttributes:result:")]
	void SetAttributes(NSDictionary attributes, NETResult result);

	// -(void)setEmail:(NSString *)email result:(NETResult)result;
	[Export("setEmail:result:")]
	void SetEmail(string email, NETResult result);

	// -(void)setPhoneNumber:(NSString *)phoneNumber result:(NETResult)result;
	[Export("setPhoneNumber:result:")]
	void SetPhoneNumber(string phoneNumber, NETResult result);

	// -(void)setDisplayName:(NSString *)displayName result:(NETResult)result;
	[Export("setDisplayName:result:")]
	void SetDisplayName(string displayName, NETResult result);

	// -(void)setPushToken:(NSString *)pushToken result:(NETResult)result;
	[Export("setPushToken:result:")]
	void SetPushToken(string pushToken, NETResult result);

	// -(void)setAdjustID:(NSString * _Nullable)adjustID result:(NETResult)result;
	[Export("setAdjustID:result:")]
	void SetAdjustID([NullAllowed] string adjustID, NETResult result);

	// -(void)setAppsflyerID:(NSString * _Nullable)appsflyerID result:(NETResult)result;
	[Export("setAppsflyerID:result:")]
	void SetAppsflyerID([NullAllowed] string appsflyerID, NETResult result);

	// -(void)setFBAnonymousID:(NSString * _Nullable)fbAnonymousID result:(NETResult)result;
	[Export("setFBAnonymousID:result:")]
	void SetFBAnonymousID([NullAllowed] string fbAnonymousID, NETResult result);

	// -(void)setMparticleID:(NSString * _Nullable)mparticleID result:(NETResult)result;
	[Export("setMparticleID:result:")]
	void SetMparticleID([NullAllowed] string mparticleID, NETResult result);

	// -(void)setOnesignalID:(NSString * _Nullable)onesignalID result:(NETResult)result;
	[Export("setOnesignalID:result:")]
	void SetOnesignalID([NullAllowed] string onesignalID, NETResult result);

	// -(void)setAirshipChannelID:(NSString * _Nullable)airshipChannelID result:(NETResult)result;
	[Export("setAirshipChannelID:result:")]
	void SetAirshipChannelID([NullAllowed] string airshipChannelID, NETResult result);

	// -(void)setMediaSource:(NSString * _Nullable)mediaSource result:(NETResult)result;
	[Export("setMediaSource:result:")]
	void SetMediaSource([NullAllowed] string mediaSource, NETResult result);

	// -(void)setCampaign:(NSString * _Nullable)campaign result:(NETResult)result;
	[Export("setCampaign:result:")]
	void SetCampaign([NullAllowed] string campaign, NETResult result);

	// -(void)setAdGroup:(NSString * _Nullable)adGroup result:(NETResult)result;
	[Export("setAdGroup:result:")]
	void SetAdGroup([NullAllowed] string adGroup, NETResult result);

	// -(void)setAd:(NSString * _Nullable)ad result:(NETResult)result;
	[Export("setAd:result:")]
	void SetAd([NullAllowed] string ad, NETResult result);

	// -(void)setKeyword:(NSString * _Nullable)keyword result:(NETResult)result;
	[Export("setKeyword:result:")]
	void SetKeyword([NullAllowed] string keyword, NETResult result);

	// -(void)setCreative:(NSString * _Nullable)creative result:(NETResult)result;
	[Export("setCreative:result:")]
	void SetCreative([NullAllowed] string creative, NETResult result);

	// -(void)collectDeviceIdentifiersWithResult:(NETResult)result;
	[Export("collectDeviceIdentifiersWithResult:")]
	void CollectDeviceIdentifiersWithResult(NETResult result);

	// -(void)canMakePaymentsWithFeatures:(NSArray<NSNumber *> *)features result:(NETResult)result;
	[Export("canMakePaymentsWithFeatures:result:")]
	void CanMakePaymentsWithFeatures(NSNumber[] features, NETResult result);

	// -(void)promotionalOfferForProductIdentifier:(NSString *)productIdentifier discountIdentifier:(NSString * _Nullable)discountIdentifier result:(NETResult)result;
	[Export("promotionalOfferForProductIdentifier:discountIdentifier:result:")]
	void PromotionalOfferForProductIdentifier(string productIdentifier, [NullAllowed] string discountIdentifier, NETResult result);

	// -(void)startPromotedProductPurchase:(NSNumber *)callbackID result:(NETResult)result;
	[Export("startPromotedProductPurchase:result:")]
	void StartPromotedProductPurchase(NSNumber callbackID, NETResult result);

	// -(void)closeWithResult:(NETResult)result;
	[Export("closeWithResult:")]
	void CloseWithResult(NETResult result);
}
