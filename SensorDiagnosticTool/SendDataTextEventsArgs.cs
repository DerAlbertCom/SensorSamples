using System;

namespace SensorDiagnosticTool
{
    internal class SendDataTextEventsArgs : EventArgs
    {
        private readonly string _data;
        private readonly string _text;

        public SendDataTextEventsArgs(string data, string text)
        {
            _data = data;
            _text = text;
        }

        public string Data
        {
            get { return _data; }
        }

        public string Text
        {
            get { return _text; }
        }
    }
}