using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ch20Ex05
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AppControlService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AppControlService : IAppControlService
    {
        private MainWindow hostApp;
        public AppControlService(MainWindow hostApp)
        {
            this.hostApp = hostApp;
        }
        public void SetRadius(int radius, string foreTo, int seconds)
        {
            hostApp.SetRadius(radius, foreTo, new TimeSpan(0, 0, seconds));
        }

    }
}
