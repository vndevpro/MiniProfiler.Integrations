using System;

namespace MiniProfiler.Integrations
{
    public delegate string ReviewCommandTextEventHandler<in TEventArgs>(object sender, TEventArgs args) where TEventArgs : EventArgs;
}