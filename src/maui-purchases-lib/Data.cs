using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace maui_purchases_lib;


public class PromotedPurchaseResult
{
    /// the productIdentifier associated with the promoted purchase
    [JsonPropertyName("productIdentifier")]
    string ProductIdentifier;

    /// the customerInfo associated with the promoted purchase
    [JsonPropertyName("customerInfo")]
    CustomerInfo CustomerInfo;
}

/// Billing Feature types
public enum BillingFeature
{
    /// [https://developer.android.com/reference/com/android/
    /// billingclient/api/BillingClient.FeatureType#SUBSCRIPTIONS]
    [EnumMember(Value = "subscriptions")]
    Subscriptions,

    /// [https://developer.android.com/reference/com/android/
    /// billingclient/api/BillingClient.FeatureType#SUBSCRIPTIONS_UPDATE]
    [EnumMember(Value = "subscriptionsUpdate")]
    SubscriptionsUpdate,

    /// [https://developer.android.com/reference/com/android/
    /// billingclient/api/BillingClient.FeatureType#IN_APP_ITEMS_ON_VR]
    [EnumMember(Value = "inAppItemsOnVr")]
    InAppItemsOnVr,

    /// [https://developer.android.com/reference/com/android/
    /// billingclient/api/BillingClient.FeatureType#SUBSCRIPTIONS_ON_VR]
    [EnumMember(Value = "subscriptionsOnVr")]
    SubscriptionsOnVr,

    /// [https://developer.android.com/reference/com/android/
    /// billingclient/api/BillingClient.FeatureType#PRICE_CHANGE_CONFIRMATION]
    [EnumMember(Value = "priceChangeConfirmation")]
    PriceChangeConfirmation,
}

/// Possible IntroEligibility status.
/// Use [checkTrialOrIntroductoryPriceEligibility] to determine the eligibility
public enum IntroEligibilityStatus
{
    [EnumMember(Value = "introEligibilityStatusUnknown")]
    IntroEligibilityStatusUnknown,
    [EnumMember(Value = "introEligibilityStatusIneligible")]
    IntroEligibilityStatusIneligible,
    [EnumMember(Value = "introEligibilityStatusEligible")]
    IntroEligibilityStatusEligible,
    [EnumMember(Value = "introEligibilityStatusNoIntroOfferExists")]
    IntroEligibilityStatusNoIntroOfferExists,
}


/// Holds the introductory price status
public class IntroEligibility
{
    /// The introductory price eligibility status
    [JsonPropertyName("status")]
    IntroEligibilityStatus status;

    /// Description of the status
    [JsonPropertyName("description")]
    string description;
}

public class LogInResult
{
    /// true if the logged in user has been created in the
    /// RevenueCat backend for the first time

    [JsonPropertyName("created")]
    bool Created;

    /// the [CustomerInfo] associated to the logged in user
    [JsonPropertyName("customerInfo")]
    CustomerInfo CustomerInfo;
}

public class Offerings
{
    [JsonPropertyName("all")]
    public Dictionary<string, Offering> All { get; set; }

    [JsonPropertyName("current")]
    public Offering? Current { get; set; }
}

public class Offering
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    [JsonPropertyName("serverDescription")]
    public string ServerDescription { get; set; }

    [JsonPropertyName("availablePackages")]
    public List<Package> AvailablePackages { get; set; }

    [JsonPropertyName("lifetime")]
    public Package? Lifetime { get; set; }

    [JsonPropertyName("annual")]
    public Package? Annual { get; set; }

    [JsonPropertyName("sixmonth")]
    public Package? Sixmonth { get; set; }

    [JsonPropertyName("threemonth")]
    public Package? Threemonth { get; set; }

    [JsonPropertyName("twomonth")]
    public Package? Twomonth { get; set; }

    [JsonPropertyName("monthly")]
    public Package? Monthly { get; set; }

    [JsonPropertyName("weekly")]
    public Package? Weekly { get; set; }
    
}

public class Package
{
    [JsonPropertyName("offeringIdentifier")]
    public string OfferingIdentifier { get; set; }

    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    [JsonPropertyName("packageType")]
    public PackageType PackageType { get; set; }

    [JsonPropertyName("product")]
    public StoreProduct StoreProduct { get; set; }
}

public enum PackageType
{
    [EnumMember(Value = "CUSTOM")]
    CUSTOM,
    [EnumMember(Value = "LIFETIME")]
    LIFETIME,
    [EnumMember(Value = "ANNUAL")]
    ANNUAL,
    [EnumMember(Value = "SIX_MONTH")]
    SIX_MONTH,
    [EnumMember(Value = "THREE_MONTH")]
    THREE_MONTH,
    [EnumMember(Value = "TWO_MONTH")]
    TWO_MONTH,
    [EnumMember(Value = "MONTHLY")]
    MONTHLY,
    [EnumMember(Value = "WEEKLY")]
    WEEKLY,
    UNKNOWN
}



public class IntroductoryPrice
{
    [JsonPropertyName("periodNumberOfUnits")]
    public int PeriodNumberOfUnits { get; set; }

    [JsonPropertyName("cycles")]
    public int Cycles { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("priceString")]
    public string PriceString { get; set; }

    [JsonPropertyName("period")]
    public string Period { get; set; }

    [JsonPropertyName("periodUnit")]
    public PeriodUnit PeriodUnit { get; set; }
}

public enum PeriodUnit
{
    [EnumMember(Value = "DAY")]
    DAY,
    [EnumMember(Value = "WEEK")]
    WEEK,
    [EnumMember(Value = "MONTH")]
    MONTH,
    [EnumMember(Value = "YEAR")]
    YEAR,
    UNKNOWN
}


public class StoreProductDiscount
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    [JsonPropertyName("periodNumberOfUnits")]
    public int PeriodNumberOfUnits { get; set; }

    [JsonPropertyName("cycles")]
    public int Cycles { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("priceString")]
    public string PriceString { get; set; }

    [JsonPropertyName("period")]
    public string Period { get; set; }

    [JsonPropertyName("periodUnit")]
    public string PeriodUnit { get; set; }
}

public class StoreProduct
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("price")]
    public double Price { get; set; }
    [JsonPropertyName("priceString")]
    public string PriceString { get; set; }
    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }
    [JsonPropertyName("introPrice")]
    public IntroductoryPrice IntroductoryPrice { get; set; }
    [JsonPropertyName("discounts")]
    public List<StoreProductDiscount> Discounts { get; set; }
}

public class PromotionalOffer
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }
    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }
    [JsonPropertyName("signature")]
    public string Signature { get; set; }
    [JsonPropertyName("nonce")]
    public string Nonce { get; set; }
    [JsonPropertyName("keyIdentifier")]
    public string KeyIdentifier { get; set; }
    

}

public class StoreTransaction
{
    [JsonPropertyName("revenueCatId")]
    public string RevenueCatIdentifier { get; set; }
    [JsonPropertyName("productId")]
    public string ProductIdentifier { get; set; }
    [JsonPropertyName("purchaseDate")]
    public string PurchaseDate { get; set; }
}

public enum Store
{
    /// For entitlements granted via Apple App Store.
    [EnumMember(Value = "APP_STORE")]
    APP_STORE,

    /// For entitlements granted via Apple Mac App Store.
    [EnumMember(Value = "MAC_APP_STORE")]
    MAC_APP_STORE,

    /// For entitlements granted via Google Play Store.
    [EnumMember(Value = "PLAY_STORE")]
    PLAY_STORE,

    /// For entitlements granted via Stripe.
    [EnumMember(Value = "STRIPE")]
    STRIPE,

    /// For entitlements granted via a promo in RevenueCat.
    [EnumMember(Value = "PROMOTIONAL")]
    PROMOTIONAL,

    /// For entitlements granted via an unknown store.
    [EnumMember(Value = "AMAZON")]
    AMAZON,

    /// For entitlements granted via Amazon Appstore.
  UNKNOWN,
}

public class EntitlementInfos
{
    [JsonPropertyName("all")]
    public Dictionary<string, EntitlementInfo> All { get; set; }

    [JsonPropertyName("active")]
    public EntitlementInfo? Active { get; set; }
}

/// Class containing all information regarding the customer
public class CustomerInfo
{
    /// Entitlements attached to this customer info
    [JsonPropertyName("entitlements")]
    public EntitlementInfos Entitlements { get; set; }

    [JsonPropertyName("allPurchaseDates")]
    Dictionary<string, string> AllPurchaseDates { get; set; }

    /// Set of active subscription skus
    [JsonPropertyName("activeSubscriptions")]
    List<string> ActiveSubscriptions { get; set; }

    /// Set of purchased skus, active and inactive

    [JsonPropertyName("allPurchasedProductIdentifiers")]
    List<string> AllPurchasedProductIdentifiers { get; set; }

    /// Returns all the non-subscription purchases a user has made.
    /// The purchases are ordered by purchase date in ascending order.

    [JsonPropertyName("nonSubscriptionTransactions")]
    List<StoreTransaction> NonSubscriptionTransactions { get; set; }

    /// The date this user was first seen in RevenueCat.

    [JsonPropertyName("firstSeen")]
    string FirstSeen { get; set; }

    /// The original App User Id recorded for this user.

    [JsonPropertyName("originalAppUserId")]
    string OriginalAppUserId { get; set; }

    /// Map of skus to expiration dates

    [JsonPropertyName("allExpirationDates")]
    Dictionary<string, string?> AllExpirationDates { get; set; }

    /// Date when this info was requested

    [JsonPropertyName("requestDate")]
    string RequestDate { get; set; }

    /// The latest expiration date of all purchased skus

    [JsonPropertyName("latestExpirationDate")]
    string? LatestExpirationDate { get; set; }

    /// Returns the purchase date for the version of the application when the user bought the app.
    /// Use this for grandfathering users when migrating to subscriptions.

    [JsonPropertyName("originalPurchaseDate")]
    string? OriginalPurchaseDate { get; set; }

    /// Returns the version number for the version of the application when the
    /// user bought the app. Use this for grandfathering users when migrating
    /// to subscriptions.
    ///
    /// This corresponds to the value of CFBundleVersion (in iOS) in the
    /// Info.plist file when the purchase was originally made. This is always null
    /// in Android

    [JsonPropertyName("originalApplicationVersion")]
    string? OriginalApplicationVersion { get; set; }

    /// URL to manage the active subscription of the user. If this user has an active iOS
    /// subscription, this will point to the App Store, if the user has an active Play Store subscription
    /// it will point there. If there are no active subscriptions it will be null.
    /// If there are multiple for different platforms, it will point to the device store.

    [JsonPropertyName("managementURL")]
    string? ManagementURL { get; set; }
}


public enum PeriodType
{
    /// If the entitlement is under a introductory price period.
    [EnumMember(Value = "INTRO")]
    INTRO,

    /// If the entitlement is not under an introductory or trial period.
    [EnumMember(Value = "NORMAL")]
    NORMAL,

    /// If the entitlement is under a trial period.
    [EnumMember(Value = "TRIAL")]
    TRIAL,

    /// If the period type couldn't be determined.
    UNKNOWN
}

/// Enum of ownership types
public enum OwnershipType
{
    /// The purchase was made directly by this user.
    [EnumMember(Value = "PURCHASED")]
    PURCHASED,

    /// The purchase has been shared to this user by a family member.
    [EnumMember(Value = "FAMILY_SHARED")]
    FAMILY_SHARED,

    /// The purchase has no or an unknown ownership type.
    UNKNOWN
}

public class EntitlementInfo {

        [JsonPropertyName("identifier")]
        string Identifier { get; set; }

    /// True if the user has access to this entitlement
    
        [JsonPropertyName("isActive")]
    bool IsActive { get; set; }

    /// True if the underlying subscription is set to renew at the end of
    /// the billing period (expirationDate).
    [JsonPropertyName("willRenew")]
    bool WillRenew { get; set; }

    /// The latest purchase or renewal date for the entitlement.
    [JsonPropertyName("latestPurchaseDate")]
        string LatestPurchaseDate { get; set; }

    /// The first date this entitlement was purchased
    [JsonPropertyName("originalPurchaseDate")]
    string OriginalPurchaseDate { get; set; }

    /// The product identifier that unlocked this entitlement
    [JsonPropertyName("productIdentifier")]
    string ProductIdentifier { get; set; }

    /// False if this entitlement is unlocked via a production purchase
    [JsonPropertyName("isSandbox")]
    bool IsSandbox { get; set; }

    /// Use this property to determine whether a purchase was made by the current
    /// user or shared to them by a family member. This can be useful for
    /// onboarding users who have had an entitlement shared with them, but might
    /// not be entirely aware of the benefits they now have.
    [JsonPropertyName("ownershipType")]
    OwnershipType OwnershipType { get; set; }

    /// The store where this entitlement was unlocked from
   [JsonPropertyName("store")]
        Store Store { get; set; }

    /// The last period type this entitlement was in
    [JsonPropertyName("periodType")]
    PeriodType PeriodType { get; set; }

    /// The expiration date for the entitlement, can be null for lifetime access.
    /// If the [periodType] is [PeriodType.trial],
    /// this is the trial expiration date.
    [JsonPropertyName("expirationDate")]
    string? ExpirationDate { get; set; }

    /// The date an unsubscribe was detected. Can be null if it's still
    /// subscribed or product is not a subscription.
    /// @note: Entitlement may still be active even if user has unsubscribed.
    /// Check the [isActive] property.
    [JsonPropertyName("unsubscribeDetectedAt")]
    string? UnsubscribeDetectedAt { get; set; }

    /// The date a billing issue was detected. Can be null if there is no
    /// billing issue or an issue has been resolved.
    /// @note: Entitlement may still be active even if there is a billing issue.
    /// Check the [isActive] property.
    [JsonPropertyName("billingIssueDetectedAt")]
    string? BillingIssueDetectedAt { get; set; }

}

public class CustomJsonStringEnumConverter : JsonConverterFactory
{
    private readonly JsonNamingPolicy namingPolicy;
    private readonly bool allowIntegerValues;
    private readonly JsonStringEnumConverter baseConverter;

    public CustomJsonStringEnumConverter() : this(null, true) { }

    public CustomJsonStringEnumConverter(JsonNamingPolicy namingPolicy = null, bool allowIntegerValues = true)
    {
        this.namingPolicy = namingPolicy;
        this.allowIntegerValues = allowIntegerValues;
        this.baseConverter = new JsonStringEnumConverter(namingPolicy, allowIntegerValues);
    }

    public override bool CanConvert(Type typeToConvert) => baseConverter.CanConvert(typeToConvert);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
                    let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                    where attr != null
                    select (field.Name, attr.Value);
        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        if (dictionary.Count > 0)
        {
            return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, namingPolicy), allowIntegerValues).CreateConverter(typeToConvert, options);
        }
        else
        {
            return baseConverter.CreateConverter(typeToConvert, options);
        }
    }
}

public class JsonNamingPolicyDecorator : JsonNamingPolicy
{
    readonly JsonNamingPolicy underlyingNamingPolicy;

    public JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy) => this.underlyingNamingPolicy = underlyingNamingPolicy;

    public override string ConvertName(string name) => underlyingNamingPolicy == null ? name : underlyingNamingPolicy.ConvertName(name);
}

internal class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator
{
    readonly Dictionary<string, string> dictionary;

    public DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy underlyingNamingPolicy) : base(underlyingNamingPolicy) => this.dictionary = dictionary ?? throw new ArgumentNullException();

    public override string ConvertName(string name) => dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
}