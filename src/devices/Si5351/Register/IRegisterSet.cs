// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Iot.Device.Si5351.Register
{
    /// <summary>
    /// Si5351 register set interface
    /// </summary>
    public interface IRegisterSet
    {
        /// <summary>
        /// Gets the first address of the register set.
        /// </summary>
        /// <returns>The address of the first register.</returns>
        Address Address { get; }

        /// <summary>
        /// Gets the addresses of the registers included in the set in ascending order.
        /// </summary>
        /// <value>The addresses of the included registers.</value>
        Address[] Addresses { get; }

        /// <summary>
        /// Converts registers contents to a byte array.
        /// </summary>
        /// <returns>The array of bytes that represent the registers contents.</returns>
        byte[] ToBytes();
    }
}
