 
namespace TUSA.Domain.Enums
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    //https://stackoverflow.com/questions/6034329/advice-about-building-an-error-code-lookup-in-c-sharp
    internal enum Errors
    { 
        [Description("Please remove the items that expire in a month")]
        ERR_EXPIRE_IN_A_MONTH = 0x00008D07,
        ERR1_EXPIRE_IN_A_MONTH

    } 
}
