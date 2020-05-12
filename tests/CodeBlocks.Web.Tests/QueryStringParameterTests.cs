using CodeBlocks.Web.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Xunit;

namespace CodeBlocks.Web.Tests
{
    public class QueryStringParameterTests
    {
        public const string PropWithNameValue = "foo";
        public const string PropWithoutNameValue = "bar";


        [Fact]
        public void QueryStringParameter_With_Name_Value()
        {
            var requestObject = new SampleObject()
            {
                PropWithName = PropWithNameValue,
                PropWithoutName = PropWithoutNameValue
            };

            var queryString = requestObject.ToQueryString();
            Assert.NotNull(queryString);

            var data = QueryHelpers.ParseQuery(queryString);

            Assert.Contains(SampleObject.NamedParameterValue, data.Keys);
            Assert.Equal(PropWithNameValue, data[SampleObject.NamedParameterValue]);

            Assert.Contains(nameof(SampleObject.PropWithoutName), data.Keys);
            Assert.Equal(PropWithoutNameValue, data[nameof(SampleObject.PropWithoutName)]);
        }
    }


    public class SampleObject
    {
        public const string NamedParameterValue = "Prop_With_Name";

        [QueryStringParameter(Name = NamedParameterValue)]
        public string PropWithName { get; set; }

        [QueryStringParameter]
        public string PropWithoutName { get; set; }
    }
}
