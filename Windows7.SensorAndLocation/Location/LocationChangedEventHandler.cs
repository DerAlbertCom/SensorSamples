// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;

namespace Windows7.Location
{
    /// <summary>
    ///     Handler for location change events.
    /// </summary>
    /// <param name="locationProvider">Location provider for which this event applies.</param>
    /// <param name="newLocation">New location report.</param>
    public delegate void LocationChangedEventHandler(LocationProvider locationProvider, LocationReport newLocation);
}