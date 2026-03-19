using System.ComponentModel;

namespace Music.Domain.Enum
{
    public enum Gender
    {
        [Description("Nam")]
        Male = 0,
        [Description("Nữ")]
        Female = 1,
    }
}
