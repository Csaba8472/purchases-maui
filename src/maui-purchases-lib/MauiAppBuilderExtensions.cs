using Microsoft.Maui.LifecycleEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_purchases_lib;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseRevenuecat(this MauiAppBuilder builder, string androidAPIKey, string iosAPIKey, string appUserId)
    {
        
        builder.ConfigureLifecycleEvents(events =>
        {
#if ANDROID
            events.AddAndroid(android => android
                .OnStart((Android.App.Activity activity) =>
                {
                    Purchases.Instance.Init(activity, MauiApplication.Context);
                    Purchases.Instance.Setup(androidAPIKey, appUserId, true, null, () => { }, (code, msg) => { });
                }));
#endif

#if IOS
            events.AddiOS(ios => ios
                .FinishedLaunching((UIKit.UIApplication app, Foundation.NSDictionary launchOptions) => 
                {
                    Purchases.Instance.Setup(iosAPIKey, appUserId, true, null, () => { }, (code, msg) => { });
                    return true;
                }));
#endif
        });
        return builder;

    }
}