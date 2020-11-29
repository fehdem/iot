// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.Si5351.Register
{
    /// <summary>
    /// Represents the set of the two clock disable state registers (CLK3-0 Disable State, CLK7-4 Disable State).
    /// The settings in this register determine the state of CLKx output when disabled.
    /// Outputs can be disabled via the Output Enable Control register (register 3) and
    /// the OEB pin.
    ///
    /// Represents the device status register.
    /// The bits of this read-only register report general device status information.
    /// </summary>
    /// <value></value>
    public record SomeRegister : IRegister
    {
        /// <summary>
        /// ...
        /// </summary>
        /// <value>...</value>
        public int Property { get; init; }

        /// <summary>
        /// Initializes a new instance of the Some Register register.
        /// </summary>
        /// <param name="property">Associated clock output (range: 0 to 7).</param>
        public SomeRegister(int property)
        {
            Property = Property;
        }

        /// <summary>
        /// Initializes a new intance of the Some Register register from a given register value.
        /// </summary>
        /// <param name="registerValue">Register value</param>
        public SomeRegister(byte registerValue)
        {
            _ = registerValue;
        }

        /// <inheritdoc/>
        public Address Address => throw new NotImplementedException();

        /// <inheritdoc/>
        public byte ToByte()
        {
            throw new NotImplementedException();
        }
    }
}
