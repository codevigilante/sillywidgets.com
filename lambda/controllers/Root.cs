using System;
using System.Threading.Tasks;
using System.IO;
using SillyWidgets;
using Amazon.DynamoDBv2.DocumentModel;

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
            SillyView home = new SillyView();
            Task<bool> result = home.LoadS3Async("sillywidgets.com", "index.html", Amazon.RegionEndpoint.USWest1);
            Task<Document> data = base.DynamoGetItemAsync(Amazon.RegionEndpoint.USWest1, "sillywidgets", "codevigilante@gmail.com");

            result.Wait();
            data.Wait();

            if (!result.Result)
            {
                return(null);
            }
            
            home.Bind(data.Result);
            
            return(home);
        }
    }
}