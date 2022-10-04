//
//  NETPurchases.m
//  NETPurchases
//
//  Created by Csaba Huszár on 2022. 07. 25..
//

#import "NETPurchases.h"
@import RevenueCat;
@import StoreKit;
@import PurchasesHybridCommon;

typedef void (^RCPurchaseCompletedBlock)(RCStoreTransaction * _Nullable,
                                         RCCustomerInfo * _Nullable,
                                         NSError * _Nullable,
                                         BOOL userCancelled);
typedef void (^RCStartPurchaseBlock)(RCPurchaseCompletedBlock);

@interface NETPurchases () <RCPurchasesDelegate>

@property (nonatomic, retain) NSMutableArray<RCStartPurchaseBlock> *startPurchaseBlocks;

@end

@implementation NETPurchases

- (void)setupPurchases:(NSString *)apiKey
             appUserID:(NSString *)appUserID
          observerMode:(BOOL)observerMode
 userDefaultsSuiteName:(nullable NSString *)userDefaultsSuiteName
                result:(NETResult)result {
    if ([appUserID isKindOfClass:NSNull.class]) {
        appUserID = nil;
    }
    if ([userDefaultsSuiteName isKindOfClass:NSNull.class]) {
        userDefaultsSuiteName = nil;
    }

    [RCPurchases configureWithAPIKey:apiKey
                           appUserID:appUserID
                        observerMode:observerMode
               userDefaultsSuiteName:userDefaultsSuiteName
                      platformFlavor:self.platformFlavor
               platformFlavorVersion:self.platformFlavorVersion
            usesStoreKit2IfAvailable:true
                   dangerousSettings:nil];
    RCPurchases.sharedPurchases.delegate = self;
    result(nil);
}

- (void)setAllowSharingStoreAccount:(BOOL)allowSharingStoreAccount
                             result:(NETResult)result {
#pragma GCC diagnostic push
#pragma GCC diagnostic ignored "-Wdeprecated-declarations"
    [RCCommonFunctionality setAllowSharingStoreAccount:allowSharingStoreAccount];
#pragma GCC diagnostic pop
    result(nil);
}

- (void)setFinishTransactions:(BOOL)finishTransactions
                       result:(NETResult)result {
    [RCCommonFunctionality setFinishTransactions:finishTransactions];
    result(nil);
}

- (void)getOfferingsWithResult:(NETResult)result {
    [RCCommonFunctionality getOfferingsWithCompletionBlock:[self getResponseCompletionBlock:result]];
}

- (void)getProductInfo:(NSArray *)products
                result:(NETResult)result {
    [RCCommonFunctionality getProductInfo:products completionBlock:^(NSArray<NSDictionary *> *productObjects) {
        result(productObjects);
    }];
}

- (void)purchaseProduct:(NSString *)productIdentifier
signedDiscountTimestamp:(nullable NSString *)discountTimestamp
                 result:(NETResult)result {
    [RCCommonFunctionality purchaseProduct:productIdentifier
                   signedDiscountTimestamp:discountTimestamp
                           completionBlock:[self getResponseCompletionBlock:result]];
}

- (void)purchasePackage:(NSString *)packageIdentifier
               offering:(NSString *)offeringIdentifier
signedDiscountTimestamp:(nullable NSString *)discountTimestamp
                 result:(NETResult)result {
    [RCCommonFunctionality purchasePackage:packageIdentifier
                                  offering:offeringIdentifier
                   signedDiscountTimestamp:discountTimestamp
                           completionBlock:[self getResponseCompletionBlock:result]];
}

- (void)restorePurchasesWithResult:(NETResult)result {
    [RCCommonFunctionality restorePurchasesWithCompletionBlock:[self getResponseCompletionBlock:result]];
}

- (void)syncPurchasesWithResult:(NETResult)result {
    [RCCommonFunctionality syncPurchasesWithCompletionBlock:[self getResponseCompletionBlock:result]];
}

- (void)getAppUserIDWithResult:(NETResult)result {
    result([RCCommonFunctionality appUserID]);
}

- (void)logInAppUserID:(NSString * _Nullable)appUserID
                result:(NETResult)result {
    [RCCommonFunctionality logInWithAppUserID:appUserID completionBlock:[self getResponseCompletionBlock:result]];
}

- (void)logOutWithResult:(NETResult)result {
    [RCCommonFunctionality logOutWithCompletionBlock:[self getResponseCompletionBlock:result]];
}

- (void)setDebugLogsEnabled:(BOOL)enabled
                     result:(NETResult)result {
    [RCCommonFunctionality setDebugLogsEnabled:enabled];
    result(nil);
}

- (void)setProxyURLString:(nullable NSString *)proxyURLString
                   result:(NETResult)result {
    [RCCommonFunctionality setProxyURLString:proxyURLString];
    result(nil);
}

- (void)setSimulatesAskToBuyInSandbox:(BOOL)enabled
                               result:(NETResult)result {
    [RCCommonFunctionality setSimulatesAskToBuyInSandbox:enabled];
    result(nil);
}

- (void)getCustomerInfoWithResult:(NETResult)result {
    [RCCommonFunctionality getCustomerInfoWithCompletionBlock:[self getResponseCompletionBlock:result]];
}

- (void)setAutomaticAppleSearchAdsAttributionCollection:(BOOL)enabled
                                                 result:(NETResult)result {
    [RCCommonFunctionality setAutomaticAppleSearchAdsAttributionCollection:enabled];
    result(nil);
}

- (void)isAnonymousWithResult:(NETResult)result {
    result(@([RCCommonFunctionality isAnonymous]));
}

- (void)isConfiguredWithResult:(NETResult)result {
    result(@(RCPurchases.isConfigured));
}

- (void)checkTrialOrIntroductoryPriceEligibility:(NSArray *)products
                                          result:(NETResult)result {
    [RCCommonFunctionality checkTrialOrIntroductoryPriceEligibility:products
                                                    completionBlock:^(NSDictionary<NSString *, NSDictionary *> *_Nonnull responseDictionary) {
                                                        result([NSDictionary dictionaryWithDictionary:responseDictionary]);
                                                    }];
}

- (void)invalidateCustomerInfoCacheWithResult:(NETResult)result {
    [RCCommonFunctionality invalidateCustomerInfoCache];
    result(nil);
}

- (void)presentCodeRedemptionSheetWithResult:(NETResult)result {
#if TARGET_OS_IOS
    if (@available(iOS 14.0, *)) {
        [RCCommonFunctionality presentCodeRedemptionSheet];
    } else {
        NSLog(@"[Purchases] Warning: tried to present codeRedemptionSheet, but it's only available on iOS 14.0 or greater.");
    }
#else
    NSLog(@"[Purchases] Warning: tried to present codeRedemptionSheet, but it's only available on iOS 14.0 or greater.");
#endif
    result(nil);
}

#pragma mark Subscriber Attributes

- (void)setAttributes:(NSDictionary *)attributes result:(NETResult)result {
    [RCCommonFunctionality setAttributes:attributes];
    result(nil);
}

- (void)setEmail:(NSString *)email result:(NETResult)result {
    [RCCommonFunctionality setEmail:email];
    result(nil);
}

- (void)setPhoneNumber:(NSString *)phoneNumber result:(NETResult)result {
    [RCCommonFunctionality setPhoneNumber:phoneNumber];
    result(nil);
}

- (void)setDisplayName:(NSString *)displayName result:(NETResult)result {
    [RCCommonFunctionality setDisplayName:displayName];
    result(nil);
}

- (void)setPushToken:(NSString *)pushToken result:(NETResult)result {
    [RCCommonFunctionality setPushToken:pushToken];
    result(nil);
}

- (void)setAdjustID:(nullable NSString *)adjustID result:(NETResult)result {
    [RCCommonFunctionality setAdjustID:adjustID];
    result(nil);
}

- (void)setAppsflyerID:(nullable NSString *)appsflyerID result:(NETResult)result {
    [RCCommonFunctionality setAppsflyerID:appsflyerID];
    result(nil);
}

- (void)setFBAnonymousID:(nullable NSString *)fbAnonymousID result:(NETResult)result {
    [RCCommonFunctionality setFBAnonymousID:fbAnonymousID];
    result(nil);
}

- (void)setMparticleID:(nullable NSString *)mparticleID result:(NETResult)result {
    [RCCommonFunctionality setMparticleID:mparticleID];
    result(nil);
}

- (void)setOnesignalID:(nullable NSString *)onesignalID result:(NETResult)result {
    [RCCommonFunctionality setOnesignalID:onesignalID];
    result(nil);
}

- (void)setAirshipChannelID:(nullable NSString *)airshipChannelID result:(NETResult)result {
    [RCCommonFunctionality setAirshipChannelID:airshipChannelID];
    result(nil);
}

- (void)setMediaSource:(nullable NSString *)mediaSource result:(NETResult)result {
    [RCCommonFunctionality setMediaSource:mediaSource];
    result(nil);
}

- (void)setCampaign:(nullable NSString *)campaign result:(NETResult)result {
    [RCCommonFunctionality setCampaign:campaign];
    result(nil);
}

- (void)setAdGroup:(nullable NSString *)adGroup result:(NETResult)result {
    [RCCommonFunctionality setAdGroup:adGroup];
    result(nil);
}

- (void)setAd:(nullable NSString *)ad result:(NETResult)result {
    [RCCommonFunctionality setAd:ad];
    result(nil);
}

- (void)setKeyword:(nullable NSString *)keyword result:(NETResult)result {
    [RCCommonFunctionality setKeyword:keyword];
    result(nil);
}

- (void)setCreative:(nullable NSString *)creative result:(NETResult)result {
    [RCCommonFunctionality setCreative:creative];
    result(nil);
}

- (void)collectDeviceIdentifiersWithResult:(NETResult)result {
    [RCCommonFunctionality collectDeviceIdentifiers];
    result(nil);
}

- (void)canMakePaymentsWithFeatures:(NSArray <NSNumber *>*)features result:(NETResult)result {
    result(@([RCCommonFunctionality canMakePaymentsWithFeatures:features]));
}

- (void)promotionalOfferForProductIdentifier:(NSString *)productIdentifier
                          discountIdentifier:(nullable NSString *)discountIdentifier
                                      result:(NETResult)result {
    [RCCommonFunctionality promotionalOfferForProductIdentifier:productIdentifier
                                                       discount:discountIdentifier
                                                completionBlock:^(NSDictionary *_Nullable responseDictionary,
                                                        RCErrorContainer *_Nullable error) {
                                                    if (error) {
                                                        [self rejectWithResult:result error:error];
                                                    } else {
                                                        result(responseDictionary);
                                                    }
                                                }];
}

- (void)startPromotedProductPurchase:(NSNumber *)callbackID
                              result:(NETResult)result {
    RCStartPurchaseBlock makePurchaseBlock = [self.startPurchaseBlocks objectAtIndex:[callbackID integerValue]];
    [RCCommonFunctionality makeDeferredPurchase:makePurchaseBlock
                                completionBlock:[self getResponseCompletionBlock:result]];
}

- (void)closeWithResult:(NETResult)result {
    result(nil);
}

#pragma mark -
#pragma mark Delegate Methods

- (void)purchases:(RCPurchases *)purchases receivedUpdatedCustomerInfo:(RCCustomerInfo *)customerInfo {
    //[self.channel invokeMethod:PurchasesCustomerInfoUpdatedEvent arguments:customerInfo.dictionary];
    [self.delegate customerInfoUpdated:customerInfo.dictionary];
}

- (void)      purchases:(RCPurchases *)purchases
readyForPromotedProduct:(RCStoreProduct *)product
               purchase:(RCStartPurchaseBlock)startPurchase {
    if (!self.startPurchaseBlocks) {
        self.startPurchaseBlocks = [NSMutableArray array];
    }

    [self.startPurchaseBlocks addObject:startPurchase];
    NSInteger position = [self.startPurchaseBlocks count] - 1;
    
    /*
     [self.channel invokeMethod:PurchasesReadyForPromotedProductPurchaseEvent
                     arguments:@{@"callbackID": @(position),
                                 @"productID": product.productIdentifier
                               }];
     */
    
    [self.delegate readyForPromotedProductPurchase:@{@"callbackID": @(position),
                                                     @"productID": product.productIdentifier
                                                   }];
}


#pragma mark -
#pragma mark Helper Methods

- (void)rejectWithResult:(NETResult)result error:(RCErrorContainer *)errorContainer {
    result([NETError errorWithCode:[NSString stringWithFormat:@"%ld", (long) errorContainer.code]
                               message:errorContainer.message
                               details:errorContainer.info]);
}

- (void (^)(NSDictionary *, RCErrorContainer *))getResponseCompletionBlock:(NETResult)result {
    return ^(NSDictionary * _Nullable resultDictionary, RCErrorContainer * _Nullable error) {
        if (error) {
            [self rejectWithResult:result error:error];
        } else {
            result(resultDictionary);
        }
    };
}

- (NSString *)platformFlavor {
    return @".net-ios";
}

- (NSString *)platformFlavorVersion {
    return @"4.0.0-rc.1";
}

@end
