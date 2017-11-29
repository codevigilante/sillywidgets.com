using System;
using System.Threading.Tasks;
using System.IO;
using SillyWidgets;

namespace SillyWidgetsLambda
{
    public class Root : SillyController
    {
        public Root()
            : base()
        {

        }

        public ISillyView Index(ISillyContext context)
        {
            Console.WriteLine("root.Index");
            SillyView home = new SillyView();
            Task<bool> result = home.LoadS3Async("sillywidgets.com", "index.html", Amazon.RegionEndpoint.USWest1);

            result.Wait();

            Console.WriteLine(result.Result);

            if (!result.Result)
            {
                return(null);
            }
            
            home.Bind("version", "v0.5");
            
            return(home);
        }
    }
}