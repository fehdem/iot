using Xunit;
using Iot.Device.Si5351.Register;
using static Iot.Device.Si5351.Register.ClockDisableState;

namespace Iot.Device.Si5351.Tests
{
    public class ClockDisableStateTest
    {
        [Fact]
        public void ControlDisableState_CheckAddresses()
        {
            var reg = new ClockDisableState(0, 0);
            Assert.Equal(Address.CLK30DISSTATE, reg.Address);
            Assert.Equal(2, reg.Addresses.Length);
            Assert.Equal(Address.CLK30DISSTATE, reg.Addresses[0]);
            Assert.Equal(Address.CLK74DISSTATE, reg.Addresses[1]);
        }

        [Theory]
        [InlineData(0b0000_0000, 0b0000_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0001, 0b0000_0000, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0010, 0b0000_0000, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0011, 0b0000_0000, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0100, 0b0000_0000, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_1000, 0b0000_0000, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_1100, 0b0000_0000, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0001_0000, 0b0000_0000, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0010_0000, 0b0000_0000, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0011_0000, 0b0000_0000, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0100_0000, 0b0000_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b1000_0000, 0b0000_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b1100_0000, 0b0000_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0000_0001, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0000_0010, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0000_0011, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0000_0100, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0000_1000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0000_1100, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0001_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0010_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0011_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low)]
        [InlineData(0b0000_0000, 0b0100_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High)]
        [InlineData(0b0000_0000, 0b1000_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance)]
        [InlineData(0b0000_0000, 0b1100_0000, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never)]
        public void ClockDisableState_InitializeFromRegisterValue(byte regVal30,
                                                                  byte regVal74,
                                                                  DisableState state0,
                                                                  DisableState state1,
                                                                  DisableState state2,
                                                                  DisableState state3,
                                                                  DisableState state4,
                                                                  DisableState state5,
                                                                  DisableState state6,
                                                                  DisableState state7)
        {
            var register = new ClockDisableState(regVal30, regVal74);
            Assert.Equal(state0, register.ClockOutput0);
            Assert.Equal(state1, register.ClockOutput1);
            Assert.Equal(state2, register.ClockOutput2);
            Assert.Equal(state3, register.ClockOutput3);
            Assert.Equal(state4, register.ClockOutput4);
            Assert.Equal(state5, register.ClockOutput5);
            Assert.Equal(state6, register.ClockOutput6);
            Assert.Equal(state7, register.ClockOutput7);
        }

        [Theory]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_0000, 0b0000_0000)]
        [InlineData(DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_0001, 0b0000_0000)]
        [InlineData(DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_0010, 0b0000_0000)]
        [InlineData(DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_0011, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_0100, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_1000, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_1100, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0001_0000, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0010_0000, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0011_0000, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b0100_0000, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b1000_0000, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, 0b1100_0000, 0b0000_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_0000, 0b0000_0001)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_0000, 0b0000_0010)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, DisableState.Low, 0b0000_0000, 0b0000_0011)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, DisableState.Low, 0b0000_0000, 0b0000_0100)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, DisableState.Low, 0b0000_0000, 0b0000_1000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, DisableState.Low, 0b0000_0000, 0b0000_1100)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, DisableState.Low, 0b0000_0000, 0b0001_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, DisableState.Low, 0b0000_0000, 0b0010_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, DisableState.Low, 0b0000_0000, 0b0011_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.High, 0b0000_0000, 0b0100_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.HighImpedance, 0b0000_0000, 0b1000_0000)]
        [InlineData(DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Low, DisableState.Never, 0b0000_0000, 0b1100_0000)]
        public void ClockDisableState_InitializeFromSettings_CheckPropertiesAndRegisterValue(DisableState state0,
                                                                                             DisableState state1,
                                                                                             DisableState state2,
                                                                                             DisableState state3,
                                                                                             DisableState state4,
                                                                                             DisableState state5,
                                                                                             DisableState state6,
                                                                                             DisableState state7,
                                                                                             byte regVal30,
                                                                                             byte regVal74)
        {
            var reg = new ClockDisableState(state0, state1, state2, state3, state4, state5, state6, state7);

            Assert.Equal(2, reg.ToBytes().Length);
            Assert.Equal(regVal30, reg.ToBytes()[0]);
            Assert.Equal(regVal74, reg.ToBytes()[1]);
        }
    }
}