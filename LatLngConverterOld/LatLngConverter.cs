using DotSpatial.Projections;
using LatLngConverterOld.Model;

namespace LatLngConverterOld
{
    public class LatLngConverter
    {
        // ETRS89 / UTM zone 33N
        // Most NVE map services uses this as the default sr
        private const int ETRS89_UTM_Z33 = 25833;

        public static LatLngPoint ConvertUTM33ToLatLon(double north, double east)
        {
            var xy = new double[2];
            xy[0] = east;
            xy[1] = north;

            //An array for the z coordinate
            var z = new double[1];
            z[0] = 1;

            //Defines the starting coordiante system
            var pStart = ProjectionInfo.FromEpsgCode(ETRS89_UTM_Z33);

            //Defines the ending coordiante system
            var pEnd = KnownCoordinateSystems.Geographic.World.WGS1984;

            //Calls the reproject function that will transform the input location to the output locaiton
            Reproject.ReprojectPoints(xy, z, pStart, pEnd, 0, 1);

            return new LatLngPoint
            {
                Lat = xy[1],
                Lng = xy[0]
            };
        }
    }
}