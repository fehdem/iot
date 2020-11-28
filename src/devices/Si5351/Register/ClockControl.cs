// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.Si5351.Register
{
    /// <summary>
    /// Defines the bits of a clock control register (CLK0 control - CLK7 control).
    /// </summary>
    public record ClockControl : IRegister
    {
        private readonly int _clockNumber;

        /// <summary>
        /// Defines the the set of clock output driver power states.
        /// </summary>
        public enum PowerState
        {
            /// <summary>
            /// Clock output driver is powered up (default).
            /// </summary>
            PoweredUp,

            /// <summary>
            /// Clock output driver is power down to conserve power.
            /// </summary>
            PoweredDown
        }

        /// <summary>
        /// Defines the set of MultiSynth (MS0-7) divider integer modes.
        /// </summary>
        public enum IntegerMode
        {
            /// <summary>
            /// MultiSynth divider operates in fractional division mode (default).
            /// </summary>
            FractionalDivision,

            /// <summary>
            ///  MultiSynth divider operates in (forced) integer mode.
            /// </summary>
            Integer
        }

        /// <summary>
        /// Defines the set of sources for the MultiSynth divider.
        /// </summary>
        public enum DividerSource
        {
            /// <summary>
            /// PLL A is the source for the MultiSynth divider (default).
            /// </summary>
            PLLA,

            /// <summary>
            /// PLL B (Si5351A/C) or VCXO (Si5351B) is the source for the MultiSynth divider.
            /// </summary>
            PLLB_VCXO
        }

        /// <summary>
        /// Defines the set of clock output inversion states.
        /// </summary>
        public enum Inversion
        {
            /// <summary>
            /// Clock output is not inverted (default).
            /// </summary>
            NotInverted,

            /// <summary>
            /// Clock output is inverted.
            /// </summary>
            Inverted
        }

        /// <summary>
        /// Defines the set of clock input sources for the clock output.
        /// </summary>
        public enum InputSource
        {
            /// <summary>
            /// Connects the output to the XTAL input and bypasses synthesis stages (default).
            /// </summary>
            XTAL,

            /// <summary>
            /// Connects the output to the CLKIN pin and bypasses synthesis stages (Si5351C only).
            /// </summary>
            CLKIN,

            /// <summary>
            /// Connect the output to the MultiSynth divider (free-running or syncrhonous clock synthetization).
            /// </summary>
            MultiSynth
        }

        /// <summary>
        /// Defines the set of output strength levels (which influences rise and fall time of clock slopes as well).
        /// </summary>
        public enum DriveStrength
        {
            /// <summary>
            /// Output strength is 2 mA (default).
            /// </summary>
            Output2mA,

            /// <summary>
            /// Output strength is 4 mA.
            /// </summary>
            Output4mA,

            /// <summary>
            /// Output strength is 6 mA (for 85 Ohm termination).
            /// </summary>
            Output6mA,

            /// <summary>
            /// Output strength is 8 mA (for 50 Ohm termination).
            /// </summary>
            Output8mA
        }

        /// <summary>
        /// Strength level of the clock output.
        /// </summary>
        public DriveStrength OutputDriveStrength { get; init; }

        /// <summary>
        /// Input source of clock output.
        /// </summary>
        public InputSource ClockInputSource { get; init; }

        /// <summary>
        /// Inversion of the clock output.
        /// </summary>
        public Inversion OutputInversion { get; init; }

        /// <summary>
        /// Source of the MultiSynth divider.
        /// </summary>
        public DividerSource MultiSynthDividerSource { get; init; }

        /// <summary>
        /// MultiSynth integer mode.
        /// </summary>
        public IntegerMode MultiSynthIntegerMode { get; init; }

        /// <summary>
        /// Output power state.
        /// </summary>
        public PowerState OutputPowerState { get; init; }

        /// <summary>
        /// Initializes a new instance of a clock control register for the given clock number.
        /// </summary>
        /// <param name="clockNumber">Associated clock output (range: 0 to 7).</param>
        /// <param name="outputDriveStrength">CLKx_IDRV[1:0]: drive strength bits.</param>
        /// <param name="clockInputSource">CLKx_SRC[1:0]: clock input source bits.</param>
        /// <param name="outputInversion">CLKx_INV: output clock invert bit.</param>
        /// <param name="multiSynthDividerSource">MSx_SRC: MultiSynth source select bit.</param>
        /// <param name="multiSynthIntegerMode">MSx_INT: MultiSynth integer mode bit.</param>
        /// <param name="outputPowerState">CLKx_PDN: Output power down bit.</param>
        public ClockControl(int clockNumber,
                            DriveStrength outputDriveStrength,
                            InputSource clockInputSource,
                            Inversion outputInversion,
                            DividerSource multiSynthDividerSource,
                            IntegerMode multiSynthIntegerMode,
                            PowerState outputPowerState)
        {
            // check if the specified clock number is valid (w/o considering the actual device version that may have less than 8 clock output blocks)
            if (clockNumber < 0 || clockNumber > 7)
            {
                throw new ArgumentException($"Invalid clock number specified ({clockNumber}). The clock number must be between 0 and 7.");
            }

            _clockNumber = clockNumber;
            OutputDriveStrength = outputDriveStrength;
            ClockInputSource = clockInputSource;
            OutputInversion = outputInversion;
            MultiSynthDividerSource = multiSynthDividerSource;
            MultiSynthIntegerMode = multiSynthIntegerMode;
            OutputPowerState = outputPowerState;
        }

        /// <summary>
        /// Initializes a new intance from a given register value.
        /// </summary>
        /// <param name="clockNumber">Associated clock output (range: 0 to 7).</param>
        /// <param name="registerValue">Register value</param>
        public ClockControl(int clockNumber, byte registerValue)
        {
            _clockNumber = clockNumber;
            // check if the specified clock number is valid (w/o considering the actual device version that may have less than 8 clock output blocks)
            if (clockNumber < 0 || clockNumber > 7)
            {
                throw new ArgumentException($"Invalid clock number specified ({clockNumber}). The clock number must be between 0 and 7.");
            }

            OutputDriveStrength = (registerValue & 0b0000_0011) switch
            {
                0b0000_0000 => DriveStrength.Output2mA,
                0b0000_0001 => DriveStrength.Output4mA,
                0b0000_0010 => DriveStrength.Output6mA,
                0b0000_0011 => DriveStrength.Output8mA,
                _ => throw new NotImplementedException()
            };

            ClockInputSource = (registerValue & 0b0000_1100) switch
            {
                0b0000_0000 => InputSource.XTAL,
                0b0000_0100 => InputSource.CLKIN,
                0b0000_1100 => InputSource.MultiSynth,
                _ => throw new NotImplementedException()
            };

            OutputInversion = (registerValue & 0b0001_0000) != 0 ? Inversion.Inverted : Inversion.NotInverted;
            MultiSynthDividerSource = (registerValue & 0b0010_0000) != 0 ? DividerSource.PLLB_VCXO : DividerSource.PLLA;
            MultiSynthIntegerMode = (registerValue & 0b_0100_0000) != 0 ? IntegerMode.Integer : IntegerMode.FractionalDivision;
            OutputPowerState = (registerValue & 0b1000_0000) != 0 ? PowerState.PoweredDown : PowerState.PoweredUp;
        }

        /// <inheritdoc/>
        public byte ToByte()
        {
            byte registerValue = 0;

            // CLKx[1:0] - CLKx_IDRV[1:0]
            registerValue |= OutputDriveStrength switch
            {
                DriveStrength.Output2mA => 0b0000_0000,
                DriveStrength.Output4mA => 0b0000_0001,
                DriveStrength.Output6mA => 0b0000_0010,
                DriveStrength.Output8mA => 0b0000_0011,
                _ => throw new NotImplementedException()
            };

            // CLKx[3:2] - CLKx_SRC[1:0]
            registerValue |= ClockInputSource switch
            {
                InputSource.XTAL => 0b0000_0000,
                InputSource.CLKIN => 0b0000_0100,
                InputSource.MultiSynth => 0b0000_1100,
                _ => throw new NotImplementedException()
            };

            // CLKx[4] - CLKx_INV
            registerValue |= OutputInversion == Inversion.NotInverted ? 0b0000_0000 : 0b0001_0000;

            // CLKx[5] - MSx_SRC
            registerValue |= MultiSynthDividerSource == DividerSource.PLLA ? 0b_0000_00000 : 0b0010_0000;

            // CLKx[6] - MSx_INT
            registerValue |= MultiSynthIntegerMode == IntegerMode.FractionalDivision ? 0b0000_0000 : 0b0100_0000;

            // CLKx[7] - CLKx_PDN
            registerValue |= OutputPowerState == PowerState.PoweredUp ? 0b0000_0000 : 0b1000_0000;

            return registerValue;
        }

        /// <inheritdoc/>
        public Address Address => _clockNumber switch
        {
            0 => Address.CLK0,
            1 => Address.CLK1,
            2 => Address.CLK2,
            3 => Address.CLK3,
            4 => Address.CLK4,
            5 => Address.CLK5,
            6 => Address.CLK6,
            7 => Address.CLK7,
            _ => throw new Exception($"Invalid clock number: {_clockNumber}.")
        };
    }
}
