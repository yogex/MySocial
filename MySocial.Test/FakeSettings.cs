using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;

namespace MySocial.Test
{
    internal class FakeSettings
    {
        internal static IApplicationSettings GetFake()
        {
            var appSettings = A.Fake<IApplicationSettings>();

            A.CallTo(() => appSettings.FacebookAppKey).Returns("540740926047667");
            A.CallTo(() => appSettings.FacebookAppSecret).Returns("80508b188cfe0de0dfd51b1c9909ec0f");
            A.CallTo(() => appSettings.TwitterAppKey).Returns("lJbyz3I2dkEhBOsi2jqibg6Oh");
            A.CallTo(() => appSettings.TwitterAppSecret).Returns("LG453b9DaFReCbHa8t3ty5DPT4wLqBBeuxkqjQAJp1tTkFyGlz");

            return appSettings;
        }
    }
}
