using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETPurchasesBinding;

namespace maui_purchases_lib;

public class NETDelegate : NETPurchasesDelegate
{
    public override void CustomerInfoUpdated(NSObject data)
    {
        
    }

    public override void ReadyForPromotedProductPurchase(NSObject data)
    {
        
    }
}