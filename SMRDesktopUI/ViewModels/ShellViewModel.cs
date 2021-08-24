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


        [Obsolete]
        public ShellViewModel( IEventAggregator events, SalesViewModel salesVM)
        {
            _events = events;
            _salesVM = salesVM;


            _events.Subscribe(this);

            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }


        public Task HandleAsync(LogOnEventModel message, CancellationToken cancellationToken)
        {
            ActivateItemAsync(_salesVM);
            return Task.CompletedTask;
        }

        
    }
}
