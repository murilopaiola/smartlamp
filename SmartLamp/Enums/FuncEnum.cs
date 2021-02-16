using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLamp.Enums
{
    public enum FuncEnum
    {
        NULL0, //ignore
        Write,
        Read,
        RLed,
        GLed,
        BLed,
        StartCalibId,
        FixCalibId,
        WOutputRangePwr,
        WOutputRangeLgt,
        Pir,
        Ldr,
        ROutputRangeDevicesInOut,
        WOutputRangeDevicesInOut,
        RCurrentOutput,
        WLight,
        NULL1, //ignore
        WTimeOn,
        RReaddressIndividual,
        WReaddressIndividual,
        WPlusReaddressIndividual, //increments ID before sending
        WTypeIn,
        WTypeOut,
        WTypeInOut,
        RNominalCurrent,
        RCCurrent,
        Maintenance,
        NominalCurrent,
        CCurrent,
        ConvPowerLow,
        ConvPowerHigh

    }
}
