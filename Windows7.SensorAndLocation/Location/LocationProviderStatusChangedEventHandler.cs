using System;

namespace Windows7.Location
{
    /// <summary>
    ///     Handler for location provider status changes events.
    /// </summary>
    /// <param name="locationProvider">Location provider for which this event applies.</param>
    /// <param name="newLocation">New status.</param>
    public delegate void LocationProviderStatusChangedEventHandler(
        LocationProvider locationProvider, ReportStatus status);
}