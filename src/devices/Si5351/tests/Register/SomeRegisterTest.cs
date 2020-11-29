using System;
using Xunit;
using Iot.Device.Si5351.Register;

namespace Iot.Device.Si5351.Tests
{
    public class SomeRegisterTest
    {
        [Fact]
        public void ClockControl_CheckAddresses()
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData(0b0000_0000, 0)]
        [InlineData(0b0000_0001, 0)]
        public void SomeRegister_InitializeFromRegisterValue(byte registerValue,
                                                             int propertyValue)
        {
            _ = registerValue;
            _ = propertyValue;
            // var register = new SomeRegister(registerValue);
            // Assert.Equal(propertyValue, register.Property);
        }

        [Theory]
        [InlineData(0, 0b0000_0000)]
        [InlineData(0, 0b0000_0001)]
        public void ClockControl_InitializeFromSettings_CheckPropertiesAndRegisterValue(int propertyValue,
                                                                                        byte registerValue)
        {
            _ = propertyValue;
            _ = registerValue;
            // var register = new SomeRegister(0, propertyValue);
            // Assert.Equal(propertyValue, register.Property);
        }
    }
}