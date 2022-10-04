using Com.Hcsaba.Netpurchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_purchases_lib;

public class NETResult : Java.Lang.Object, INETResult
{

    Action<Object?> successRet;
    Action<string, string?, Object?> errorRet;

    public NETResult(Action<Object?> success, Action<string, string?, Object?> error)
    {
        successRet = success;
        errorRet = error;
    }
   
    public void Error(string p0, string p1, Java.Lang.Object p2)
    {
        errorRet(p0, p1, p2);
    }

    public void NotImplemented() { }

    public void Success(Java.Lang.Object? p0)
    {
        successRet(p0);
    }
}