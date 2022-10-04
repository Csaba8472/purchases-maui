//
//  NETError.m
//  NETPurchases
//
//  Created by Csaba Huszár on 2022. 07. 25..
//

#import "NETError.h"

@implementation NETError
+ (instancetype)errorWithCode:(NSString*)code message:(NSString*)message details:(id)details {
  return [[NETError alloc] initWithCode:code message:message details:details];
}

- (instancetype)initWithCode:(NSString*)code message:(NSString*)message details:(id)details {
  NSAssert(code, @"Code cannot be nil");
  self = [super init];
  NSAssert(self, @"Super init cannot be nil");
    _code = code;
  _message = message;
  _details = details;
  return self;
}

- (BOOL)isEqual:(id)object {
  if (self == object) {
    return YES;
  }
  if (![object isKindOfClass:[NETError class]]) {
    return NO;
  }
    NETError* other = (NETError*)object;
  return [self.code isEqual:other.code] &&
         ((!self.message && !other.message) || [self.message isEqual:other.message]) &&
         ((!self.details && !other.details) || [self.details isEqual:other.details]);
}

- (NSUInteger)hash {
  return [self.code hash] ^ [self.message hash] ^ [self.details hash];
}
@end
