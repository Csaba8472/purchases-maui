package com.hcsaba.netpurchases;

import android.app.Activity;
import android.content.Context;
import androidx.annotation.Nullable;

import com.revenuecat.purchases.Purchases;
import com.revenuecat.purchases.PurchasesErrorCode;
import com.revenuecat.purchases.Store;
import com.revenuecat.purchases.common.PlatformInfo;
import com.revenuecat.purchases.hybridcommon.CommonKt;
import com.revenuecat.purchases.hybridcommon.ErrorContainer;
import com.revenuecat.purchases.hybridcommon.OnResult;
import com.revenuecat.purchases.hybridcommon.OnResultAny;
import com.revenuecat.purchases.hybridcommon.OnResultList;
import com.revenuecat.purchases.hybridcommon.SubscriberAttributesKt;
import com.revenuecat.purchases.hybridcommon.mappers.CustomerInfoMapperKt;

import org.jetbrains.annotations.NotNull;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import kotlin.UninitializedPropertyAccessException;

/**
 * PurchasesFlutterPlugin
 */
public class PurchasesNetPlugin {
    private String INVALID_ARGS_ERROR_CODE = "invalidArgs";

    private static final String CUSTOMER_INFO_UPDATED = "Purchases-CustomerInfoUpdated";

    // Only set activity for v2 embedder. Always access activity from getActivity() method.
    @Nullable
    private Context applicationContext;

    @Nullable
    private Activity activity;

    private NETPurchasesDelegate delegate;

    private static final String PLATFORM_NAME = ".net-android";
    private static final String PLUGIN_VERSION = "4.0.0-rc.1";

    // Purchases.getSharedInstance().close();

    public void init(Activity myActivity, Context appContext, NETPurchasesDelegate netPurchasesDelegate) {
        activity = myActivity;
        applicationContext = appContext;
        delegate = netPurchasesDelegate;
    }

    public void setupPurchases(String apiKey, String appUserID, @Nullable Boolean observerMode,
                                @Nullable Boolean useAmazon, final NETResult result) {
        if (this.applicationContext != null) {
            PlatformInfo platformInfo = new PlatformInfo(PLATFORM_NAME, PLUGIN_VERSION);
            Store store = Store.PLAY_STORE;
            if (useAmazon != null && useAmazon) {
                store = Store.AMAZON;
            }
            CommonKt.configure(this.applicationContext, apiKey, appUserID, observerMode,
                    platformInfo, store);
            setUpdatedCustomerInfoListener();
            result.success(null);
        } else {
            result.error(
                    String.valueOf(PurchasesErrorCode.UnknownError.getCode()),
                    "Purchases can't be setup. There is no Application context",
                    null);
        }
    }

    public void setUpdatedCustomerInfoListener() {
        Purchases.getSharedInstance().setUpdatedCustomerInfoListener(customerInfo -> {
            delegate.customerInfoUpdated(CustomerInfoMapperKt.map(customerInfo));
        });
    }

    public void setFinishTransactions(@Nullable Boolean finishTransactions, NETResult result) {
        if (finishTransactions != null) {
            CommonKt.setFinishTransactions(finishTransactions);
            result.success(null);
        } else {
            result.error(
                    INVALID_ARGS_ERROR_CODE,
                    "Missing finishTransactions argument",
                    null);
        }
    }

    @SuppressWarnings("deprecation")
    public void setAllowSharingAppStoreAccount(@Nullable Boolean allowSharingAppStoreAccount, NETResult result) {
        if (allowSharingAppStoreAccount != null) {
            CommonKt.setAllowSharingAppStoreAccount(allowSharingAppStoreAccount);
            result.success(null);
        } else {
            result.error(
                    INVALID_ARGS_ERROR_CODE,
                    "Missing allowSharing argument",
                    null);
        }
    }

    public void getOfferings(final NETResult result) {
        CommonKt.getOfferings(getOnResult(result));
    }

    public void getProductInfo(ArrayList<String> productIDs, String type, final NETResult result) {
        CommonKt.getProductInfo(productIDs, type, new OnResultList() {
            @Override
            public void onReceived(List<Map<String, ?>> map) {
                result.success(map);
            }

            @Override
            public void onError(ErrorContainer errorContainer) {
                reject(errorContainer, result);
            }
        });
    }

    public void purchaseProduct(final String productIdentifier, final String oldSKU,
                                 @Nullable final Integer prorationMode, final String type,
                                 final NETResult result) {
        CommonKt.purchaseProduct(
                activity,
                productIdentifier,
                oldSKU,
                prorationMode,
                type,
                getOnResult(result)
        );
    }

    public void purchasePackage(final String packageIdentifier,
                                 final String offeringIdentifier,
                                 @Nullable final String oldSKU,
                                 @Nullable final Integer prorationMode,
                                 final NETResult result) {
        CommonKt.purchasePackage(
                activity,
                packageIdentifier,
                offeringIdentifier,
                oldSKU,
                prorationMode,
                getOnResult(result)
        );
    }


    public void getAppUserID(final NETResult result) {
        result.success(CommonKt.getAppUserID());
    }

    public void restorePurchases(final NETResult result) {
        CommonKt.restorePurchases(getOnResult(result));
    }

    public void logOut(final NETResult result) {
        CommonKt.logOut(getOnResult(result));
    }

    public void logIn(String appUserID, final NETResult result) {
        CommonKt.logIn(appUserID, getOnResult(result));
    }

    public void setDebugLogsEnabled(boolean enabled, final NETResult result) {
        CommonKt.setDebugLogsEnabled(enabled);
        result.success(null);
    }

    public void setProxyURLString(String proxyURLString, final NETResult result) {
        CommonKt.setProxyURLString(proxyURLString);
        result.success(null);
    }

    public void getCustomerInfo(final NETResult result) {
        CommonKt.getCustomerInfo(getOnResult(result));
    }

    public void syncPurchases(final NETResult result) {
        CommonKt.syncPurchases();
        result.success(null);
    }

    public void isAnonymous(final NETResult result) {
        result.success(CommonKt.isAnonymous());
    }

    public void isConfigured(final NETResult result) {
        result.success(Purchases.isConfigured());
    }

    public void checkTrialOrIntroductoryPriceEligibility(ArrayList<String> productIDs, final NETResult result) {
        result.success(CommonKt.checkTrialOrIntroductoryPriceEligibility(productIDs));
    }

    public void invalidateCustomerInfoCache(NETResult result) {
        CommonKt.invalidateCustomerInfoCache();
        result.success(null);
    }

    //================================================================================
    // Subscriber Attributes
    //================================================================================

    public void setAttributes(Map<String, String> map, final NETResult result) {
        SubscriberAttributesKt.setAttributes(map);
        result.success(null);
    }

    public void setEmail(String email, final NETResult result) {
        SubscriberAttributesKt.setEmail(email);
        result.success(null);
    }

    public void setPhoneNumber(String phoneNumber, final NETResult result) {
        SubscriberAttributesKt.setPhoneNumber(phoneNumber);
        result.success(null);
    }

    public void setDisplayName(String displayName, final NETResult result) {
        SubscriberAttributesKt.setDisplayName(displayName);
        result.success(null);
    }

    public void setPushToken(String pushToken, final NETResult result) {
        SubscriberAttributesKt.setPushToken(pushToken);
        result.success(null);
    }

    public void setAdjustID(String adjustID, final NETResult result) {
        SubscriberAttributesKt.setAdjustID(adjustID);
        result.success(null);
    }

    public void setAppsflyerID(String appsflyerID, final NETResult result) {
        SubscriberAttributesKt.setAppsflyerID(appsflyerID);
        result.success(null);
    }

    public void setFBAnonymousID(String fbAnonymousID, final NETResult result) {
        SubscriberAttributesKt.setFBAnonymousID(fbAnonymousID);
        result.success(null);
    }

    public void setMparticleID(String mparticleID, final NETResult result) {
        SubscriberAttributesKt.setMparticleID(mparticleID);
        result.success(null);
    }

    public void setOnesignalID(String onesignalID, final NETResult result) {
        SubscriberAttributesKt.setOnesignalID(onesignalID);
        result.success(null);
    }

    public void setAirshipChannelID(String airshipChannelID, final NETResult result) {
        SubscriberAttributesKt.setAirshipChannelID(airshipChannelID);
        result.success(null);
    }

    public void setMediaSource(String mediaSource, final NETResult result) {
        SubscriberAttributesKt.setMediaSource(mediaSource);
        result.success(null);
    }

    public void setCampaign(String campaign, final NETResult result) {
        SubscriberAttributesKt.setCampaign(campaign);
        result.success(null);
    }

    public void setAdGroup(String adGroup, final NETResult result) {
        SubscriberAttributesKt.setAdGroup(adGroup);
        result.success(null);
    }

    public void setAd(String ad, final NETResult result) {
        SubscriberAttributesKt.setAd(ad);
        result.success(null);
    }

    public void setKeyword(String keyword, final NETResult result) {
        SubscriberAttributesKt.setKeyword(keyword);
        result.success(null);
    }

    public void setCreative(String creative, final NETResult result) {
        SubscriberAttributesKt.setCreative(creative);
        result.success(null);
    }

    public void collectDeviceIdentifiers(final NETResult result) {
        SubscriberAttributesKt.collectDeviceIdentifiers();
        result.success(null);
    }

    public void canMakePayments(List<Integer> features, final NETResult result) {
        CommonKt.canMakePayments(applicationContext,
                features,
                new OnResultAny<Boolean>() {
                    @Override
                    public void onReceived(Boolean aBoolean) {
                        result.success(aBoolean);
                    }

                    @Override
                    public void onError(@Nullable ErrorContainer errorContainer) {
                        result.error(String.valueOf(errorContainer.getCode()), errorContainer.getMessage(), errorContainer.getInfo());
                    }
                });
    }

    public void close(final NETResult result) {
        try {
            Purchases.getSharedInstance().close();
        } catch (UninitializedPropertyAccessException e) {
            // there's no instance so all good
        }
        result.success(null);
    }

    @NotNull
    public OnResult getOnResult(final NETResult result) {
        return new OnResult() {
            @Override
            public void onReceived(Map<String, ?> map) {
                result.success(map);
            }

            @Override
            public void onError(ErrorContainer errorContainer) {
                reject(errorContainer, result);
            }
        };
    }

    public void reject(ErrorContainer errorContainer, NETResult result) {
        result.error(String.valueOf(errorContainer.getCode()), errorContainer.getMessage(), errorContainer.getInfo());
    }

}
