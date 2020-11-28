// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Si5351.Register
{
    /// <summary>
    /// Defines the register address of the Si5153A/B/C device.
    /// </summary>
    public enum Address : byte
    {
        /// <summary>
        /// CLK0 Control - register 16
        /// </summary>
        CLK0 = 16,

        /// <summary>
        /// CLK1 Control - register 17
        /// </summary>
        CLK1 = 17,

        /// <summary>
        /// CLK2 Control - register 18
        /// </summary>
        CLK2 = 18,

        /// <summary>
        /// CLK3 Control - register 19
        /// </summary>
        CLK3 = 19,

        /// <summary>
        /// CLK4 Control - register 20
        /// </summary>
        CLK4 = 20,

        /// <summary>
        /// CLK5 Control - register 21
        /// </summary>
        CLK5 = 21,

        /// <summary>
        /// CLK6 Control - register 22
        /// </summary>
        CLK6 = 22,

        /// <summary>
        /// CLK7 Control - register 23
        /// </summary>
        CLK7 = 23,

        /// <summary>
        /// CLK3-0 Disable State - register 24
        /// </summary>
        CLK30DISSTATE = 24,

        /// <summary>
        /// CLK7-4 Disable State - register 25
        /// </summary>
        CLK74DISSTATE = 25
    }
}