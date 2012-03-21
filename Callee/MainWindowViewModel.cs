using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using WcfService;

namespace Callee
{
    public class MainWindowViewModel : IDisposable
    {
        private readonly ILog _log;
        private const int SecondsProcessing = 5;
        private readonly ServiceHost _serviceHost;
        private readonly Service _service;
        public MainWindowViewModel(ILog log)
        {
            _log = log;
            _service = new Service();
            _service.HandleRequest += HandleServiceRequest;
            _serviceHost = new ServiceHost(_service);
            _serviceHost.Open();
            _log.Log(String.Format("The service is ready at {0}", _serviceHost.BaseAddresses.First()));
        }

        string HandleServiceRequest(Service service, string s)
        {
            _log.Log(String.Format("Serving request {0}", s));
            CountDownTo(SecondsProcessing);
            var retval = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
            _log.Log(String.Format("Returning {0}", retval));
            return retval;
        }

        private void CountDownTo(int seconds)
        {
            _log.Log(String.Format("Finishing in {0}", seconds));
            var remaining = seconds;
            do
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                remaining--;
                _log.Log(remaining.ToString(CultureInfo.InvariantCulture));
            } while (remaining > 0);
        }

        public void Dispose()
        {
            _serviceHost.Close();
        }
    }
}
