namespace NETPurchasesBindingTest;

using NETPurchasesBinding;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	delegate void Del(string str);


	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		// create a UIViewController with a single UILabel
		var vc = new UIViewController ();
		vc.View!.AddSubview (new UILabel (Window!.Frame) {
			BackgroundColor = UIColor.SystemBackground,
			TextAlignment = UITextAlignment.Center,
			Text = "Hello, iOS!",
			AutoresizingMask = UIViewAutoresizing.All,
		});
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		var purchase = new NETPurchases();
		purchase.Delegate = new NPD();

		NETResult del = obj => {
			Console.WriteLine($"Notification received ");

			if(obj!= null)
            {
				Console.WriteLine(obj.ToString());
            }
		};

		purchase.SetupPurchases("appl_jAifDBxaCGxqhemGewxBPzGDbpf", "1", true, null,del);

		purchase.GetOfferingsWithResult((obj) => {


            Console.WriteLine($"GetOfferingsWithResult received ");

        });
		

		return true;
	}
}

public class NPD: NETPurchasesDelegate
{
    public override void CustomerInfoUpdated(NSObject data)
    {
        //base.CustomerInfoUpdated(data);
    }

    public override void ReadyForPromotedProductPurchase(NSObject data)
    {
        //base.ReadyForPromotedProductPurchase(data);
    }
}
