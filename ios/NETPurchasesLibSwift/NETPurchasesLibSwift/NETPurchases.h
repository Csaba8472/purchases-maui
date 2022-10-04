//
//  NETPurchases.h
//  NETPurchases
//
//  Created by Csaba Huszár on 2022. 07. 25..
//

#import <Foundation/Foundation.h>

#import "NETError.h"
#import "NETPurchasesDelegate.h"

typedef void (^NETResult)(id _Nullable result);

@interface NETPurchases : NSObject

@property(nonatomic, weak) id <NETPurchasesDelegate> delegate;

- (void)setupPurchases:(NSString *)apiKey
             appUserID:(NSString *)appUserID
          observerMode:(BOOL)observerMode
 userDefaultsSuiteName:(nullable NSString *)userDefaultsSuiteName
                result:(NETResult)result;

- (void)setAllowSharingStoreAccount:(BOOL)allowSharingStoreAccount
                             result:(NETResult)resul;


- (void)setFinishTransactions:(BOOL)finishTransactions
                       result:(NETResult)result;

- (void)getOfferingsWithResult:(NETResult)result ;

- (void)getProductInfo:(NSArray *)products
                result:(NETResult)result;

- (void)purchaseProduct:(NSString *)productIdentifier
signedDiscountTimestamp:(nullable NSString *)discountTimestamp
                 result:(NETResult)result ;

- (void)purchasePackage:(NSString *)packageIdentifier
               offering:(NSString *)offeringIdentifier
signedDiscountTimestamp:(nullable NSString *)discountTimestamp
                 result:(NETResult)result ;

- (void)restorePurchasesWithResult:(NETResult)result ;

- (void)syncPurchasesWithResult:(NETResult)result ;

- (void)getAppUserIDWithResult:(NETResult)result ;
- (void)logInAppUserID:(NSString * _Nullable)appUserID
                result:(NETResult)result;
- (void)logOutWithResult:(NETResult)result;
- (void)setDebugLogsEnabled:(BOOL)enabled
                     result:(NETResult)result ;

- (void)setProxyURLString:(nullable NSString *)proxyURLString
                   result:(NETResult)result ;

- (void)setSimulatesAskToBuyInSandbox:(BOOL)enabled
                               result:(NETResult)result;

- (void)getCustomerInfoWithResult:(NETResult)result ;

- (void)setAutomaticAppleSearchAdsAttributionCollection:(BOOL)enabled
                                                 result:(NETResult)result ;
- (void)isAnonymousWithResult:(NETResult)result ;
- (void)isConfiguredWithResult:(NETResult)result ;
- (void)checkTrialOrIntroductoryPriceEligibility:(NSArray *)products
                                          result:(NETResult)result;
- (void)invalidateCustomerInfoCacheWithResult:(NETResult)result;
- (void)presentCodeRedemptionSheetWithResult:(NETResult)result ;

#pragma mark Subscriber Attributes

- (void)setAttributes:(NSDictionary *)attributes result:(NETResult)result ;

- (void)setEmail:(NSString *)email result:(NETResult)result ;

- (void)setPhoneNumber:(NSString *)phoneNumber result:(NETResult)result;

- (void)setDisplayName:(NSString *)displayName result:(NETResult)result;
- (void)setPushToken:(NSString *)pushToken result:(NETResult)result;

- (void)setAdjustID:(nullable NSString *)adjustID result:(NETResult)result ;
- (void)setAppsflyerID:(nullable NSString *)appsflyerID result:(NETResult)result ;
- (void)setFBAnonymousID:(nullable NSString *)fbAnonymousID result:(NETResult)result ;
- (void)setMparticleID:(nullable NSString *)mparticleID result:(NETResult)result;
- (void)setOnesignalID:(nullable NSString *)onesignalID result:(NETResult)result;

- (void)setAirshipChannelID:(nullable NSString *)airshipChannelID result:(NETResult)result;
- (void)setMediaSource:(nullable NSString *)mediaSource result:(NETResult)result ;
- (void)setCampaign:(nullable NSString *)campaign result:(NETResult)result;
- (void)setAdGroup:(nullable NSString *)adGroup result:(NETResult)result ;
- (void)setAd:(nullable NSString *)ad result:(NETResult)result ;

- (void)setKeyword:(nullable NSString *)keyword result:(NETResult)result ;

- (void)setCreative:(nullable NSString *)creative result:(NETResult)result;

- (void)collectDeviceIdentifiersWithResult:(NETResult)result ;

- (void)canMakePaymentsWithFeatures:(NSArray <NSNumber *>*)features result:(NETResult)result ;

- (void)promotionalOfferForProductIdentifier:(NSString *)productIdentifier
                          discountIdentifier:(nullable NSString *)discountIdentifier
                                      result:(NETResult)result;

- (void)startPromotedProductPurchase:(NSNumber *)callbackID
                              result:(NETResult)result ;
- (void)closeWithResult:(NETResult)result;
@end
