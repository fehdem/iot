// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Iot.Device.Si5351.Register;

namespace Iot.Device.Si5351
{
    /// <summary>
    /// Represents a single output block of the Si5351 device.
    /// </summary>
    internal class OutputBlock
    {
        private ClockControl _clockControlRegister;

        public OutputBlock()
        {
            _clockControlRegister = new ClockControl(1, 0);
        }
    }
}