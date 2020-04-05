using GuessMovieGame;
using NUnit.Framework;

namespace GuessMovieGameTests
{
    [TestFixture]
    public class GuessMovieGameTests
    {
        [Test]
        public void GetMovieLength()
        {
            Movie newMovie = new Movie("Титаник","С лео дикаприо");
            int expectedLength = 7;
            int actualLength = newMovie.GetMovieLength();

            Assert.AreEqual(expectedLength, actualLength);
        }
    }
}