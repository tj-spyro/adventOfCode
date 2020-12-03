using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace ToolsTests.CookieRequestorTests
{
    [TestFixture]
    public class When_running_get_cookie_when_exists_in_file
    {
        private ICookieRequestor _sut;
        private const string Cookie = "this is a cookie!";
        
        [SetUp]
        public void Setup()
        {
            var mockFileHandler = new Mock<IFileHandler>();
            mockFileHandler.Setup(f => f.GetFileContents(It.IsAny<string>())).Returns(Cookie);
            
            _sut = new CookieRequestor(mockFileHandler.Object, new Mock<IConsoleTools>().Object);
        }

        [Test]
        public void Then_the_cookie_value_is_returned()
        {
            Assert.That(_sut.GetCookie(), Is.EqualTo(Cookie));
        }
    }
    
    [TestFixture]
    public class When_running_get_cookie_when_not_exists_in_file
    {
        private readonly Mock<IFileHandler> _mockFileHandler = new Mock<IFileHandler>(); 
        private readonly string Cookie = string.Empty;
        private const string ConsoleReturn = "this is a cookie!";
        private string returnedValue;
        
        [SetUp]
        public void Setup()
        {
            _mockFileHandler.Setup(f => f.GetFileContents(It.IsAny<string>())).Returns(Cookie);
            
            var mockConsoleTools = new Mock<IConsoleTools>();
            mockConsoleTools.Setup(c => c.GetStr(It.IsAny<string>())).Returns(ConsoleReturn);
            
            var sut = new CookieRequestor(_mockFileHandler.Object, mockConsoleTools.Object);
            returnedValue = sut.GetCookie();
        }

        [Test]
        public void Then_the_cookie_value_is_returned()
        {
            Assert.That(returnedValue, Is.EqualTo(ConsoleReturn));
        }

        [Test]
        public void Then_the_contents_is_set_to_file()
        {
            _mockFileHandler.Verify(f => f.SetFileContents(It.IsAny<string>(),It.Is<string>(s => s.Equals(ConsoleReturn))),Times.Once);
        }
    }
}