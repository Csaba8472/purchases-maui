namespace NETPurchasesBindingTest;

using System.Collections.Generic;
using Com.Hcsaba.Netpurchases;
using Java.Lang;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var netDelegate = new NETDelegate();

        var netResult = new NETResult();

        var x = new PurchasesNetPlugin();

        x.Init(this, Application.Context, netDelegate);

        x.SetupPurchases("goog_ilXEdtkQRwyrwaukCSXAHxDJNCe", "", Java.Lang.Boolean.True, Java.Lang.Boolean.False, netResult);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
    }
}

public class NETDelegate : Java.Lang.Object, INETPurchasesDelegate
{
    public void CustomerInfoUpdated(IDictionary<string, object>? p0)
    {
        
    }
}

public class NETResult : Java.Lang.Object, INETResult
{
    public void Error(string p0, string? p1, Object? p2)
    {
        
    }

    public void NotImplemented()
    {
        
    }

    public void Success(Object? p0)
    {
        
    }
}