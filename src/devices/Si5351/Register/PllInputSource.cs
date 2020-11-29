// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.Si5351.Register
{
    /// <summary>
    /// Represents the PLL Input Source register.
    /// The settings in this register define the reference source of the PLL A and PLL B (SI5351A/C only).
    /// </summary>
    /// <value></value>
    public record PllInputSource : IRegister
    {
        /// <summary>
        /// Source of PLL A (CLKIN only available with SI5351C).
        /// </summary>
        public PllSource PllASource { get; init; }

        /// <summary>
        /// Source of PLL B (XTAL only available at SI5351A/C, CLKIN only available at SI5351C).
        /// </summary>
        public PllSource PllBSource { get; init; }

        /// <summary>
        /// Initializes a new instance of the PLL Input Source register.
        /// </summary>
        /// <param name="pllASource">PLLA_SRC: Source of PLL A.</param>
        /// <param name="pllBSource">PLLB_SRC: Source of PLL B.</param>
        public PllInputSource(PllSource pllASource, PllSource pllBSource)
        {
            PllASource = pllASource;
            PllBSource = pllBSource;
        }

        /// <summary>
        /// Initializes a new intance of the PLL Input Source register from a given register value.
        /// </summary>
        /// <param name="registerValue">Value of PLL Input Source register (address 15)</param>
        public PllInputSource(byte registerValue)
        {
            PllASource = (registerValue & 0b0000_0100) == 0 ? PllSource.XTAL : PllSource.CLKIN;
            PllBSource = (registerValue & 0b0000_1000) == 0 ? PllSource.XTAL : PllSource.CLKIN;
        }

        /// <inheritdoc/>
        public Address Address => Address.PllInputSource;

        /// <inheritdoc/>
        public byte ToByte()
        {
            byte registerValue = 0;
            registerValue |= PllASource == PllSource.XTAL ? 0 : 0b0000_0100;
            registerValue |= PllBSource == PllSource.XTAL ? 0 : 0b0000_1000;
            return registerValue;
        }

        /// <summary>
        /// Defines the options for PLL source.
        /// </summary>
        public enum PllSource
        {
            /// <summary>
            /// XTAL input as the reference.
            /// </summary>
            XTAL,

            /// <summary>
            /// CLKIN input as the reference.
            /// </summary>
            CLKIN
        }
    }
}
