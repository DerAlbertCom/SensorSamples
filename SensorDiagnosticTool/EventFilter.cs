using System;
using System.Windows.Forms;

namespace SensorDiagnosticTool
{
    public class EventFilter<TEventArgs>
        where TEventArgs : EventArgs
    {
        private const int _DefaultTimeWindow = 150; // 150msek ist i.d.R. OK
        private Timer _timer;
        private object _pendingSender;
        private TEventArgs _pendingEventArgs;

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();

            EventHandler<TEventArgs> handler = this.FilteredEventRaised;
            if (handler != null)
                handler(_pendingSender, _pendingEventArgs);

            _pendingSender = null;
            _pendingEventArgs = null;
        }

        /// <summary>
        /// Empfänger für das zu filternde Ereignis.
        /// </summary>
        /// <param name="sender">Die Quelle des Ereignisses.</param>
        /// <param name="e">Die Ereignisargumente.</param>
        /// <remarks>
        /// Diese Methode kann direkt als Ereignismethode verwendet werden,
        /// man kann sie aber natürlich auch von einer bereits vorhandenen
        /// Ereignismethode aus aufrufen.
        /// </remarks>
        public void HandleOriginalEvent(object sender, TEventArgs e)
        {
            _timer.Stop();
            _pendingSender = sender;
            _pendingEventArgs = e;
            _timer.Start();
        }

        /// <summary>
        /// Dieses Ereignis wird ausgelöst, wenn ein "Original"-Ereignis
        /// erfolgreich den Filter passiert hat, d.h. wenn innerhalb eines
        /// bestimmten Zeitfensters kein weiteres Ereignis eingetroffen ist.
        /// </summary>
        public event EventHandler<TEventArgs> FilteredEventRaised;

        /// <summary>
        /// Initialisiert eine neue Instanz der
        /// <see cref="EventFilter&lt;TEventArgs&gt;"/> Klasse.
        /// </summary>
        /// <param name="timeWindow">
        /// Das Zeitfenster in Millisekunden (Standard: 150msek).
        /// </param>
        public EventFilter(int timeWindow)
        {
            _timer = new Timer();
            _timer.Interval = timeWindow;
            _timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der
        /// <see cref="EventFilter&lt;TEventArgs&gt;"/> Klasse.
        /// </summary>
        public EventFilter()
            : this(_DefaultTimeWindow)
        {
        }
    }
}