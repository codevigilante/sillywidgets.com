using System;
using SillyWidgets;

namespace SillyWidgetsLambda
{
    public class SillyWidgetsProxy : SillyProxyApplication
    {
        public SillyWidgetsProxy()
            : base()
        {
            base.RegisterController("root", new Root());

            GET("root", "/", "root", "Index");
        }
    }
}
