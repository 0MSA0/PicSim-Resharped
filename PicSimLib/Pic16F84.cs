namespace PicSimLib;

public class Pic16F84
{
    public byte[,] RAM { private set; get; } = new byte[2, 128];
    public byte[] Stack { private set; get; } = new byte[8];

    public byte StackPointer { private set; get; } = 0;
    public byte PC { private set; get; } = 0;
    public sbyte IndirectRP0 { private set; get; } = -1; // Why is this -1 again?
    
    // TODO: Timers
    
    public byte WRegister { private set; get; } = 0;
    public byte InstructionReg { private set; get; } = 0;
    public byte QuartzFrequency { set; get; } = 4;

    public UInt64 RunTime { set; get; } = 0;
    public bool WDTEnabled { set; get; } = false;

    #region ConstAddresses
    
    private enum SFRAddress
    {
        INDIRECT = 0x0,
        TMR0_OPTION = 0x1,
        PCL = 0x2,
        STATUS = 0x3,
        FSR = 0x4,
        PORTA_TRISA = 0x5,
        PORTB_TRISB = 0x6,
        // 0x07 doesn't exist
        EEDATA_EECON1 = 0x8,
        EEADR_EECON2 = 0x9,
        PCLATH = 0xA,
        INTCON = 0xB
    }

    private enum INTCBits
    {
        RBIF,
        INTF,
        T0IF,
        RBIE,
        INTE,
        T0IE,
        EEIE,
        GIE
    }

    #endregion

    public Pic16F84()
    {
        RAM[1, (int)SFRAddress.TMR0_OPTION] = 0xFF;
        RAM[0, (int)SFRAddress.STATUS] = 0x18;
        RAM[1, (int)SFRAddress.STATUS] = 0x18;
        RAM[1, (int)SFRAddress.PORTA_TRISA] = 0x1F;
        RAM[1, (int)SFRAddress.PORTB_TRISB] = 0xFF;

    }
}