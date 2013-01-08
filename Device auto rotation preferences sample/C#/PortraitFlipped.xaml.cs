﻿//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SDKTemplate;
using System;

namespace Rotation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PortraitFlipped : SDKTemplate.Common.LayoutAwarePage
    {
        // A pointer back to the main page.  This is needed if you want to call methods in MainPage such
        // as NotifyUser()
        MainPage rootPage = MainPage.Current;

        public PortraitFlipped()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string Buffer;
            Windows.Graphics.Display.DisplayProperties.AutoRotationPreferences = Windows.Graphics.Display.DisplayOrientations.PortraitFlipped;

            if (Windows.Graphics.Display.DisplayProperties.AutoRotationPreferences == Windows.Graphics.Display.DisplayOrientations.PortraitFlipped)
            {
                Buffer = "Succeeded: The Display AutoRotation Preference is now PortraitFlipped Only.\n";
            }
            else
            {
                Buffer = "Error: failed to set the preference.\n";
            }

            PortraitFlippedOutputTextBlock.Text = Buffer;
        }
    }
}
