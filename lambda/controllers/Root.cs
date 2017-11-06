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
            Task<ISillyView> result = base.LoadViewAsync("sillywidgets.com", "index.html", Amazon.RegionEndpoint.USWest1);

            result.Wait();

            SillyView home = result.Result as SillyView;

            if (home == null)
            {
                return(null);
            }
            
            home.Bind("pagetitle", "Silly Widgets");
            home.Bind("heading", "Silly Widgets");
            home.Bind("subheading", "A silly little C# MVC framework for AWS Lambda");
            home.Bind("description", "We don't NEED another Goddamn framework! And this is the part where I'm supposed to say, \"Oh, but this one's different!\" BUT, it really isn't. It's just targeting a different platform. So if you like AWS Lambda, and hate paying for hosting that you never use, and like using C# and .NET, then maybe Silly Widgets will scratch that little spot on your taint that itches.");
            home.Bind("launchdate", "Probably November 2017, but maybe December 2017");
            home.Bind("contact", "send all inquiries to codevigilante@gmail.com");

            return(home);
        }
    }
}