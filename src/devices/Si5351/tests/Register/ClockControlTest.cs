using System;
using Xunit;
using Iot.Device.Si5351.Register;

namespace Iot.Device.Si5351.Tests
{
    public class ClockControlTest
    {
        [Theory]
        [InlineData(0, (byte)Address.CLK0, true)]
        [InlineData(1, (byte)Address.CLK1, true)]
        [InlineData(2, (byte)Address.CLK2, true)]
        [InlineData(3, (byte)Address.CLK3, true)]
        [InlineData(4, (byte)Address.CLK4, true)]
        [InlineData(5, (byte)Address.CLK5, true)]
        [InlineData(6, (byte)Address.CLK6, true)]
        [InlineData(7, (byte)Address.CLK7, true)]
        [InlineData(8, 0, false)]
        public void ClockControl_CheckIfRegisterAddressIsCorrectForGivenClockNumber(int clockNumber, byte registerAddress, bool isValid)
        {
            if (isValid)
            {
                Assert.Equal(registerAddress, (byte)new ClockControl(clockNumber,
                                                                     ClockControl.DriveStrength.Output2mA,
                                                                     ClockControl.InputSource.MultiSynth,
                                                                     ClockControl.Inversion.NotInverted,
                                                                     ClockControl.DividerSource.PLLA,
                                                                     ClockControl.IntegerMode.FractionalDivision,
                                                                     ClockControl.PowerState.PoweredDown).Address);
                Assert.Equal(registerAddress, (byte)new ClockControl(clockNumber, 0).Address);
            }
            else
            {
                Assert.Throws<ArgumentException>(() => new ClockControl(clockNumber,
                                                                        ClockControl.DriveStrength.Output2mA,
                                                                        ClockControl.InputSource.MultiSynth,
                                                                        ClockControl.Inversion.NotInverted,
                                                                        ClockControl.DividerSource.PLLA,
                                                                        ClockControl.IntegerMode.FractionalDivision,
                                                                        ClockControl.PowerState.PoweredDown).Address);
                Assert.Throws<ArgumentException>(() => new ClockControl(clockNumber, 0).Address);
            }
        }

        [Theory]
        [InlineData(0b0000_0000, ClockControl.DriveStrength.Output2mA, ClockControl.InputSource.XTAL, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b0000_0001, ClockControl.DriveStrength.Output4mA, ClockControl.InputSource.XTAL, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b0000_0010, ClockControl.DriveStrength.Output6mA, ClockControl.InputSource.XTAL, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b0000_0011, ClockControl.DriveStrength.Output8mA, ClockControl.InputSource.XTAL, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b0000_0100, ClockControl.DriveStrength.Output2mA, ClockControl.InputSource.CLKIN, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b0000_1100, ClockControl.DriveStrength.Output2mA, ClockControl.InputSource.MultiSynth, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b0001_0000, ClockControl.DriveStrength.Output2mA, ClockControl.InputSource.XTAL, ClockControl.Inversion.Inverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b0010_0000, ClockControl.DriveStrength.Output2mA, ClockControl.InputSource.XTAL, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLB_VCXO, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b0100_0000, ClockControl.DriveStrength.Output2mA, ClockControl.InputSource.XTAL, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.Integer, ClockControl.PowerState.PoweredUp)]
        [InlineData(0b1000_0000, ClockControl.DriveStrength.Output2mA, ClockControl.InputSource.XTAL, ClockControl.Inversion.NotInverted, ClockControl.DividerSource.PLLA, ClockControl.IntegerMode.FractionalDivision, ClockControl.PowerState.PoweredDown)]
        public void ClockControl_InitializeFromRegisterValue(byte registerValue,
                                                             ClockControl.DriveStrength driveStrength,
                                                             ClockControl.InputSource inputSource,
                                                             ClockControl.Inversion inversion,
                                                             ClockControl.DividerSource dividerSource,
                                                             ClockControl.IntegerMode integerMode,
                                                             ClockControl.PowerState powerState)
        {
            var register = new ClockControl(0, registerValue);
            Assert.Equal(driveStrength, register.OutputDriveStrength);
            Assert.Equal(inputSource, register.ClockInputSource);
            Assert.Equal(inversion, register.OutputInversion);
            Assert.Equal(dividerSource, register.MultiSynthDividerSource);
            Assert.Equal(integerMode, register.MultiSynthIntegerMode);
            Assert.Equal(powerState, register.OutputPowerState);
        }

        [Theory]
        [InlineData(0b0000_0000)]
        [InlineData(0b0000_0001)]
        [InlineData(0b0000_0010)]
        [InlineData(0b0000_0100)]
        [InlineData(0b0000_1000)]
        [InlineData(0b0001_0000)]
        [InlineData(0b0010_0000)]
        [InlineData(0b0100_0000)]
        [InlineData(0b1000_0000)]
        public void ClockControl_ToByte(byte registerValue)
        {
            Assert.Equal(registerValue, new ClockControl(0, registerValue).ToByte());
        }
    }
}
