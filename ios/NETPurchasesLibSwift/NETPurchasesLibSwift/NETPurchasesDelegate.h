//
//  NETPurchasesDelegate.h
//  NETPurchases
//
//  Created by Csaba Huszár on 2022. 07. 26..
//

#import <Foundation/Foundation.h>

@protocol NETPurchasesDelegate <NSObject>
 
- (void)customerInfoUpdated:(id)data;
- (void)readyForPromotedProductPurchase:(id)data;

@end
