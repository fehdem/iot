// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Si5351.Register
{
    /// <summary>
    /// Si5361 register interface
    /// </summary>
    public interface IRegister
    {
        /// <summary>
        /// Gets the address of the register.
        /// </summary>
        /// <returns>The address of the register.</returns>
        Address Address { get; }

        /// <summary>
        /// Converts register contents to a byte.
        /// </summary>
        /// <returns>The byte that represent the register contents.</returns>
        byte ToByte();
    }
}
