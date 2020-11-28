// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Device.I2c;
using Iot.Device.Si5351.Register;

namespace Iot.Device.Si5351
{
    /// <summary>
    /// Binding for the Si5351 device family.
    /// </summary>
    public class Si5351 : IDisposable
    {
        private readonly DeviceOutputs _outputs;
        private readonly DeviceVersion _version;
        private readonly IRegister[] _registerMap = new IRegister[184];
        private I2cDevice _i2cDevice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Si5351"/> binding and
        /// assembles it for the specified device version (A/B/C) and number of outputs.
        /// </summary>
        public Si5351(I2cDevice i2cDevice, DeviceVersion version, DeviceOutputs outputs)
        {
            _i2cDevice = i2cDevice ?? throw new ArgumentNullException(nameof(i2cDevice));

            // verify that the parameters specify a valid device
            if (version == DeviceVersion.A && (outputs == DeviceOutputs.FourOutputs || outputs == DeviceOutputs.EightOutputs))
            {
                throw new ArgumentException($"The combination of device version ({version}) and number of outputs ({outputs}) is not valid.");
            }

            _version = version;
            _outputs = outputs;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_i2cDevice != null)
            {
                _i2cDevice?.Dispose();
                _i2cDevice = null!;
            }
        }
    }
}
