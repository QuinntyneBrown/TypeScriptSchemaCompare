using System.Threading.Tasks;
using TypeScriptSchemaCompare.Core;
using Xunit;

namespace TypeScriptSchemaCompare.UnitTests
{
    public class CompareHandlerTests
    {

        [Fact]
        public async Task Handler_GiveTwoDifferentModels_HasErrors()
        {
            var sut = new CompareHandler();

            string typeScriptModel = @"
export interface Foo {
  profileID?: number;
  subject?: string;
  userId?: number;
}
";

            string compareToTypeScriptModel = @"
export interface FooBar {
  body?: string;
  profileId?: number;
  subject?: string;
}

";

            var result = await sut.Handle(new()
            {
                Source = typeScriptModel,
                CompareTo = compareToTypeScriptModel
            }, default);

            Assert.Equal(2, result.Errors.Length);
        }
    }
}
