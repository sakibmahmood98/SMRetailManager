using Caliburn.Micro;
using SMRDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMRDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEventModel>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;

        [Obsolete]
        public ShellViewModel( IEventAggregator events, SalesViewModel salesVM,
            SimpleContainer container)
        {
            _events = events;
            _salesVM = salesVM;
            _container = container;

            _events.Subscribe(this);

            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
        }


        public Task HandleAsync(LogOnEventModel message, CancellationToken cancellationToken)
        {
            ActivateItemAsync(_salesVM);
            return Task.CompletedTask;
        }

        
    }
}
