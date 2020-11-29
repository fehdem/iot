using System;
using Xunit;
using Iot.Device.Si5351.Register;

namespace Iot.Device.Si5351.Tests
{
    public class DeviceStatusTest
    {
        [Fact]
        public void DeviceStatus_CheckAddress()
        {
            var reg = new DeviceStatus(0);
            Assert.Equal(Address.DeviceStatus, reg.Address);
        }

        [Theory]
        [InlineData(0b0000_0000, 0, false, false, false, false)]
        [InlineData(0b0000_0001, 1, false, false, false, false)]
        [InlineData(0b0000_0010, 2, false, false, false, false)]
        [InlineData(0b0000_0100, 0, false, false, false, false)]
        [InlineData(0b0000_1000, 0, false, false, false, false)]
        [InlineData(0b0001_0000, 0, true, false, false, false)]
        [InlineData(0b0010_0000, 0, false, true, false, false)]
        [InlineData(0b0100_0000, 0, false, false, true, false)]
        [InlineData(0b1000_0000, 0, false, false, false, true)]
        public void DeviceStatus_InitializeFromRegisterValue(byte registerValue, byte revision, bool clockSignalValid, bool pllALocked, bool pllBLocked, bool initialized)
        {
            var reg = new DeviceStatus(registerValue);
            Assert.Equal(revision, reg.Revision);
            Assert.Equal(clockSignalValid, reg.ClockSignalValid);
            Assert.Equal(pllALocked, reg.PllALocked);
            Assert.Equal(pllBLocked, reg.PllBLocked);
            Assert.Equal(initialized, reg.Initialized);
        }
    }
}
