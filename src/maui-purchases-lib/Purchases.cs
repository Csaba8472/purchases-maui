namespace maui_purchases_lib;

public partial class Purchases
{
    public partial void Setup(string apiKey, string appUserID, bool observerMode, string? userDefaultsSuiteName, Action callback, Action<string, string> error);
    public partial void SetAllowSharingStoreAccount(bool allowSharingStoreAccount, Action callback, Action<string, string> error);
    public partial void SetFinishTransactions(bool finishTransactions, Action callback, Action<string, string> error);
    public partial void GetOfferings(Action<Offerings> callback, Action<string, string> error);
    public partial void GetProductInfo(List<string> storeProducts, Action<List<StoreProduct>> callback, Action<string, string> error);
    public partial void PurchaseProduct(string productIdentifier, string discountTimestamp, Action<CustomerInfo> callback, Action<string, string> error);
    public partial void PurchasePackage(Package package, string? discountTimestamp, Action<CustomerInfo> callback, Action<string, string> error);
    public partial void RestorePurchases(Action<CustomerInfo> callback, Action<string, string> error);
    public partial void SyncPurchases(Action callback, Action<string, string> error);
    public partial void GetAppUserID(Action<string> callback, Action<string, string> error);
    public partial void LogIn(string? appUserID, Action<LogInResult> callback, Action<string, string> error);
    public partial void LogOut(Action<CustomerInfo> callback, Action<string, string> error);
    public partial void SetDebugLogsEnabled(bool enabled, Action callback, Action<string, string> error);
    public partial void SetProxyURLString(string? proxyURLString, Action callback, Action<string, string> error);
    public partial void SetSimulatesAskToBuyInSandbox(bool enabled, Action callback, Action<string, string> error);
    public partial void GetCustomerInfo(Action<CustomerInfo> callback, Action<string, string> error);
    public partial void SetAutomaticAppleSearchAdsAttributionCollection(bool enabled, Action callback, Action<string, string> error);
    public partial void IsAnonymous(Action<bool> callback, Action<string, string> error);
    public partial void IsConfigured(Action<bool> callback, Action<string, string> error);
    public partial void CheckTrialOrIntroductoryPriceEligibility(List<string> products, Action<Dictionary<string, IntroEligibility>> callback, Action<string, string> error);
    public partial void InvalidateCustomerInfoCache(Action callback, Action<string, string> error);
    public partial void PresentCodeRedemptionSheet(Action callback, Action<string, string> error);
    public partial void SetAttributes(Dictionary<string, string> attributes, Action callback, Action<string, string> error);
    public partial void SetEmail(string email, Action callback, Action<string, string> error);
    public partial void SetPhoneNumber(string phoneNumber, Action callback, Action<string, string> error);
    public partial void SetDisplayName(string displayName, Action callback, Action<string, string> error);
    public partial void SetPushToken(string pushToken, Action callback, Action<string, string> error);
    public partial void SetAdjustID(string? adjustID, Action callback, Action<string, string> error);
    public partial void SetAppsflyerID(string? appsflyerID, Action callback, Action<string, string> error);
    public partial void SetFBAnonymousID(string? fbAnonymousID, Action callback, Action<string, string> error);
    public partial void SetMparticleID(string mparticleID, Action callback, Action<string, string> error);
    public partial void SetOnesignalID(string? onesignalID, Action callback, Action<string, string> error);
    public partial void SetAirshipChannelID(string? airshipChannelID, Action callback, Action<string, string> error);
    public partial void SetMediaSource(string? mediaSource, Action callback, Action<string, string> error);
    public partial void SetCampaign(string? campaign, Action callback, Action<string, string> error);
    public partial void SetAdGroup(string? adGroup, Action callback, Action<string, string> error);
    public partial void SetAd(string? ad, Action callback, Action<string, string> error);
    public partial void SetKeyword(string? keyword, Action callback, Action<string, string> error);
    public partial void SetCreative(string? creative, Action callback, Action<string, string> error);
    public partial void CollectDeviceIdentifiers(Action callback, Action<string, string> error);
    public partial void CanMakePaymentsWithFeatures(List<BillingFeature> features, Action<bool> callback, Action<string, string> error);
    public partial void GetPromotionalOffer(string productIdentifier, string? discountIdentifier, Action<PromotionalOffer> callback, Action<string, string> error);
    public partial void StartPromotedProductPurchase(int callbackID, Action<PromotedPurchaseResult> callback, Action<string, string> error);
    public partial void Close(Action callback, Action<string, string> error);

}
