using Infrastructure.Common.Extensions.PathUtilities;
using Infrastructure.Common.Extensions.PathUtilities.Exceptions;

namespace Infrastructure.Common.Extensions.UnitTests.PathUtilities
{
    public class PathUtilitiesTests
    {
        [Fact]
        public void PathInvalidDirectorySeparatorTest()
        {
            Assert.Throws<InvalidDirectorySeperatorCharException>(
                () => PathUtilitiesExtension.RemoveFolder("/", 1, "\\\\")
                );
        }
        [Fact]
        public void PathTest()
        {
            string input = "/first/second/third/forth/fifth/";
            string expected = "/first/second/";
            string result = PathUtilitiesExtension.RemoveFolder(input, 3, "/");
            Assert.Equal(expected, result);
        }
    }
}
