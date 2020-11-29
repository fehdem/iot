namespace Iot.Device.Si5351.Register
{
    /// <summary>
    /// Represents the Device Status register.
    /// The bits of this read-only register report general device status information.
    /// </summary>
    public class DeviceStatus : IRegister
    {
        /// <summary>
        /// Device revision number.
        /// </summary>
        public int Revision { get; init; }

        /// <summary>
        /// Clock signel (CLKIN pin) validity.
        /// </summary>
        /// <value>True, if the signal is valid, otherwise false.</value>
        public bool ClockSignalValid { get; init; }

        /// <summary>
        /// Locked state of PLL A.
        /// </summary>
        /// <value>True, if the PLL has been locked on a valid reference from CLKIN or XTAL, otherwise false.</value>
        public bool PllALocked { get; init; }

        /// <summary>
        /// Locked state of PLL B.
        /// </summary>
        /// <value>True, if the PLL has been locked on a valid reference from CLKIN or XTAL, otherwise false.</value>
        public bool PllBLocked { get; init; }

        /// <summary>
        /// Locked state of PLL A.
        /// </summary>
        /// <value>True, if the device initialization has been completed, otherwise false.</value>
        public bool Initialized { get; init; }

        /// <summary>
        /// Initializes a new intance of the Device Status register from a given register value.
        /// </summary>
        /// <param name="registerValue">Value of Device Status register (address 0)</param>
        public DeviceStatus(byte registerValue)
        {
            Revision = registerValue & 0b0000_0011;
            ClockSignalValid = (registerValue & 0b0001_0000) != 0;
            PllALocked = (registerValue & 0b0010_0000) != 0;
            PllBLocked = (registerValue & 0b0100_0000) != 0;
            Initialized = (registerValue & 0b1000_0000) != 0;
        }

        /// <inheritdoc/>
        public Address Address => Address.DeviceStatus;

        /// <inheritdoc/>
        public byte ToByte() => (byte)(Revision | (ClockSignalValid ? 0b0001_0000 : 0) | (PllALocked ? 0b0010_0000 : 0) | (PllBLocked ? 0b0100_0000 : 0) | (Initialized ? 0b1000_0000 : 0));
    }
}
