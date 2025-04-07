using DotSpatial.Projections;
using RegObs.GeoCode.Models;

namespace RegObs.GeoCode.Converters
{
    public class LatLngConverter
    {
        // ETRS89 / UTM zone 33N
        // Most NVE map services uses this as the default sr
        private const int ETRS89_UTM_Z33 = 25833;

        public static UTMPoint ConvertLatLonToUTM33(double lat, double lng)
        {
            var xy = new double[2];
            xy[0] = lng;
            xy[1] = lat;

            //An array for the z coordinate
            var z = new double[1];
            z[0] = 1;

            //Defines the starting coordiante system
            var pStart = KnownCoordinateSystems.Geographic.World.WGS1984;

            //Defines the ending coordiante system
            var pEnd = ProjectionInfo.FromEpsgCode(ETRS89_UTM_Z33);

            //Calls the reproject function that will transform the input location to the output locaiton
            Reproject.ReprojectPoints(xy, z, pStart, pEnd, 0, 1);

            return new UTMPoint
            {
                North = (int)xy[1],
                East = (int)xy[0],
                Zone = 33,
                Wkid = ETRS89_UTM_Z33
            };
        }

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
