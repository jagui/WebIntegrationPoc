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
        private const string BaseUrl = "http://localhost:2996/Service.svc";
        private const int SecondsProcessing = 5;
        private readonly Uri _baseAddress = new Uri(BaseUrl);
        private readonly ServiceHost _serviceHost;
        private readonly Service _service;
        public MainWindowViewModel(ILog log)
        {
            _log = log;
            _service = new Service();
            _service.Request += HandleServiceRequest;
            _serviceHost = new ServiceHost(_service, _baseAddress);
            _serviceHost.Open();
            _log.Log(String.Format("The service is ready at {0}", _baseAddress));
        }

        void HandleServiceRequest(object sender, EventArgs e)
        {
            _log.Log("Serving request");
            CountDownTo(SecondsProcessing);
            _log.Log("Returning");
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
