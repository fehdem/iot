// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Si5351
{
    /// <summary>
    /// Defines the set of device versions.
    /// </summary>
    public enum DeviceVersion
    {
        /// <summary>
        /// Device version A with XTAL input only
        /// </summary>
        A = 0,

        /// <summary>
        /// Device version B with XTAL and VCXO inputs
        /// </summary>
        B = 1,

        /// <summary>
        /// Device version C with XTAL and CLKIN inputs
        /// </summary>
        C = 2
    }
}
