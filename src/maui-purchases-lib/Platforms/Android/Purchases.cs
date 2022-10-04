namespace maui_purchases_lib;

using Android.App;
using Android.App.AppSearch;
using Android.Content;
using Android.Test;
using Com.Hcsaba.Netpurchases;
using GoogleGson;
using Java.Lang;
using Java.Util;
using Org.Json;
using System.Diagnostics;
using System.Text.Json;
using static Com.Revenuecat.Purchases.Common.Subscriberattributes.SubscriberAttributeKey.CampaignParameters;

public partial class Purchases
{

    Context ctx;
    Android.App.Activity act;

    PurchasesNetPlugin _netPurchases;
    NETDelegate _netDelegate;

    private static Gson gson = new GsonBuilder().SerializeNulls().Create();

    private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
    {
        Converters = { new CustomJsonStringEnumConverter() },
        WriteIndented = true,
    };

    private static readonly Purchases _instance = new();

    public static Purchases Instance
    {
        get
        {
            return _instance;
        }
    }

    private Purchases()
    {
        
    }

    public void Init(Android.App.Activity activity, Context context)
    {
        ctx = context;
        act = activity;
        _netDelegate = new NETDelegate();
        _netPurchases = new PurchasesNetPlugin();
        _netPurchases.Init(act, ctx, _netDelegate);
    }

    public static dynamic Cast(dynamic obj, Type castTo)
    {
        return Convert.ChangeType(obj, castTo);
    }

    public static NETResult GetCallback<T>(Action<T>? successCallback, Action<string, string> errorCallback, Action? empty = null)
    {
        var result = new NETResult(
            successResult =>
            {
                if (successResult == null)
                {
                    empty?.Invoke();
                } 
                else if(typeof(T) == typeof(string) || typeof(T) == typeof(bool))
                {
                    var res = Cast(successResult, typeof(T));
                    successCallback(res);
                } 
                else
                {
                    var responseObject = JsonSerializer.Deserialize<T>(gson.ToJson((Object)successResult), JsonOptions)!;
                    successCallback(responseObject);
                }
            },
            (p0, p1, errorResult) =>
            {
                errorCallback(p0, p1);
            });
        return result;
    }

    public partial void Setup(string apiKey, string appUserID, bool observerMode, string? userDefaultsSuiteName, Action callback, Action<string, string> error)
    {
        _netPurchases.SetupPurchases(apiKey, appUserID, (Boolean)observerMode, Boolean.False, GetCallback<object>(null, error, callback));
    }

    public partial void SetFinishTransactions(bool finishTransactions, Action callback, Action<string, string> error)
    {
        _netPurchases.SetFinishTransactions(new Boolean(finishTransactions), GetCallback<object>(null, error, callback));
    }

    public partial void GetOfferings(Action<Offerings> callback, Action<string, string> error)
    {
        _netPurchases.GetOfferings(GetCallback(callback, error));
    }

    public partial void GetProductInfo(List<string> storeProducts, Action<List<StoreProduct>> callback, Action<string, string> error)
    {
        _netPurchases.GetProductInfo(storeProducts, null, GetCallback(callback, error));
    }

    public partial void PurchaseProduct(string productIdentifier, string discountTimestamp, Action<CustomerInfo> callback, Action<string, string> error)
    {
        _netPurchases.PurchaseProduct(productIdentifier, null, null, null, GetCallback(callback, error));
    }

    public partial void PurchasePackage(Package package, string? discountTimestamp, Action<CustomerInfo> callback, Action<string, string> error)
    {
        _netPurchases.PurchasePackage(package.Identifier, package.OfferingIdentifier, null, null, GetCallback(callback, error));
    }

    public partial void RestorePurchases(Action<CustomerInfo> callback, Action<string, string> error)
    {
        _netPurchases.RestorePurchases(GetCallback(callback, error));
    }

    public partial void SyncPurchases(Action callback, Action<string, string> error)
    {
        _netPurchases.SyncPurchases(GetCallback<object>(null, error, callback));
    }

    public partial void GetAppUserID(Action<string> callback, Action<string, string> error)
    {
        _netPurchases.GetAppUserID(GetCallback(callback, error));
    }

    public partial void LogIn(string? appUserID, Action<LogInResult> callback, Action<string, string> error)
    {
        _netPurchases.LogIn(appUserID, GetCallback(callback, error));
    }

    public partial void LogOut(Action<CustomerInfo> callback, Action<string, string> error)
    {
        _netPurchases.LogOut(GetCallback(callback, error));
    }

    public partial void SetDebugLogsEnabled(bool enabled, Action callback, Action<string, string> error)
    {
        _netPurchases.SetDebugLogsEnabled(enabled, GetCallback<object>(null, error, callback));
    }

    public partial void SetProxyURLString(string? proxyURLString, Action callback, Action<string, string> error)
    {
        _netPurchases.SetProxyURLString(proxyURLString, GetCallback<object>(null, error, callback));
    }

    public partial void GetCustomerInfo(Action<CustomerInfo> callback, Action<string, string> error)
    {
        _netPurchases.GetCustomerInfo(GetCallback(callback, error));
    }

    public partial void IsAnonymous(Action<bool> callback, Action<string, string> error)
    {
        _netPurchases.IsAnonymous(GetCallback(callback, error));
    }

    public partial void IsConfigured(Action<bool> callback, Action<string, string> error)
    {
        _netPurchases.IsConfigured(GetCallback(callback, error));
    }

    public partial void CheckTrialOrIntroductoryPriceEligibility(List<string> products, Action<Dictionary<string, IntroEligibility>> callback, Action<string, string> error)
    {
        _netPurchases.CheckTrialOrIntroductoryPriceEligibility(products, GetCallback(callback, error));
    }

    public partial void InvalidateCustomerInfoCache(Action callback, Action<string, string> error)
    {
        _netPurchases.InvalidateCustomerInfoCache(GetCallback<object>(null, error, callback));
    }

    public partial void SetAttributes(Dictionary<string, string> attributes, Action callback, Action<string, string> error)
    {
        _netPurchases.SetAttributes(attributes, GetCallback<object>(null, error, callback));
    }

    public partial void SetEmail(string email, Action callback, Action<string, string> error)
    {
        _netPurchases.SetEmail(email, GetCallback<object>(null, error, callback));
    }

    public partial void SetPhoneNumber(string phoneNumber, Action callback, Action<string, string> error)
    {
        _netPurchases.SetPhoneNumber(phoneNumber, GetCallback<object>(null, error, callback));
    }

    public partial void SetDisplayName(string displayName, Action callback, Action<string, string> error)
    {
        _netPurchases.SetDisplayName(displayName, GetCallback<object>(null, error, callback));
    }

    public partial void SetPushToken(string pushToken, Action callback, Action<string, string> error)
    {
        _netPurchases.SetPushToken(pushToken, GetCallback<object>(null, error, callback));
    }

    public partial void SetAdjustID(string? adjustID, Action callback, Action<string, string> error)
    {
        _netPurchases.SetAdjustID(adjustID, GetCallback<object>(null, error, callback));
    }

    public partial void SetAppsflyerID(string? appsflyerID, Action callback, Action<string, string> error)
    {
        _netPurchases.SetAppsflyerID(appsflyerID, GetCallback<object>(null, error, callback));
    }

    public partial void SetFBAnonymousID(string? fbAnonymousID, Action callback, Action<string, string> error)
    {
        _netPurchases.SetFBAnonymousID(fbAnonymousID, GetCallback<object>(null, error, callback));
    }

    public partial void SetMparticleID(string mparticleID, Action callback, Action<string, string> error)
    {
        _netPurchases.SetMparticleID(mparticleID, GetCallback<object>(null, error, callback));
    }

    public partial void SetOnesignalID(string? onesignalID, Action callback, Action<string, string> error)
    {
        _netPurchases.SetOnesignalID(onesignalID, GetCallback<object>(null, error, callback));
    }

    public partial void SetAirshipChannelID(string? airshipChannelID, Action callback, Action<string, string> error)
    {
        _netPurchases.SetAirshipChannelID(airshipChannelID, GetCallback<object>(null, error, callback));
    }

    public partial void SetMediaSource(string? mediaSource, Action callback, Action<string, string> error)
    {
        _netPurchases.SetMediaSource(mediaSource, GetCallback<object>(null, error, callback));
    }

    public partial void SetCampaign(string? campaign, Action callback, Action<string, string> error)
    {
        _netPurchases.SetCampaign(campaign, GetCallback<object>(null, error, callback));
    }

    public partial void SetAdGroup(string? adGroup, Action callback, Action<string, string> error)
    {
        _netPurchases.SetAdGroup(adGroup, GetCallback<object>(null, error, callback));
    }

    public partial void SetAd(string? ad, Action callback, Action<string, string> error)
    {
        _netPurchases.SetAd(ad, GetCallback<object>(null, error, callback));
    }

    public partial void SetKeyword(string? keyword, Action callback, Action<string, string> error)
    {
        _netPurchases.SetKeyword(keyword, GetCallback<object>(null, error, callback));
    }

    public partial void SetCreative(string? creative, Action callback, Action<string, string> error)
    {
        _netPurchases.SetCreative(creative, GetCallback<object>(null, error, callback));
    }

    public partial void CollectDeviceIdentifiers(Action callback, Action<string, string> error)
    {
        _netPurchases.CollectDeviceIdentifiers(GetCallback<object>(null, error, callback));
    }

    public partial void CanMakePaymentsWithFeatures(List<BillingFeature> features, Action<bool> callback, Action<string, string> error)
    {
        var featuresList = features.Select((BillingFeature f) => { return new Integer((int)f); }).ToList();
        _netPurchases.CanMakePayments(featuresList, GetCallback(callback, error));
    }

    public partial void Close(Action callback, Action<string, string> error)
    {
        _netPurchases.Close(GetCallback<object>(null, error, callback));
    }

    //iOS only
    public partial void SetAllowSharingStoreAccount(bool allowSharingStoreAccount, Action callback, Action<string, string> error) { }

    //iOS only
    public partial void PresentCodeRedemptionSheet(Action callback, Action<string, string> error) { }

    //iOS only
    public partial void GetPromotionalOffer(string productIdentifier, string? discountIdentifier, Action<PromotionalOffer> callback, Action<string, string> error) { }

    //iOS only
    public partial void StartPromotedProductPurchase(int callbackID, Action<PromotedPurchaseResult> callback, Action<string, string> error) { }

    //iOS only
    public partial void SetSimulatesAskToBuyInSandbox(bool enabled, Action callback, Action<string, string> error) { }

    //iOS Only
    public partial void SetAutomaticAppleSearchAdsAttributionCollection(bool enabled, Action callback, Action<string, string> error) { }

}