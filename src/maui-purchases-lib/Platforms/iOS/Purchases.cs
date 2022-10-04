using System;
using System.Linq;
using Foundation;
using System.Text.Json;
using System.Collections.Generic;
using NETPurchasesBinding;
using System.Linq;
using NetworkExtension;

namespace maui_purchases_lib;

public partial class Purchases
{
    NETPurchases _purchases = new();

    private static JsonSerializerOptions JsonOptions = new()
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
        _purchases.Delegate = new NETDelegate();
    }
    
    public static dynamic Cast(dynamic obj, Type castTo)
    {
        return Convert.ChangeType(obj, castTo);
    }

    public static NETResult GetCallback<T>(Action<T>? successCallback, Action<string, string> errorCallback, Action? empty = null)
    {
        NETResult del = obj => {
            if(obj == null)
            {
                empty?.Invoke();
            } 
            else if (obj.GetType() == typeof(NSDictionary))
            {
                NSError error;
                var json = NSJsonSerialization.Serialize((obj as NSDictionary), NSJsonWritingOptions.PrettyPrinted, out error);
                var responseObject = JsonSerializer.Deserialize<T>(json.ToString(), JsonOptions)!;
                successCallback(responseObject);
            }
            else if (obj.GetType() == typeof(NETError))
            {
                var netErrorObj = obj as NETError;
                errorCallback(netErrorObj.Code, netErrorObj.Message);
            }
            else if (obj.GetType() == typeof(NSString))
            {
                var netString = obj as NSString;
                successCallback(Cast(netString, typeof(T)));
            }
            else if (obj.GetType() == typeof(bool))
            {
                successCallback(Cast(obj, typeof(T)));
            }
            else
            {
                empty?.Invoke();
            }
        };
        return del;
    }

    public partial void Setup(string apiKey, string appUserID, bool observerMode, string? userDefaultsSuiteName, Action callback, Action<string, string> error)
    {
        _purchases.SetupPurchases(apiKey, appUserID, observerMode, userDefaultsSuiteName, GetCallback<object>(null, error, callback));
    }

    public partial void SetAllowSharingStoreAccount(bool allowSharingStoreAccount, Action callback, Action<string, string> error)
    {
        _purchases.SetAllowSharingStoreAccount(allowSharingStoreAccount, GetCallback<object>(null, error, callback));
    }

    public partial void SetFinishTransactions(bool finishTransactions, Action callback, Action<string, string> error)
    {
        _purchases.SetFinishTransactions(finishTransactions, GetCallback<object>(null, error, callback));
    }

    public partial void GetOfferings(Action<Offerings> callback, Action<string, string> error)
    {
        _purchases.GetOfferingsWithResult(GetCallback(callback, error));
    }

    public partial void GetProductInfo(List<string> storeProducts, Action<List<StoreProduct>> callback, Action<string, string> error)
    {
        _purchases.GetProductInfo(NSArray.FromObjects(storeProducts.ToArray()), GetCallback(callback, error));
    }

    public partial void PurchaseProduct(string productIdentifier, string discountTimestamp, Action<CustomerInfo> callback, Action<string, string> error)
    {
        _purchases.PurchaseProduct(productIdentifier, discountTimestamp, GetCallback(callback, error));
    }

    public partial void PurchasePackage(Package package, string? discountTimestamp, Action<CustomerInfo> callback, Action<string, string> error)
    {
        _purchases.PurchasePackage(package.Identifier, package.OfferingIdentifier, discountTimestamp, GetCallback(callback, error));
    }

    public partial void RestorePurchases(Action<CustomerInfo> callback, Action<string, string> error)
    {
        _purchases.RestorePurchasesWithResult(GetCallback(callback, error));
    }

    public partial void SyncPurchases(Action callback, Action<string, string> error)
    {
        _purchases.SyncPurchasesWithResult(GetCallback<object>(null, error, callback));
    }

    public partial void GetAppUserID(Action<string> callback, Action<string, string> error)
    {
        _purchases.GetAppUserIDWithResult(GetCallback(callback, error));
    }

    public partial void LogIn(string? appUserID, Action<LogInResult> callback, Action<string, string> error)
    {
        _purchases.LogInAppUserID(appUserID, GetCallback(callback, error));
    }

    public partial void LogOut(Action<CustomerInfo> callback, Action<string, string> error)
    {
        _purchases.LogOutWithResult(GetCallback(callback, error));
    }

    public partial void SetDebugLogsEnabled(bool enabled, Action callback, Action<string, string> error)
    {
        _purchases.SetDebugLogsEnabled(enabled, GetCallback<object>(null, error, callback));
    }

    public partial void SetProxyURLString(string? proxyURLString, Action callback, Action<string, string> error)
    {
        _purchases.SetProxyURLString(proxyURLString, GetCallback<object>(null, error, callback));
    }

    public partial void SetSimulatesAskToBuyInSandbox(bool enabled, Action callback, Action<string, string> error)
    {
        _purchases.SetSimulatesAskToBuyInSandbox(enabled, GetCallback<object>(null, error, callback));
    }

    public partial void GetCustomerInfo(Action<CustomerInfo> callback, Action<string, string> error)
    {
        _purchases.GetCustomerInfoWithResult(GetCallback(callback, error));
    }

    public partial void SetAutomaticAppleSearchAdsAttributionCollection(bool enabled, Action callback, Action<string, string> error)
    {
        _purchases.SetSimulatesAskToBuyInSandbox(enabled, GetCallback<object>(null, error, callback));
    }

    public partial void IsAnonymous(Action<Boolean> callback, Action<string, string> error)
    {
        _purchases.IsAnonymousWithResult(GetCallback(callback, error));
    }

    public partial void IsConfigured(Action<Boolean> callback, Action<string, string> error)
    {
        _purchases.IsConfiguredWithResult(GetCallback(callback, error));
    }

    public partial void CheckTrialOrIntroductoryPriceEligibility(List<string> products, Action<Dictionary<string, IntroEligibility>> callback, Action<string, string> error)
    {
        _purchases.CheckTrialOrIntroductoryPriceEligibility(NSArray.FromObjects(products.ToArray()), GetCallback(callback, error));
    }

    public partial void InvalidateCustomerInfoCache(Action callback, Action<string, string> error)
    {
        _purchases.InvalidateCustomerInfoCacheWithResult(GetCallback<object>(null, error, callback));
    }

    public partial void PresentCodeRedemptionSheet(Action callback, Action<string, string> error)
    {
        _purchases.PresentCodeRedemptionSheetWithResult(GetCallback<object>(null, error, callback));
    }

    public partial void SetAttributes(Dictionary<string, string> attributes, Action callback, Action<string, string> error)
    {
        var attributesDictionary = NSDictionary.FromObjectsAndKeys(attributes.Values.ToArray(), attributes.Keys.ToArray());
        _purchases.SetAttributes(attributesDictionary, GetCallback<object>(null, error, callback));
    }

    public partial void SetEmail(string email, Action callback, Action<string, string> error)
    {
        _purchases.SetEmail(email, GetCallback<object>(null, error, callback));
    }

    public partial void SetPhoneNumber(string phoneNumber, Action callback, Action<string, string> error)
    {
        _purchases.SetPhoneNumber(phoneNumber, GetCallback<object>(null, error, callback));
    }

    public partial void SetDisplayName(string displayName, Action callback, Action<string, string> error)
    {
        _purchases.SetDisplayName(displayName, GetCallback<object>(null, error, callback));
    }

    public partial void SetPushToken(string pushToken, Action callback, Action<string, string> error)
    {
        _purchases.SetPushToken(pushToken, GetCallback<object>(null, error, callback));
    }

    public partial void SetAdjustID(string? adjustID, Action callback, Action<string, string> error)
    {
        _purchases.SetAdjustID(adjustID, GetCallback<object>(null, error, callback));
    }

    public partial void SetAppsflyerID(string? appsflyerID, Action callback, Action<string, string> error)
    {
        _purchases.SetAppsflyerID(appsflyerID, GetCallback<object>(null, error, callback));
    }

    public partial void SetFBAnonymousID(string? fbAnonymousID, Action callback, Action<string, string> error)
    {
        _purchases.SetFBAnonymousID(fbAnonymousID, GetCallback<object>(null, error, callback));
    }

    public partial void SetMparticleID(string mparticleID, Action callback, Action<string, string> error)
    {
        _purchases.SetMparticleID(mparticleID, GetCallback<object>(null, error, callback));
    }

    public partial void SetOnesignalID(string? onesignalID, Action callback, Action<string, string> error)
    {
        _purchases.SetOnesignalID(onesignalID, GetCallback<object>(null, error, callback));
    }

    public partial void SetAirshipChannelID(string? airshipChannelID, Action callback, Action<string, string> error)
    {
        _purchases.SetAirshipChannelID(airshipChannelID, GetCallback<object>(null, error, callback));
    }

    public partial void SetMediaSource(string? mediaSource, Action callback, Action<string, string> error)
    {
        _purchases.SetMediaSource(mediaSource, GetCallback<object>(null, error, callback));
    }

    public partial void SetCampaign(string? campaign, Action callback, Action<string, string> error)
    {
        _purchases.SetCampaign(campaign, GetCallback<object>(null, error, callback));
    }

    public partial void SetAdGroup(string? adGroup, Action callback, Action<string, string> error)
    {
        _purchases.SetAdGroup(adGroup, GetCallback<object>(null, error, callback));
    }

    public partial void SetAd(string? ad, Action callback, Action<string, string> error)
    {
        _purchases.SetAd(ad, GetCallback<object>(null, error, callback));
    }

    public partial void SetKeyword(string? keyword, Action callback, Action<string, string> error)
    {
        _purchases.SetKeyword(keyword, GetCallback<object>(null, error, callback));
    }

    public partial void SetCreative(string? creative, Action callback, Action<string, string> error)
    {
        _purchases.SetCreative(creative, GetCallback<object>(null, error, callback));
    }

    public partial void CollectDeviceIdentifiers(Action callback, Action<string, string> error)
    {
        _purchases.CollectDeviceIdentifiersWithResult(GetCallback<object>(null, error, callback));
    }

    public partial void CanMakePaymentsWithFeatures(List<BillingFeature> features, Action<Boolean> callback, Action<string, string> error)
    {
        var featuresList = features.ToArray().Select((BillingFeature f) => { return NSNumber.FromInt32((int)f); }).ToArray();
        _purchases.CanMakePaymentsWithFeatures(featuresList, GetCallback(callback, error));
    }

    public partial void GetPromotionalOffer(string productIdentifier, string? discountIdentifier, Action<PromotionalOffer> callback, Action<string, string> error)
    {
        _purchases.PromotionalOfferForProductIdentifier(productIdentifier, discountIdentifier, GetCallback(callback, error));
    }

    public partial void StartPromotedProductPurchase(int callbackID, Action<PromotedPurchaseResult> callback, Action<string, string> error)
    {
        _purchases.StartPromotedProductPurchase(callbackID, GetCallback(callback, error));
    }

    public partial void Close(Action callback, Action<string, string> error)
    {
        _purchases.CloseWithResult(GetCallback<object>(null, error, callback));
    }
}