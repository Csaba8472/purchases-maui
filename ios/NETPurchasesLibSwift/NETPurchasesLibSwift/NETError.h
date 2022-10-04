//
//  NETError.h
//  NETPurchases
//
//  Created by Csaba Huszár on 2022. 07. 25..
//

#import <Foundation/Foundation.h>

@interface NETError : NSObject
/**
 * Creates a `FlutterError` with the specified error code, message, and details.
 *
 * @param code An error code string for programmatic use.
 * @param message A human-readable error message.
 * @param details Custom error details.
 */
+ (instancetype)errorWithCode:(NSString*)code
                      message:(NSString* _Nullable)message
                      details:(id _Nullable)details;
/**
 The error code.
 */
@property(readonly, nonatomic) NSString* code;

/**
 The error message.
 */
@property(readonly, nonatomic, nullable) NSString* message;

/**
 The error details.
 */
@property(readonly, nonatomic, nullable) id details;
@end
