using System.IO.Abstractions.TestingHelpers;
using NUnit.Framework;
using Tools;
// ReSharper disable InconsistentNaming

// ReSharper disable once CheckNamespace
namespace ToolsTests.FileHandlerTests
{
    [TestFixture]
    public class When_running_get_file_contents_when_file_and_directory_does_not_exist
    {
        private readonly MockFileSystem _mockFileSystem = new MockFileSystem();
        private const string CurrentDirectory = @"D:\";
        private const string Directory = @"newfolder";
        private const string File = @"newfile.txt";
        
        
        [SetUp]
        public void SetUp()
        {
            _mockFileSystem.Directory.SetCurrentDirectory(CurrentDirectory);
            var sut = new FileHandler(_mockFileSystem);
            sut.GetFileContents($@"{Directory}\{File}");
        }

        [Test]
        public void Then_directory_is_created()
        {
            Assert.That(_mockFileSystem.Directory.Exists($@"{CurrentDirectory}\{Directory}"),Is.True);
        }

        [Test]
        public void Then_file_is_created()
        {
            Assert.That(_mockFileSystem.File.Exists($@"{CurrentDirectory}\{Directory}\{File}"),Is.True);
        }
    }
    
    [TestFixture]
    public class When_running_get_file_contents_when_existing_file
    {
        private readonly MockFileSystem _mockFileSystem =  new MockFileSystem();
        private const string CurrentDirectory = @"D:\";
        private const string Directory = @"newfolder";
        private const string File = @"newfile.txt";
        private const string Contents = @"this is contents";
        private string _returnedContents;
        
        
        
        [SetUp]
        public void SetUp()
        {
            _mockFileSystem.Directory.SetCurrentDirectory(CurrentDirectory);
            _mockFileSystem.AddFile($@"{Directory}\{File}", new MockFileData(Contents));
            var sut = new FileHandler(_mockFileSystem);
            _returnedContents = sut.GetFileContents($@"{Directory}\{File}");
        }

        [Test]
        public void Then_file_is_created()
        {
            Assert.That(_returnedContents, Is.EqualTo(Contents));
        }
    }
    
    [TestFixture]
    public class When_running_set_file_contents_when_file_and_directory_does_not_exist
    {
        private readonly MockFileSystem _mockFileSystem = new MockFileSystem();
        private const string CurrentDirectory = @"D:\";
        private const string Directory = @"newfolder";
        private const string File = @"newfile.txt";
        private const string Contents = @"this is contents";
        
        
        [SetUp]
        public void SetUp()
        {
            _mockFileSystem.Directory.SetCurrentDirectory(CurrentDirectory);
            var sut = new FileHandler(_mockFileSystem);
            sut.SetFileContents($@"{Directory}\{File}",Contents);
        }

        [Test]
        public void Then_directory_is_created()
        {
            Assert.That(_mockFileSystem.Directory.Exists($@"{CurrentDirectory}\{Directory}"),Is.True);
        }

        [Test]
        public void Then_file_is_created()
        {
            Assert.That(_mockFileSystem.File.Exists($@"{CurrentDirectory}\{Directory}\{File}"),Is.True);
        }

        [Test]
        public void Then_file_contents_is_correct()
        {
            Assert.That(_mockFileSystem.File.ReadAllText($@"{CurrentDirectory}\{Directory}\{File}"),Is.EqualTo(Contents));
        }
    }
    
    [TestFixture]
    public class When_running_set_file_contents_when_file_exist
    {
        private readonly MockFileSystem _mockFileSystem = new MockFileSystem();
        private const string CurrentDirectory = @"D:\";
        private const string Directory = @"newfolder";
        private const string File = @"newfile.txt";
        private const string OldContents = @"old contents";
        private const string Contents = @"this is contents";
        
        
        [SetUp]
        public void SetUp()
        {
            _mockFileSystem.Directory.SetCurrentDirectory(CurrentDirectory);
            _mockFileSystem.AddFile($@"{Directory}\{File}", new MockFileData(OldContents));
            var sut = new FileHandler(_mockFileSystem);
            sut.SetFileContents($@"{Directory}\{File}",Contents);
        }

        [Test]
        public void Then_file_contents_is_correct()
        {
            Assert.That(_mockFileSystem.File.ReadAllText($@"{CurrentDirectory}\{Directory}\{File}"),Is.EqualTo(Contents));
        }
    }
}