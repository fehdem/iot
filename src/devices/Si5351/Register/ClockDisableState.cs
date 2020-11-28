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
    /// </summary>
    public record ClockDisableState : IRegisterSet
    {
        private readonly byte[] _buffer = new byte[2];

        /// <summary>
        /// Disable state of clock output 0.
        /// </summary>
        public DisableState ClockOutput0 { get; init; }

        /// <summary>
        /// Disable state of clock output 1.
        /// </summary>
        public DisableState ClockOutput1 { get; init; }

        /// <summary>
        /// Disable state of clock output 2.
        /// </summary>
        public DisableState ClockOutput2 { get; init; }

        /// <summary>
        /// Disable state of clock output 3.
        /// </summary>
        public DisableState ClockOutput3 { get; init; }

        /// <summary>
        /// Disable state of clock output 4.
        /// </summary>
        public DisableState ClockOutput4 { get; init; }

        /// <summary>
        /// Disable state of clock output 5.
        /// </summary>
        public DisableState ClockOutput5 { get; init; }

        /// <summary>
        /// Disable state of clock output 6.
        /// </summary>
        public DisableState ClockOutput6 { get; init; }

        /// <summary>
        /// Disable state of clock output 7.
        /// </summary>
        public DisableState ClockOutput7 { get; init; }

        /// <summary>
        /// Initializes a new instance of a clock disable state register set.
        /// </summary>
        public ClockDisableState(DisableState clockOutput0,
                                  DisableState clockOutput1,
                                  DisableState clockOutput2,
                                  DisableState clockOutput3,
                                  DisableState clockOutput4,
                                  DisableState clockOutput5,
                                  DisableState clockOutput6,
                                  DisableState clockOutput7)
        {
            ClockOutput0 = clockOutput0;
            ClockOutput1 = clockOutput1;
            ClockOutput2 = clockOutput2;
            ClockOutput3 = clockOutput3;
            ClockOutput4 = clockOutput4;
            ClockOutput5 = clockOutput5;
            ClockOutput6 = clockOutput6;
            ClockOutput7 = clockOutput7;
        }

        /// <summary>
        /// Initializes a new intance from given register values.
        /// </summary>
        /// <param name="registerValueClk30">Value of CLK3-0 Disable State register.</param>
        /// <param name="registerValueClk74">Value of CLK7-4 Disable State register.</param>
        public ClockDisableState(byte registerValueClk30, byte registerValueClk74)
        {
            ClockOutput0 = ByteToDisableState((byte)(registerValueClk30 >> 0));
            ClockOutput1 = ByteToDisableState((byte)(registerValueClk30 >> 2));
            ClockOutput2 = ByteToDisableState((byte)(registerValueClk30 >> 4));
            ClockOutput3 = ByteToDisableState((byte)(registerValueClk30 >> 6));
            ClockOutput4 = ByteToDisableState((byte)(registerValueClk74 >> 0));
            ClockOutput5 = ByteToDisableState((byte)(registerValueClk74 >> 2));
            ClockOutput6 = ByteToDisableState((byte)(registerValueClk74 >> 4));
            ClockOutput7 = ByteToDisableState((byte)(registerValueClk74 >> 6));
        }

        /// <inheritdoc/>
        public Address Address => Addresses[0];

        /// <inheritdoc/>
        public Address[] Addresses => new Address[] { Address.CLK30DISSTATE, Address.CLK74DISSTATE };

        /// <inheritdoc/>
        public byte[] ToBytes()
        {
            _buffer[0] = (byte)(DisableStateToByte(ClockOutput3) << 6 | DisableStateToByte(ClockOutput2) << 4 | DisableStateToByte(ClockOutput1) << 2 | DisableStateToByte(ClockOutput0) << 0);
            _buffer[1] = (byte)(DisableStateToByte(ClockOutput7) << 6 | DisableStateToByte(ClockOutput6) << 4 | DisableStateToByte(ClockOutput5) << 2 | DisableStateToByte(ClockOutput4) << 0);
            return _buffer;
        }

        private static DisableState ByteToDisableState(byte value) =>
            (value & 0b0000_0011) switch
            {
                0b0000_0000 => DisableState.Low,
                0b0000_0001 => DisableState.High,
                0b0000_0010 => DisableState.HighImpedance,
                0b0000_0011 => DisableState.Never,
                _ => throw new NotImplementedException()
            };

        private static byte DisableStateToByte(DisableState disableState) =>
            disableState switch
            {
                DisableState.Low => 0b0000_0000,
                DisableState.High => 0b0000_0001,
                DisableState.HighImpedance => 0b0000_0010,
                DisableState.Never => 0b0000_0011,
                _ => throw new NotImplementedException()
            };

        /// <summary>
        /// Defines the set of output disable states.
        /// </summary>
        public enum DisableState
        {
            /// <summary>
            /// Output is low when disabled.
            /// </summary>
            Low,

            /// <summary>
            /// Output is high when disabled.
            /// </summary>
            High,

            /// <summary>
            /// Output has high impedance when disabled.
            /// </summary>
            HighImpedance,

            /// <summary>
            /// Output is never disabled.
            /// </summary>
            Never
        }
    }
}
