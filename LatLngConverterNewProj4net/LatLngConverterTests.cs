namespace LatLngConverterNewProj4net
{
    [TestClass]
    public sealed class LatLngConverterTests
    {
        [TestMethod]
        public void ConvertToLatLng()
        {
            //arrange
            var north = 6650800;
            var east = 259100;

            //act
            var latLng = LatLngConverter.ConvertUTM33ToLatLon(north, east);

            //assert
            Assert.AreEqual(59.92403938645684, latLng.Lat);
            Assert.AreEqual(10.688916857615725, latLng.Lng);
        }

        [TestMethod]
        public void ConvertToLatLngWithWKT()
        {
            //arrange
            var north = 6650800;
            var east = 259100;

            //act
            var latLng = LatLngConverter.ConvertUTM33ToLatLonFromWKT(north, east);

            //assert
            Assert.AreEqual(59.92403938645684, latLng.Lat);
            Assert.AreEqual(10.688916857615725, latLng.Lng);
        }
    }
}