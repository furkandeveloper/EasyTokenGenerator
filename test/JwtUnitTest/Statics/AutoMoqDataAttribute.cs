using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtUnitTest.Statics
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            :base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {

        }
    }
}
